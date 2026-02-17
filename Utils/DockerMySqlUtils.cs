using MySql.Data.MySqlClient;
using OrdemServicos.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServicos.Utils
{
    public class DockerMySqlUtils
    {
        private readonly string containerName;
        private readonly string connectionString;
        public DockerMySqlUtils()
        {
            containerName = ConfigurationManager.AppSettings["DockerContainerName"];
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public async Task BackupTablesAsync(List<string> tableNames, CustomProgressBar progressBar)
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(connectionString);

                string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
                if (!Directory.Exists(backupDir))
                    Directory.CreateDirectory(backupDir);

                progressBar.Minimum = 0;
                progressBar.Maximum = tableNames.Count;
                progressBar.Value = 0;
                progressBar.Visible = true;

                int currentTable = 0;

                foreach (var tableName in tableNames)
                {
                    currentTable++;
                    string dayOfWeek = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
                    string backupFilePath = Path.Combine(backupDir, $"Backup_{tableName}_{dayOfWeek}.sql");

                    string arguments =
                        $"exec {containerName} mysqldump --no-create-info --default-character-set=utf8mb4 " +
                        $"-h {builder.Server} -P {builder.Port} -u {builder.UserID} -p{builder.Password} {builder.Database} {tableName}";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "docker",
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(psi))
                    {
                        using (var reader = process.StandardOutput)
                        {
                            string dump = reader.ReadToEnd();
                            File.WriteAllText(backupFilePath, dump, Encoding.UTF8);
                        }
                        process.WaitForExit();
                    }

                    // Atualiza progresso
                    progressBar.Value = currentTable;

                    // Força redesenho para disparar o OnPaint do CustomProgressBar
                    progressBar.Refresh();

                    // Delay de 3 segundos (simulação de tempo de processamento)
                    await Task.Delay(3000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Erro ao realizar backup das tabelas: " + ex.Message);
            }
        }
        public void RestoreTable()
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(connectionString);

                string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
                string backupFilePath;

                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = backupDir;
                    dialog.Filter = "SQL Files (*.sql)|*.sql";
                    dialog.Title = "Selecione o arquivo de backup";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        backupFilePath = dialog.FileName;
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Nenhum arquivo selecionado.");
                        return;
                    }
                }

                string fileName = Path.GetFileNameWithoutExtension(backupFilePath);
                string[] parts = fileName.Split('_');
                if (parts.Length < 2)
                {
                    Console.WriteLine("❌ Nome do arquivo não segue o padrão esperado: Backup_<Tabela>_ddMMyyyy_HHmm.sql");
                    return;
                }
                string tableName = parts[1];
                string[] allLines = File.ReadAllLines(backupFilePath, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();

                foreach (string line in allLines)
                {
                    if (line.StartsWith("INSERT INTO") && line.Contains($"`{tableName}`"))
                    {
                        sb.AppendLine(line);
                    }
                }

                if (sb.Length == 0)
                {
                    Console.WriteLine($"⚠️ Nenhum dado encontrado para a tabela {tableName} no backup.");
                    return;
                }

                string arguments = $"exec -i {containerName} mysql --default-character-set=utf8mb4 -h {builder.Server} -P {builder.Port} -u {builder.UserID} -p{builder.Password} {builder.Database}";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "docker",
                    Arguments = arguments,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    process.StandardInput.WriteLine($"SET FOREIGN_KEY_CHECKS=0;");
                    process.StandardInput.WriteLine($"TRUNCATE TABLE `{tableName}`;");
                    process.StandardInput.WriteLine($"ALTER TABLE `{tableName}` AUTO_INCREMENT = 1;");
                    process.StandardInput.WriteLine($"SET FOREIGN_KEY_CHECKS=1;");

                    process.StandardInput.WriteLine(sb.ToString());

                    process.StandardInput.Close();
                    process.WaitForExit();
                }

                Console.WriteLine($"✅ Restore concluído da tabela: {tableName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Erro ao restaurar tabela: " + ex.Message);
            }
        }
    }
}