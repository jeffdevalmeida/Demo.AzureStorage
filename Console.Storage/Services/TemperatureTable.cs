using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Services
{
    public class TemperatureTable : TableEntity
    {
        public bool ValidPreview { get; set; }
    }
}
