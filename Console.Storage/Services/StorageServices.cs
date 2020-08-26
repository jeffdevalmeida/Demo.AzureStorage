using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Storage.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class StorageServices
    {
        private static CloudTable AuthTable(string AzureTableName)
        {
            string accountName = "";
            string accountKey = "";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

                CloudTableClient client = account.CreateCloudTableClient();

                CloudTable table = client.GetTableReference(AzureTableName);

                return table;
            }
            catch
            {
                return null;
            }
        }
        
        public static TemperatureTable GetTemperatureTable()
        {
            var operation = TableOperation.Retrieve<TemperatureTable>("p1", "r1");
            var table = AuthTable("Temperature");
            var result = table.ExecuteAsync(operation);
            return result.Result.Result as TemperatureTable;
        }

        public static void UpdateTemperaturePreview(bool value)
        {
            TemperatureTable model = GetTemperatureTable();
            if (model != null)
            {
                model.ValidPreview = value;
                var operation = TableOperation.Replace(model);
                var table = AuthTable("Temperature");
                table.ExecuteAsync(operation);
            }
        }
    }
}
