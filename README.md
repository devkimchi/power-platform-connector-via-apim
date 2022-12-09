# Power Platform Custom Connector protected by Azure API Management #

This provides sample codes how to protect Power Platform custom connectors through Azure API Management as the "transparent" proxy.


## Getting Started ##

TBD

```bash
ATLASSIAN_INSTANCE_NAME={{Atlassian_InstanceName}}
```

```powershell
az login
gh auth login
```

```powershell
& $([Scriptblock]::Create($(Invoke-RestMethod https://aka.ms/azfunc-openapi/generate-openapi.ps1))) `
    -FunctionAppPath    dev/dk/power-platfform-connector-via-apim/src/ApiKeyAuthApp `
    -BaseUri            http://localhost:7071/api/ `
    -Endpoint           openapi/v3.json `
    -OutputPath         dev/dk/power-platfform-connector-via-apim/infra `
    -OutputFilename     openapi-apikeyauth.json `
    -Delay              30 `
    -UseWindows
```

```powershell
azd init
azd pipeline config --principal-name {{SERVICE_PRINCIPAL_NAME}} --principal-role "Contributor" --provider GitHub
azd provision
```

```powershell
gh workflow run "Azure Dev" --repo devkimchi/power-platfform-connector-via-apim
```
