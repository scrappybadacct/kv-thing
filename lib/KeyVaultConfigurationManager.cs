using System;
using System.Threading.Tasks;

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace lib
{
  public class KeyVaultConfigurationManager
  {
    public async Task<String> GetSecretFromVaultMSI(String vaultName, String secretName)
    {
      String secretHttpsEndpoint = $"https://{vaultName}.vault.azure.net/secrets/{secretName}";
      AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();

      try
      {
        var keyVaultClient = new KeyVaultClient(
          new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback)
        );

        var secret = await keyVaultClient.GetSecretAsync(secretHttpsEndpoint);

        return secret.Value;
      }
      catch (Exception e)
      {
        return e.Message;
      }
    }
  }
}
