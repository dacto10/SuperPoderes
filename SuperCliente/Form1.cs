using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperCliente.SuperPoderesService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using SuperAPI.Clases;

namespace SuperCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            //soap
            //var client = new CargarSuperPoderesClient();
            //var response = await client.updateSuperPoderesAsync();
            //messageLabel.Text = response.Message;

            //rest
            HttpClient client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44347/api/person/", new StringContent(""));
            var content = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ResponseMessageSchema>(content);
            messageLabel.Text = data.message;
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            var text = dropdown.Text;
            if (text != "")
            {
                //soap
                //var client = new CargarSuperPoderesClient();
                //var request = new ObtenerSuperPoderesRequest();
                //request.Tipo = text;
                //var response = await client.getSuperPoderesAsync(request);
                //messageLabel.Text = response.Message;
                //listBox.Items.AddRange(response.Personas.ToArray<string>());

                //rest
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://localhost:44347/api/person/" + text);
                var content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ResponseValuesSchema<Person>>(content);
                messageLabel.Text = data.message;
                listBox.Items.AddRange(data.values.Select(person => person.name).ToArray());
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            var text = dropdown.Text;
            if (text != "")
            {
                //rest
                HttpClient client = new HttpClient();
                var response = await client.DeleteAsync("https://localhost:44347/api/person/" + text);
                var content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ResponseMessageSchema>(content);
                messageLabel.Text = data.message;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (input.Text != "")
            {
                var xd = new Person(input.Text, false);
                var json = JsonConvert.SerializeObject(xd);
                var req = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var response = await client.PutAsync("https://localhost:44347/api/person/", req);
                var content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ResponseValuesSchema<Person>>(content);
                messageLabel.Text = data.message;
                listBox.Items.AddRange(data.values.Select(person => person.name).ToArray());
            }
        }
    }
}
