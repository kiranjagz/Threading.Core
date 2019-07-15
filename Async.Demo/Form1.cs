using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBlock_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                var fact = FactGet(i, "math");
                MessageBox.Show(fact);
            }
        }

        public string FactGet(int number, string type)
        {
            var url = $"http://numbersapi.com/" + number + "/" + type + "?json";
            String path = @"c:\test.txt";
            using (var client = new HttpClient())
            {
                var response = client.GetByteArrayAsync(url).Result;
                var responseString = Encoding.UTF8.GetString(response);
                if (!string.IsNullOrWhiteSpace(responseString))
                {
                    using (var streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine(responseString);
                    };

                    return responseString;


                }
            }
            return null;
        }

        private async void BtnAsync_ClickAsync(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                var fact = await FactGetAsync(i, "trivia");
                await Task.Run(() =>
                 {
                     MessageBox.Show(fact);
                 });
              
            }
        }

        public async Task<string> FactGetAsync(int number, string type)
        {
            var url = $"http://numbersapi.com/" + number + "/" + type + "?json";
            String path = @"c:\testAsync.txt";
            using (var client = new HttpClient())
            {
                var response = await client.GetByteArrayAsync(url);
                var responseString = Encoding.UTF8.GetString(response);
                if (!string.IsNullOrWhiteSpace(responseString))
                {
                    using (var streamWriter = new StreamWriter(path, true))
                    {
                        await streamWriter.WriteLineAsync(responseString);
                    };

                    return responseString;


                }
            }
            return null;
        }
    }
}
