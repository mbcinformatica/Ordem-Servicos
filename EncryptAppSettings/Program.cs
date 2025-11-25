using System;
using System.Configuration;

namespace EncryptAppSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Abre o App.config da aplicação alvo
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Pega a seção appSettings
                ConfigurationSection section = config.GetSection("appSettings");

                if (section != null)
                {
                    if (!section.SectionInformation.IsProtected)
                    {
                        // Criptografa usando RSA
                        section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                        section.SectionInformation.ForceSave = true;
                        config.Save(ConfigurationSaveMode.Full);

                        Console.WriteLine("✅ Seção 'appSettings' criptografada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("⚠️ A seção 'appSettings' já está criptografada.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Seção 'appSettings' não encontrada no App.config.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criptografar: " + ex.Message);
            }
        }
    }
}
