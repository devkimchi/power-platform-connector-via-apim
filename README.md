# Power Platform Custom Connector protected by Azure API Management #

This provides sample codes how to protect Power Platform custom connectors through Azure API Management as the "transparent" proxy.


## Getting Started ##

Read the following documents:

* [**API Key Auth**](./src/ApiKeyAuthApp/README.md)
* [**Basic Auth**](./src/BasicAuthApp/README.md)
* [**OAuth2 &ndash; Authorisation Code Auth**](./src/AuthCodeAuthApp/README.md)
* [**OAuth2 &ndash; Implicit Auth**](./src/ImplicitAuthApp/README.md)
* [**OpenID Connect Auth**](./src/OidcAuthApp/README.md)


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
