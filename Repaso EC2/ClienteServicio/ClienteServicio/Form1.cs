using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteServicio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:1256/api/Empleado?DNI=" + txtDni.Text;
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string resultado = await cliente.GetStringAsync(url);

            Empleado empleado = Newtonsoft.Json.JsonConvert.DeserializeObject<Empleado>(resultado);
            txtNombre.Text = empleado.nombre;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.DNI = txtDni.Text;
            empleado.nombre = txtNombre.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Ubicacion = txtUbigeo.Text;
            if(rdbMasculino.Checked)
            {
                empleado.Genero="M";
            }
            else
            {
                empleado.Genero = "F";
            }
            empleado.FecNac = dtpFechaNacimiento.Value;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(empleado);
            HttpClient cliente = new HttpClient();
            string url = "http://localhost:1256/api/Empleado";

            var resultado = await cliente.PostAsync(url, new StringContent(json,System.Text.Encoding.UTF8,"application/json"));

        }

        public async Task<HttpResponseMessage> obtenerEmpleados()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1256/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await client.GetAsync("api/Empleado/");
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            HttpResponseMessage response = await obtenerEmpleados();

            if (response.IsSuccessStatusCode)
            {
                String responseContent = await response.Content.ReadAsStringAsync();
                List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(responseContent);
               
                foreach(Empleado emp in empleados)
                {
                    lbEmpleados.Items.Add(emp.DNI +" - "+emp.nombre);
                }
            }
        }
    }
}
