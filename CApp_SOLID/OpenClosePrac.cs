using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{

    //SOLID - Open/Closed Principle


    // below SendNotification class is not following Open/Closed Principle
    // because if we want to add new notification type like PushNotification then we need to modify the existing SendNotification class

   
    public class SendNotification
    {
        public void Send(string type, string msg)
        {
            if(type == "SMS")
            {
                //send SMS
            }
            else if (type == "Email")
            {
                //send Email
            }
            else
            {
                throw new NotSupportedException("Notification type not supported");
            }
        }
    }
    internal class OpenClosePrac
    {
        public static void TestOpenClose()
        {
            SendNotification sn = new SendNotification();
            sn.Send("SMS", "Hello via SMS");
            sn.Send("Email", "Hello via Email");

            sn.Send("Push", "Hello via Push"); // this will throw exception


            NotificationHandler notificationHandler = new NotificationHandler();

            notificationHandler.SendNotification(new SMSNotification(), "Hello via SMS");
            notificationHandler.SendNotification(new EmailNotification(), "Hello via Email");   

            notificationHandler.SendNotification(new PushNotification(), "Hello via Push");
        }
    }

    public interface INotification
    {
        void Send(string msg);
    }

    public class  SMSNotification : INotification
    {
        public void Send(string msg)
        {
            //send SMS
        }
    }

    public class EmailNotification : INotification
    {
        public void Send(string msg)
        {
            //send Email
        }
    }    

    public class NotificationHandler
    {
        public void SendNotification(INotification notification, string msg)
        {
            notification.Send(msg);
        }
    }

    // now if the requirement came to support Push notifications as well then we are not modifying the existing NotificationHandler class

    public class PushNotification : INotification
    {
        public void Send(string msg)
        {
            //send Push Notification
        }
    }
}
