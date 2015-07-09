﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace SendToast
{
    public partial class SentToast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSendToast_Click(object sender, EventArgs e)
        {
            try
            {
                string subscriptionUri = TextBoxUri.Text.ToString();
                HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(subscriptionUri);
                sendNotificationRequest.Method = "POST";

                // Create the toast message. 
                string toastMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<wp:Notification xmlns:wp=\"WPNotification\">" +
                "<wp:Toast>" +
                "<wp:Text1>" + TextBoxTitle.Text.ToString() + "</wp:Text1>" +
                "<wp:Text2>" + TextBoxSubTitle.Text.ToString() + "</wp:Text2>" +
                "<wp:Param>/Page2.xaml?NavigatedFrom=Toast Notification</wp:Param>" +
                "</wp:Toast> " +
                "</wp:Notification>";

                // Set the notification payload to send.
                byte[] notificationMessage = Encoding.Default.GetBytes(toastMessage);

                // Set the web request content length.
                sendNotificationRequest.ContentLength = notificationMessage.Length;
                sendNotificationRequest.ContentType = "text/xml";
                sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "toast");
                sendNotificationRequest.Headers.Add("X-NotificationClass", "2");

                using (Stream requestStream = sendNotificationRequest.GetRequestStream())
                {
                    requestStream.Write(notificationMessage, 0, notificationMessage.Length);
                }
                // Send the notification and get the response. 
                HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
                string notificationStatus = response.Headers["X-NotificationStatus"];
                string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

                // Display the response from the Microsoft Push Notification Service. 	
                // Normally, error handling code would be here. In the real world, because data connections are not always available, 	
                // notifications may need to be throttled back if the device cannot be reached. 
                TextBoxResponse.Text = notificationStatus + " | " + deviceConnectionStatus + " | " + notificationChannelStatus;
            }
            catch (Exception ex)
            {
                TextBoxResponse.Text = "Exception caught sending update: " + ex.ToString();
            }
        }
    }
}
