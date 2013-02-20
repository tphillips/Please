/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 

using System;

namespace PleaseBLL
{

    [Serializable]
    public class SystemSettings
    {

        public string EmailBody_NewRequest { get; set; }
        public string EmailBody_SubscriberWelcome { get; set; }
        public string UI_AcceptedRequestThanks { get; set; }
        public string EmailSubject_SubscriberWelcome { get; set; }
        public string EmailSubject_RequestAcceptedRequestor { get; set; }
        public string EmailSubject_RequestAcceptedSubscribers { get; set; }
        public string UI_SubscriptionConfirmation { get; set; }
        public string UI_RequestAlreadyFulfilled { get; set; }
        public string UI_RequestBroadcasted { get; set; }
        public string EmailBody_RequestAcceptedSubscribers { get; set; }
        public string SMTPServer { get; set; }
        public string MailFrom { get; set; }
        public string EmailSubject_NewRequest { get; set; }
        public string EmailBody_RequestAcceptedRequestor { get; set; }
        public string LinkUrl { get; set; }
        public bool RequireRequestorsToBeSubscribers { get; set; }
        public int SMTPPort { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public bool SMTPSSL { get; set; }
        public bool ThreadEmails { get; set; }
        public string EmailBody_Unsubscribe { get; set; }
        public string EmailSubject_Unsubscribe { get; set; }

        public SystemSettings()
        {
        }

        /// <summary>
        /// This method sets the default settings for the system, these can then be changed in 
        /// the generated Settings.xml file.
        /// </summary>
        public static SystemSettings Default()
        {
            SystemSettings s = new SystemSettings();

            s.RequireRequestorsToBeSubscribers = true;
            s.LinkUrl = "http://localhost/BroadcastWeb/Respond.aspx";

            s.ThreadEmails = true;
            s.SMTPServer = "localhost";
            s.SMTPUser = "";
            s.SMTPPassword = "";
            s.SMTPSSL = false;
            s.SMTPPort = 25;
            s.MailFrom = "me@noreply.com";

            s.UI_RequestBroadcasted = "Your request has been broadcast to all subscribers of this list.  You will be notified if anyone accepts.";
            s.UI_SubscriptionConfirmation = "Thanks, you have been sent a confirmation email.";
            s.UI_AcceptedRequestThanks = "Thank you!  The list will be notified that the request for cover has been accepted.";
            s.UI_RequestAlreadyFulfilled = "Thank you for your kind offer, however this request for help has already been closed.";

            s.EmailSubject_SubscriberWelcome = "Welcome to the cover broadcast list";
            s.EmailBody_SubscriberWelcome = "Hi $name,\r\n\r\n" +
                "Thanks for subscribing to the cover broadcast list.\r\n\r\n" +
                    "Do NOT reply to this email.";

            s.EmailSubject_NewRequest = "Cover Request";
            s.EmailBody_NewRequest = "Hi $name,\r\n\r\n" +
                "$requestor needs help with $help.\r\n\r\n" +
                "To offer your help please click here: \r\n" +
                "$link\r\n\r\n" +
                    "Note that clicking this link will immediatley offer your help.  You will be advised of the result of your offer right away.\r\n\r\n" +
                "Do NOT reply to this email.";

            s.EmailSubject_RequestAcceptedSubscribers = "A request has been accepted";
            s.EmailBody_RequestAcceptedSubscribers = "Hi $name,\r\n\r\n" +
                "$requestor's help request for $help  has BEEN FULFILLED by $volunteer. If you are responsible for logging this change, please do so now.\r\n\r\n" +
                    "Do NOT reply to this email.";

            s.EmailSubject_RequestAcceptedRequestor = "Your request has been accepted!";
            s.EmailBody_RequestAcceptedRequestor = "Great news!\r\n\r\n" +
                "$acceptor has accepted your request for help for $help!\r\n\r\n" +
                    "Do NOT reply to this email.";

            s.EmailSubject_Unsubscribe = "You have been Unsubscribed";
            s.EmailBody_Unsubscribe = "Hi $name,\r\n\r\n" +
                "You have been removed from the broadcast list.\r\n\r\n" +
                    "Do NOT reply to this email.";

            return s;
        }
    }
}

