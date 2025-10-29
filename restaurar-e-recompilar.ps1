# Caminho do projeto
$projeto = "E:\ProjetosCSharp\Ordem-Servicos"
$csproj = Join-Path $projeto "Ordem-Servicos.csproj"

Write-Host "🔍 Verificando projeto em: $projeto"

# Verifica se o arquivo .csproj existe
if (!(Test-Path $csproj)) {
    Write-Host "❌ Projeto não encontrado: $csproj"
    exit
}

# Remove pasta de pacotes (se existir)
$packagesPath = Join-Path $projeto "packages"
if (Test-Path $packagesPath) {
    Write-Host "🧹 Removendo pasta de pacotes local..."
    Remove-Item -Recurse -Force $packagesPath
}

# Restaura pacotes NuGet
Write-Host "🔄 Restaurando pacotes NuGet..."
dotnet restore $csproj

# Limpa e recompila
Write-Host "🧼 Limpando projeto..."
dotnet clean $csproj

Write-Host "⚙️ Recompilando projeto..."
dotnet build $csproj

Write-Host "✅ Processo concluído!"
