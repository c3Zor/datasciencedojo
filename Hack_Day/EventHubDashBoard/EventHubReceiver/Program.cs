﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus.Messaging;

namespace EventHubReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            string eventHubConnectionString = "Endpoint=sb://brucewaynetollbooth.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=LyWC2gtI/Rui6M1RltgNl3BKYQRICaWqMeqo8niolak=";
            string eventHubName = "anomalies";
            string storageAccountName = "dojoattendeestorage";
            string storageAccountKey = "OtJ77t3X6uMNIf6zd3xr4ZewW9vXDK9XQtaGXx7gOoaULgGQyBuvAfrC2aiOkUY/WV9H4lVU+ngaLUle7gVuWQ==";
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccountName, storageAccountKey);

            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString, storageConnectionString);
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>().Wait();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
        }
    }
}
