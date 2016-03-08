using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PushSharp.Apple;
using PushSharp.Google;
using PushSharp.Windows;
using SamplePushNotificationBroadcaster.Properties;

namespace SamplePushNotificationBroadcaster
{
    public partial class Form1 : Form
    {
        private const string GcmSenderId = "927829574554";
        private const string GcmSenderAuthToken = "AIzaSyBpSNEc5N3wdhzyGGDdZ5pZkOMzYqkJ7lA";
        private const string ApnsCertificateFile = @"\Resources\PushCertificates.p12";
        private const string ApnsCertificatePassword = "Welcome123";
        private const string WnsClientSecret = "";
        private const string WnsPackageSid = "";
        private const string WnsPackageName = "";

        public Form1()
        {
            InitializeComponent();

            txtDeviceToken.Text = Resources.Enter_device_token_or_registationId;
            rbAndroid.Checked = true;

            txtDeviceToken.GotFocus += (sender, args) =>
            {
                if (txtDeviceToken.Text != Resources.Enter_device_token_or_registationId)
                {
                    return;
                }
                txtDeviceToken.Text = string.Empty;
            };

            txtDeviceToken.LostFocus += (sender, args) =>
            {
                if (txtDeviceToken.Text != string.Empty)
                {
                    return;
                }
                txtDeviceToken.Text = Resources.Enter_device_token_or_registationId;
            };
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeviceToken.Text))
            {
                return;
            }

            progressBar1.Value = 5;
            progressBar1.Value += 5;

            var notificationPayload = JObject.Parse(JsonConvert.SerializeObject(new
            {
                Title = txtTitle.Text,
                Message = txtMessage.Text,
                Badge = txtBadge.Text
            }));

            if (rbAndroid.Checked)
            {
                var broker = new GcmServiceBroker(new GcmConfiguration(GcmSenderId, GcmSenderAuthToken, null));

                progressBar1.Value += 5;
                broker.Start();

                progressBar1.Value += 5;
                broker.QueueNotification(new GcmNotification
                {
                    RegistrationIds = new List<string> { txtDeviceToken.Text },
                    Data = notificationPayload
                });

                progressBar1.Value += 5;
                broker.Stop();
            }
            else if (rbiOS.Checked)
            {
                var certificateFilePath = Path.GetDirectoryName(Application.ExecutablePath) + ApnsCertificateFile;
                var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, certificateFilePath, ApnsCertificatePassword);
                var broker = new ApnsServiceBroker(config);

                progressBar1.Value += 5;
                broker.Start();

                progressBar1.Value += 5;
                broker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = txtDeviceToken.Text,
                    Payload = notificationPayload
                });

                progressBar1.Value += 5;
                broker.Stop();
            }
            else if (rbWindows.Checked)
            {
                var config = new WnsConfiguration(WnsPackageName, WnsPackageSid, WnsClientSecret);
                var broker = new WnsServiceBroker(config);

                progressBar1.Value += 5;
                broker.Start();

                progressBar1.Value += 5;
                broker.QueueNotification(new WnsToastNotification
                {
                    ChannelUri = txtDeviceToken.Text,
                    Payload = XElement.Parse(@"
                        <toast>
                            <visual>
                                <binding template=""ToastText01"">
                                    <text id=""1"">WNS_Send_Single</text>
                                </binding>  
                            </visual>
                        </toast>
                    ")
                });

                progressBar1.Value += 5;
                broker.Stop();
            }

            progressBar1.Value += 5;
            while (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            progressBar1.Value = 100;
        }
    }
}
