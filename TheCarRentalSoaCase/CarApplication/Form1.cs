using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CarApplication.CarService;

namespace CarApplication
{
    public partial class Form1 : Form
    {
        readonly CarManagementClient _client;
        public Form1()
        {
            InitializeComponent();
            _client = new CarManagementClient();

        }

        private void btn_listcar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Car> listCars = _client.ListCars();

                foreach (Car car in listCars)
                {
                    listBox1.Items.Add(car.BrandName + " " + car.TypeName);
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void btn_insertNewCar_Click(object sender, EventArgs e)
        {

            try
            {
                Car car = new Car { BrandName = "BMW", TypeName = "320d" };
                int newCarId;
                newCarId = _client.InsertNewcar(car);
                listBox1.Items.Add(newCarId);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }

        }

        private void btn_getcarPicture_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buff = _client.GetCarPicture("C67872");
                var typeConverter = TypeDescriptor.GetConverter(typeof(Bitmap));
                var bitmap = (Bitmap)typeConverter.ConvertFrom(buff);
                pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }

        }
    }
}
