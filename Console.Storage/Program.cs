using System;

namespace Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = true;

            StorageServices.UpdateTemperaturePreview(value);
        }
    }
}
