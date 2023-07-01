using GetSecretManager.Manager;
using System;
using System.Threading.Tasks;

namespace GetSecretManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AwsManager.GetKey(args[0], args[1], args[2], args[3]);
        }
    }
}
