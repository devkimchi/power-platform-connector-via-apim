# Power Platform Custom Connector protected by Azure API Management #

This provides sample codes how to protect Power Platform custom connectors through Azure API Management as the "transparent" proxy.


## Further Reading ##

* 한국어: TBD
* English: TBD


## Getting Started ##

There are two parts involved in this repository to implement the Power Platform custom connectors protected by Azure API Management.

* Provision and deploy apps
* Create custom connectors on Power Platform


### Provision and Deploy Apps ###

1. Log into Azure through Azure CLI.

   ```bash
   # Login to Azure
   az login

   # Login to Azure within GitHub Codespaces
   az login --use-device-code
   ```

2. Log into GitHub through GitHub CLI.

   ```bash
   gh auth login
   ```

3. Log into Azure Dev CLI.

   ```bash
   # Login to Azure
   azd login

   # Login to Azure within GitHub Codespaces
   azd login --use-device-code
   ```

4. Run the following command to configure Azure Dev CLI environment. It will ask you to enter all necessary information.

   ```bash
   azd init
   ```

   * Choose `Empty Template`.
   * Enter the **environment name** that represents your resource name on Azure.
   * Choose your **Azure subscription**.
   * Choose your **Azure resource location**.

5. Run the following command to configure Azure Dev CLI with GitHub Actions CI/CD pipeline. At the end of configuration, **DO NOT COMMIT AND PUSH** the local changes **FOR NOW**.

   ```bash
   azd pipeline config
   ```

6. Overwrite `azure.yaml` with `azure.sample.yaml`. Then replace all `{{AZURE_ENV_NAME}}` with your actual environment name.
7. Open `.azure/{{AZURE_ENV_NAME}}/.env` and add the following three lines. Make sure you replace `{{GITHUB_PERSONAL_ACCESS_TOKEN}}` and `{{GITHUB_USERNAME}}` with yours, respectively:

   ```bash
   GITHUB_REPOSITORY_NAME="power-platform-connector-via-apim"
   GITHUB_TOKEN="{{GITHUB_PERSONAL_ACCESS_TOKEN}}"
   GITHUB_USERNAME="{{GITHUB_USERNAME}}"
   ```

8. Run the following command to provision and deploy the apps.

   ```bash
   azd provision
   ```


### Custom Connecotrs on Power Platform ###

Each custom connector has its own way of authentication and authorisation. Read the following documents:

* [**API Key Auth**](./src/ApiKeyAuthApp/README.md)
* [**Basic Auth**](./src/BasicAuthApp/README.md)
* [**OAuth2 &ndash; Authorisation Code Auth**](./src/AuthCodeAuthApp/README.md)


## Issues? ##

If you find any issue while using this repository, please create an issue on the [issue](../../issues) page.

