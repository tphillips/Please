using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class AdminSettings : System.Web.UI.Page
    {

        private BroadcastSystem system
        {
            get
            {
                return Global.system;
                //                if (Application["system"] == null)
                //                {
                //                    Application["system"] = new BroadcastSystem();
                //                }
                //                return (BroadcastSystem)Application["system"];
            }
        }

        protected void Page_Load(object sender, EventArgs args)
        {
            if (!Page.IsPostBack)
            {
                txtSMTPServer.Text = system.Settings.SMTPServer;
                txtPort.Text = system.Settings.SMTPPort.ToString();
                txtMailFrom.Text = system.Settings.MailFrom;
                txtLinkUrl.Text = system.Settings.LinkUrl;
                txtEmailSubjectNewRequest.Text = system.Settings.EmailSubject_NewRequest;
                txtEmailBodyNewRequest.Text = system.Settings.EmailBody_NewRequest;
                txtEmailSubjectNewSubscriber.Text = system.Settings.EmailSubject_SubscriberWelcome;
                txtEmailBodyNewSubscriber.Text = system.Settings.EmailBody_SubscriberWelcome;
                txtEmailSubjectRequestAcceptedSubscribers.Text = system.Settings.EmailSubject_RequestAcceptedSubscribers;
                txtEmailBodyRequestAcceptedSubscribers.Text = system.Settings.EmailBody_RequestAcceptedSubscribers;
                txtEmailSubjectRequestAcceptedRequestor.Text = system.Settings.EmailSubject_RequestAcceptedRequestor;
                txtEmailBodyRequestAcceptedRequestor.Text = system.Settings.EmailBody_RequestAcceptedRequestor;
            }
        }

        protected void cmdSaveClick(object sender, EventArgs args)
        {
            if (Page.IsValid)
            {
                system.Settings.SMTPServer = txtSMTPServer.Text;
                system.Settings.SMTPPort = int.Parse(txtPort.Text);
                system.Settings.MailFrom = txtMailFrom.Text;
                system.Settings.LinkUrl = txtLinkUrl.Text;
                system.Settings.EmailSubject_NewRequest = txtEmailSubjectNewRequest.Text;
                system.Settings.EmailBody_NewRequest = txtEmailBodyNewRequest.Text;
                system.Settings.EmailSubject_SubscriberWelcome = txtEmailSubjectNewSubscriber.Text;
                system.Settings.EmailBody_SubscriberWelcome = txtEmailBodyNewSubscriber.Text;
                system.Settings.EmailSubject_RequestAcceptedSubscribers= txtEmailSubjectRequestAcceptedSubscribers.Text;
                system.Settings.EmailBody_RequestAcceptedSubscribers = txtEmailBodyRequestAcceptedSubscribers.Text;
                system.Settings.EmailSubject_RequestAcceptedRequestor= txtEmailSubjectRequestAcceptedRequestor.Text;
                system.Settings.EmailBody_RequestAcceptedRequestor = txtEmailBodyRequestAcceptedRequestor.Text;
                system.Save();
            }
        }

    }

}

