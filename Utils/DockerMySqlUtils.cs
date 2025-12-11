using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
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

        /// <summary>
        /// Faz backup somente dos dados (INSERTs) de uma lista de tabelas.
        /// Cada tabela gera um arquivo separado: Backup_<Tabela>_<DataHora>.sql
        /// </summary>
        public void BackupTables(List<string> tableNames)
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(connectionString);

                // Pasta Backup dentro do projeto
                string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
                if (!Directory.Exists(backupDir))
                    Directory.CreateDirectory(backupDir);

                foreach (var tableName in tableNames)
                {
                    // Nome do arquivo: Backup_<Tabela>_ddMMyyyy_HHmm.sql
                    string timestamp = DateTime.Now.ToString("ddMMyyyy_HHmm");
                    string backupFilePath = Path.Combine(backupDir, $"Backup_{tableName}_{timestamp}.sql");

                    // ✅ dump só dos dados da tabela e em UTF-8
                    string arguments = $"exec {containerName} mysqldump --no-create-info --default-character-set=utf8mb4 -h {builder.Server} -P {builder.Port} -u {builder.UserID} -p{builder.Password} {builder.Database} {tableName}";

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

                    Console.WriteLine($"✅ Backup da tabela {tableName} concluído: {backupFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Erro ao realizar backup das tabelas: " + ex.Message);
            }
        }

        /// <summary>
        /// Restaura o banco a partir de um arquivo .sql na pasta Backup.
        /// Se não passar nome, restaura o último backup.
        /// </summary>
        public void RestoreTable()
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(connectionString);

                string backupDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
                string backupFilePath;

                // ✅ Seleciona o arquivo de backup
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

                // ✅ Extrai o nome da tabela do arquivo
                // Exemplo: Backup_DBUsuarios_15122025_2100.sql → tabela = DBUsuarios
                string fileName = Path.GetFileNameWithoutExtension(backupFilePath);
                string[] parts = fileName.Split('_');
                if (parts.Length < 2)
                {
                    Console.WriteLine("❌ Nome do arquivo não segue o padrão esperado: Backup_<Tabela>_ddMMyyyy_HHmm.sql");
                    return;
                }
                string tableName = parts[1]; // pega a parte <Tabela>

                // ✅ Lê o arquivo e filtra apenas os INSERTs da tabela escolhida
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
                    // ✅ Limpa a tabela e zera o AUTO_INCREMENT antes de restaurar
                    process.StandardInput.WriteLine($"SET FOREIGN_KEY_CHECKS=0;");
                    process.StandardInput.WriteLine($"TRUNCATE TABLE `{tableName}`;");
                    process.StandardInput.WriteLine($"ALTER TABLE `{tableName}` AUTO_INCREMENT = 1;");
                    process.StandardInput.WriteLine($"SET FOREIGN_KEY_CHECKS=1;");

                    // ✅ Restaura os dados filtrados
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
