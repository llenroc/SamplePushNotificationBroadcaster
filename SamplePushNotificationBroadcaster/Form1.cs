using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PushSharp.Google;
using SamplePushNotificationBroadcaster.Properties;

namespace SamplePushNotificationBroadcaster
{
    public partial class Form1 : Form
    {
        private const string SenderId = "927829574554";
        private const string SenderAuthToken = "AIzaSyBpSNEc5N3wdhzyGGDdZ5pZkOMzYqkJ7lA";

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

            if (rbAndroid.Checked)
            {
                progressBar1.Value += 5;
                var broker = new GcmServiceBroker(new GcmConfiguration(SenderId, SenderAuthToken, null));

                progressBar1.Value += 5;
                broker.Start();

                progressBar1.Value += 5;
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    Title = txtTitle.Text,
                    Message = txtMessage.Text,
                    Badge = txtBadge.Text
                });
                broker.QueueNotification(new GcmNotification
                {
                    RegistrationIds = new List<string> { txtDeviceToken.Text },
                    Data = JObject.Parse(jsonString)
                });

                progressBar1.Value += 5;
                broker.Stop();

                progressBar1.Value += 5;
            }

            while (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            progressBar1.Value = 100;
        }
    }
}
