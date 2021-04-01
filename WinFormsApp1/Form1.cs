using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxEmail.Text == "" && tbxPassword.Text == "")
            {
                MessageBox.Show("Email and Password is Required.");
            }
            else if (tbxEmail.Text == "")
            {
                MessageBox.Show("Email is Required.");
            }
            else if (tbxPassword.Text == "")
            {
                MessageBox.Show("Password is Required.");
            }

            string baseUrl = "https://github.com";
            string loginUrl = "/login";
            string dataUrl = "https://github.com/settings/security-log";

            var uri = new Uri(baseUrl);

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = uri;

                var request = new { userName = tbxEmail.Text, password = tbxPassword.Text };
                var resLogin = client.PostAsJsonAsync(loginUrl, request).Result;

                var resData = client.GetAsync(dataUrl).Result;

                //var html = resSession.Content.ReadAsStringAsync().Result;

                //var doc = new HtmlDocument();
                //doc.LoadHtml(html);
            }

            //var TARGETURL = "https://github.com/settings/security-log";

            //HttpClient client = new HttpClient();

            //var authToken = Encoding.ASCII.GetBytes($"{tbxEmail.Text}:{tbxPassword.Text}");
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

            //HttpResponseMessage response = await client.GetAsync(TARGETURL);
            //HttpContent content = response.Content;

            //string result = await content.ReadAsStringAsync();

            //if (result != null)
            //{
            //    tbxDetails.Text = result;
            //}
        }
    }
}
