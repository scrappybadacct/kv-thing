using System;
using System.Threading.Tasks;
using lib;

namespace app
{
  class Program
  {
    static void Main(string[] args)
    {
      Task<String> secretTask = new KeyVaultConfigurationManager().GetSecretFromVaultMSI("c-test-keyvault", "c-test-secret-2");
      secretTask.Wait();

      System.Console.WriteLine(secretTask.Result);
    }
  }
}
