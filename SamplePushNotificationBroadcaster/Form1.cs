using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
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
        private const string WnsClientSecret = "EoQkPkNuYTM7znX+UAGRyyeG0eTGDFtH";
        private const string WnsPackageSid = "ms-app://s-1-15-2-1412280723-3910725469-679997538-3266902989-3194955833-4133533994-3874005050";
        private const string WnsPackageName = "TeacherMatchLLC.SmartFindMobile";

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

            if (rbAndroid.Checked)
            {
                var broker = new GcmServiceBroker(new GcmConfiguration(GcmSenderId, GcmSenderAuthToken, null));

                broker.OnNotificationFailed += BrokerOnOnNotificationFailed;
                broker.OnNotificationSucceeded += BrokerOnOnNotificationSucceeded;

                progressBar1.Value += 5;
                broker.Start();

                progressBar1.Value += 5;
                broker.QueueNotification(new GcmNotification
                {
                    RegistrationIds = new List<string> { txtDeviceToken.Text },
                    Data = JObject.Parse(JsonConvert.SerializeObject(new GcmNotificationPayload
                    {
                        Title = txtTitle.Text,
                        Message = txtMessage.Text,
                        Badge = txtBadge.Text,
                        JobId = int.Parse(txtJobId.Text),
                        UserId = int.Parse(txtUserId.Text)
                    }))
                });

                progressBar1.Value += 5;
                broker.Stop();
            }
            else if (rbiOS.Checked)
            {
                var certificateFilePath = Path.GetDirectoryName(Application.ExecutablePath) + ApnsCertificateFile;
                var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, certificateFilePath, ApnsCertificatePassword);
                var broker = new ApnsServiceBroker(config);

                broker.OnNotificationFailed += Broker_OnNotificationFailed;
                broker.OnNotificationSucceeded += Broker_OnNotificationSucceeded;

                progressBar1.Value += 5;
                broker.Start();

                progressBar1.Value += 5;
                broker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = txtDeviceToken.Text.Replace(" ", string.Empty),
                    Payload = JObject.Parse(JsonConvert.SerializeObject(new ApnsNotificationPayload
                    {
                        Aps = new Aps
                        {
                            Alert = new Alert
                            {
                                Body = txtMessage.Text,
                                Title = txtTitle.Text
                            },
                            Badge = int.Parse(txtBadge.Text)
                        },
                        JobId = int.Parse(txtJobId.Text),
                        UserId = int.Parse(txtUserId.Text)
                    }))
                });

                progressBar1.Value += 5;
                broker.Stop();
            }
            else if (rbWindows.Checked)
            {
                var notificationXMLString = @"<toast launch=''>
                                                  <visual lang='en-US'>
                                                    <binding template='ToastImageAndText01'>
                                                      <image id='1' src='World' />
                                                      <text id='1'>Hello</text>
                                                    </binding>
                                                  </visual>
                                                </toast>";
                //var config = new WnsConfiguration(WnsPackageName, WnsPackageSid, WnsClientSecret);
                //var broker = new WnsServiceBroker(config);

                //broker.OnNotificationSucceeded += BrokerOnOnNotificationSucceeded;
                //broker.OnNotificationFailed += BrokerOnOnNotificationFailed;

                //progressBar1.Value += 5;
                //broker.Start();

                //progressBar1.Value += 5;
                //broker.QueueNotification(new WnsToastNotification
                //{
                //    ChannelUri = txtDeviceToken.Text,
                //    Payload = XElement.Parse(notificationXMLString)
                //});

                //progressBar1.Value += 5;
                //broker.Stop();

                var ret = PostToWns(WnsClientSecret, WnsPackageSid, txtDeviceToken.Text, notificationXMLString, "Toast", "text/xml");
            }

            progressBar1.Value += 5;
            while (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            progressBar1.Value = 100;
        }

        private void BrokerOnOnNotificationSucceeded(WnsNotification notification)
        {
            Console.WriteLine(notification.ChannelUri, notification.Payload);
        }

        private void BrokerOnOnNotificationFailed(WnsNotification notification, AggregateException exception)
        {
            Console.WriteLine(notification.ChannelUri, notification.Payload);
            Console.WriteLine(exception.Message);
        }

        private void Broker_OnNotificationSucceeded(ApnsNotification notification)
        {
            Console.WriteLine(notification.DeviceToken, notification.Payload);
        }

        private void Broker_OnNotificationFailed(ApnsNotification notification, AggregateException exception)
        {
            Console.WriteLine(notification.DeviceToken, notification.Payload);
            Console.WriteLine(exception.Message);
        }

        private void BrokerOnOnNotificationSucceeded(GcmNotification notification)
        {
            Console.WriteLine(notification.RegistrationIds?.FirstOrDefault() ?? string.Empty, notification.Notification);
        }

        private void BrokerOnOnNotificationFailed(GcmNotification notification, AggregateException exception)
        {
            Console.WriteLine(notification.RegistrationIds?.FirstOrDefault() ?? string.Empty, notification.Notification);
            Console.WriteLine(exception.Message);
        }

        // Post to WNS
        public string PostToWns(string secret, string sid, string uri, string xml, string notificationType, string contentType)
        {
            try
            {
                // You should cache this access token.
                var accessToken = GetAccessToken(secret, sid);

                byte[] contentInBytes = Encoding.UTF8.GetBytes(xml);

                HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
                request.Method = "POST";
                request.Headers.Add("X-WNS-Type", notificationType);
                request.ContentType = contentType;
                request.Headers.Add("Authorization", String.Format("Bearer {0}", accessToken.AccessToken));

                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(contentInBytes, 0, contentInBytes.Length);

                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                    return webResponse.StatusCode.ToString();
            }

            catch (WebException webException)
            {
                HttpStatusCode status = ((HttpWebResponse)webException.Response).StatusCode;

                if (status == HttpStatusCode.Unauthorized)
                {
                    // The access token you presented has expired. Get a new one and then try sending
                    // your notification again.

                    // Because your cached access token expires after 24 hours, you can expect to get 
                    // this response from WNS at least once a day.

                    GetAccessToken(secret, sid);

                    // We recommend that you implement a maximum retry policy.
                    return PostToWns(uri, xml, secret, sid, notificationType, contentType);
                }
                else if (status == HttpStatusCode.Gone || status == HttpStatusCode.NotFound)
                {
                    // The channel URI is no longer valid.

                    // Remove this channel from your database to prevent further attempts
                    // to send notifications to it.

                    // The next time that this user launches your app, request a new WNS channel.
                    // Your app should detect that its channel has changed, which should trigger
                    // the app to send the new channel URI to your app server.

                    return "";
                }
                else if (status == HttpStatusCode.NotAcceptable)
                {
                    // This channel is being throttled by WNS.

                    // Implement a retry strategy that exponentially reduces the amount of
                    // notifications being sent in order to prevent being throttled again.

                    // Also, consider the scenarios that are causing your notifications to be throttled. 
                    // You will provide a richer user experience by limiting the notifications you send 
                    // to those that add true value.

                    return "";
                }
                else
                {
                    // WNS responded with a less common error. Log this error to assist in debugging.

                    // You can see a full list of WNS response codes here:
                    // http://msdn.microsoft.com/en-us/library/windows/apps/hh868245.aspx#wnsresponsecodes

                    string[] debugOutput = {
                                       status.ToString(),
                                       webException.Response.Headers["X-WNS-Debug-Trace"],
                                       webException.Response.Headers["X-WNS-Error-Description"],
                                       webException.Response.Headers["X-WNS-Msg-ID"],
                                       webException.Response.Headers["X-WNS-Status"]
                                   };
                    return string.Join(" | ", debugOutput);
                }
            }

            catch (Exception ex)
            {
                return "EXCEPTION: " + ex.Message;
            }
        }

        // Authorization
        [DataContract]
        public class OAuthToken
        {
            [DataMember(Name = "access_token")]
            public string AccessToken { get; set; }
            [DataMember(Name = "token_type")]
            public string TokenType { get; set; }
        }

        private OAuthToken GetOAuthTokenFromJson(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                var ser = new DataContractJsonSerializer(typeof(OAuthToken));
                var oAuthToken = (OAuthToken)ser.ReadObject(ms);
                return oAuthToken;
            }
        }

        protected OAuthToken GetAccessToken(string secret, string sid)
        {
            var urlEncodedSecret = WebUtility.UrlEncode(secret);
            var urlEncodedSid = WebUtility.UrlEncode(sid);

            var body = $"grant_type=client_credentials&client_id={urlEncodedSid}&client_secret={urlEncodedSecret}&scope=notify.windows.com";

            string response;
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                response = client.UploadString("https://login.live.com/accesstoken.srf", body);
            }
            return GetOAuthTokenFromJson(response);
        }
        
    }
}
