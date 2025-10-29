# Caminho do projeto
$projeto = "E:\ProjetosCSharp\Ordem-Servicos"

# Busca todos os arquivos .resx
Get-ChildItem -Path $projeto -Recurse -Filter *.resx | ForEach-Object {
    $arquivo = $_.FullName
    $stream = [System.IO.File]::Open($arquivo, [System.IO.FileMode]::Open, [System.IO.FileAccess]::ReadWrite)
    $stream.Close()

    # Remove a marca da Web (Zone.Identifier)
    if (Unblock-File -Path $arquivo -ErrorAction SilentlyContinue) {
        Write-Host "✅ Desbloqueado: $arquivo"
    } else {
        Write-Host "⚠️ Já desbloqueado ou erro: $arquivo"
    }
}
