using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.NotificationHubs;


namespace Cabspot.Controllers.Clases
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://cabspotpushnotificationshub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=jzNxQVUrtz7A5TBfN9QDdJMT5F6HvnV1E/jddfZSVa0=",   //"<your hub's DefaultFullSharedAccessSignature>",
                                                                         "cabspotpushnotificationshub");   //  "<hub name>");
        }
    }
}