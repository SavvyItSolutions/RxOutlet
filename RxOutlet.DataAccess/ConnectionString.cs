using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using System;



namespace RxOutlet.DataAccess
{
    public static class ConnectionString
    {
      
        static string account = Microsoft.Azure.CloudConfigurationManager.GetSetting("StorageAccountName");
        static string key = Microsoft.Azure.CloudConfigurationManager.GetSetting("StorageAccountKey");

        public static object CloudConfigurationManager { get; private set; }

        public static CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
