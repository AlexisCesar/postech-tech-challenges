$auxErrActPref = $ErrorActionPreference
$ErrorActionPreference = 'SilentlyContinue'

try {
    Write-Host "Select a environment"
    Write-Host "[1] dev"
    Write-Host "[2] prod"

    $env = Read-Host
    if($env -eq 1) {
        $env = "dev"
    } elseif($env -eq 2) {
        $env = "prod"
    } else {
        Write-Host "Invalid environment" -ForegroundColor Red
        exit
    }

    kubectl > $null

    if(!$?) {
        Write-Host "ERROR: kubectl not found" -ForegroundColor Red
        exit
    }

    helm > $null

    if(!$?) {
        Write-Host "ERROR: helm not found" -ForegroundColor Red
        exit
    }
    
    kubectl get node > $null

    if(!$?) {
        Write-Host "ERROR: k8s node not found. Is kubernetes running?" -ForegroundColor Red
        exit
    }

    kubectl get namespace dev > $null

    if(!$?) {
        Write-Host "dev namespace not found. Creating..." -ForegroundColor Yellow
        kubectl create namespace dev
    } else {
        Write-Host "dev namespace already created" -ForegroundColor Green
    }

    kubectl get namespace prod > $null

    if(!$?) {
        Write-Host "prod namespace not found. Creating..." -ForegroundColor Yellow
        kubectl create namespace prod
    } else {
        Write-Host "prod namespace already created" -ForegroundColor Green
    }

    Get-ChildItem ./helm/lanchonetedobairro_chart

    if(!$?) {
        Write-Host "helm/lanchonetedobairro_chart not found" -ForegroundColor Red
        exit
    }

    Write-Host "Trying to install chart in environment: $env" -ForegroundColor Cyan

    helm upgrade --install lanchonetedobairro-$env ./helm/lanchonetedobairro_chart --values ./helm/lanchonetedobairro_chart/values.yaml -f ./helm/lanchonetedobairro_chart/values-$env.yaml -n $env

    if(!$?) {
        Write-Host "ERROR: helm install failed" -ForegroundColor Red
        exit
    }

    Write-Host "Chart installation done! Environment: $env" -ForegroundColor Green
}
finally {
    $ErrorActionPreference = $auxErrActPref
}