using MySql.Data.MySqlClient;
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

        public async Task BackupTablesAsync(List<string> tableNames, ProgressBarCustom.ProgressBarCustom progressBar)
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
                progressBar.DisplayText = "Aguarde Realizando Backup...";
                progressBar.Visible = true;
                progressBar.AutoCenter = true;

                int currentTable = 0;

                foreach (var tableName in tableNames)
                {
                    currentTable++;
                    string dayOfWeek = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
                    string backupFilePath = Path.Combine(backupDir, $"Backup_{tableName}_{dayOfWeek}.sql");

                    // Executa docker dentro da VM via SSH
                    string sshUser = "mbc"; // substitua pelo usuário válido da VM
                    string sshHost = "192.168.2.200";

                    // Adicionada a flag --skip-extended-insert
                    string dockerCommand =
                        $"docker exec {containerName} mysqldump --no-create-info --skip-extended-insert --default-character-set=utf8mb4 " +
                        $"-h {builder.Server} -P {builder.Port} -u {builder.UserID} -p{builder.Password} {builder.Database} {tableName}";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "ssh",
                        Arguments = $"{sshUser}@{sshHost} \"{dockerCommand}\"",
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
                    progressBar.Visible = true;
                    progressBar.Value = currentTable;
                    progressBar.Refresh();

                    await Task.Delay(1000);
                }
                progressBar.Visible = false;
                progressBar.Refresh();
                MessageBox.Show("Backup Concluído com Sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Erro ao Realizar Backup das Tabelas: " + ex.Message);
            }
        }
        public async Task RestoreTableAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            string tableName = "";

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
                    Console.WriteLine("❌ Nome do arquivo não segue o padrão esperado: Backup_<Tabela>_...");
                    return;
                }
                tableName = parts[1];
                string[] allLines = File.ReadAllLines(backupFilePath, Encoding.UTF8);

                // Filtra apenas os INSERTs da tabela
                List<string> inserts = new List<string>();
                foreach (string line in allLines)
                {
                    if (line.StartsWith("INSERT INTO") && line.Contains($"`{tableName}`"))
                    {
                        inserts.Add(line);
                    }
                }

                if (inserts.Count == 0)
                {
                    Console.WriteLine($"⚠️ Nenhum dado encontrado para a tabela {tableName} no backup.");
                    return;
                }

                // Configura barra de progresso com número de INSERTs
                progressBar.Minimum = 0;
                progressBar.Maximum = inserts.Count;
                progressBar.Value = 0;
                progressBar.DisplayText = $"Aguarde Restaurando Backup {tableName}...";
                progressBar.Visible = true;
                progressBar.AutoCenter = true;

                string sshUser = "mbc"; // substitua pelo usuário válido da VM
                string sshHost = "192.168.2.200";

                string dockerCommand =
                    $"docker exec -i {containerName} mysql --default-character-set=utf8mb4 " +
                    $"-h {builder.Server} -P {builder.Port} -u {builder.UserID} -p{builder.Password} {builder.Database}";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "ssh",
                    Arguments = $"{sshUser}@{sshHost} \"{dockerCommand}\"",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    // Preparação da tabela
                    process.StandardInput.WriteLine($"SET FOREIGN_KEY_CHECKS=0;");
                    process.StandardInput.WriteLine($"TRUNCATE TABLE `{tableName}`;");
                    process.StandardInput.WriteLine($"ALTER TABLE `{tableName}` AUTO_INCREMENT = 1;");
                    process.StandardInput.WriteLine($"SET FOREIGN_KEY_CHECKS=1;");

                    int current = 0;
                    foreach (var insert in inserts)
                    {
                        process.StandardInput.WriteLine(insert);
                        progressBar.Visible = true;
                        current++;
                        progressBar.Value = current;
                        progressBar.Refresh();

                        await Task.Delay(100); // delay pequeno só para atualizar visualmente
                    }

                    process.StandardInput.Close();
                    process.WaitForExit();
                }
                progressBar.Visible = false;
                progressBar.Refresh();
                MessageBox.Show("Backup Restaurado com Sucesso!", 
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao Restaurar Tabela {tableName}: {ex.Message}");
            }
        }
    }
}