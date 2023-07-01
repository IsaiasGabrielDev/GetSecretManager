namespace GetSecretManager.Manager
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Amazon;
    using Amazon.S3;
    using Amazon.SecretsManager;
    using Amazon.SecretsManager.Model;

    public class AwsManager
    {
        public static async Task GetKey(string acessKey, string secretKey, string savefrom, string secretName)
        {
            try
            {
                var client = new AmazonSecretsManagerClient(acessKey, secretKey, RegionEndpoint.USEast1);

                var request = new GetSecretValueRequest
                {
                    SecretId = secretName
                };
                var response = await client.GetSecretValueAsync(request);

                Console.WriteLine(response.SecretString);

                string path = savefrom;
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(response.SecretString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
