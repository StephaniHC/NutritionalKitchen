# Instala el generador de reportes si aún no está disponible globalmente
dotnet tool install -g dotnet-reportgenerator-globaltool --version 5.1.26

# Guardar el directorio actual
$dir = Get-Location

# Eliminar resultados de pruebas anteriores
Remove-Item -Recurse -Force "$dir\TestResults" -ErrorAction SilentlyContinue

# Ejecutar las pruebas y recolectar cobertura
$output = dotnet test --collect:"XPlat Code Coverage" --settings .runsettings 2>&1
Write-Host "Last Exit Code: $LASTEXITCODE"
Write-Host $output

# Extraer el GUID de la carpeta generada para resultados
$coverageFolder = Get-ChildItem "$dir\TestResults" | Sort-Object LastWriteTime -Descending | Select-Object -First 1
$coveragePath = "$($coverageFolder.FullName)\coverage.cobertura.xml"

# Validar existencia del archivo de cobertura
if (!(Test-Path $coveragePath)) {
    Write-Error "No se encontró el archivo de cobertura en: $coveragePath"
    exit 1
}

# Eliminar reportes anteriores
Remove-Item -Recurse -Force "$dir\coveragereport" -ErrorAction SilentlyContinue

# Crear carpeta de historial si no existe
$historyPath = "$dir\CoverageHistory"
if (!(Test-Path $historyPath)) {
    New-Item -ItemType Directory -Path $historyPath | Out-Null
}

# Generar el reporte en HTML
reportgenerator -reports:"$coveragePath" -targetdir:"$dir\coveragereport" -reporttypes:Html -historydir:"$historyPath"

# Abrir el reporte automáticamente si es un entorno de escritorio
$osInfo = Get-CimInstance -ClassName Win32_OperatingSystem
if ($osInfo.ProductType -eq 1) {
    Start-Process "$dir\coveragereport\index.html"
}
