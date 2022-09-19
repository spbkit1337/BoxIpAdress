using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//мои юзынги

using System.Net; //нужна для получения инфы о ip
using System.Reflection.Emit;

namespace BoxIpAdress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 10000; //тут создаю интервал в секундах для того чтобы обновлялся label с надпесью "ip adress (внешний)"     10 секунд!!!!
            timer1.Start(); //включаю таймер при загрузки формы то есть программы
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "плиз вэйт :)";
            label4.Text = "плиз вэйт :)";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Обрати внимания что этот код находится в timer 1 чтобы  айпи адресс обновлялся каждые 10 сек проста для удобства

            //также нужно сказать что без using System.Net; работать не будет

            //Здесь я получаю локальный айпи адрес машины.

            string hostName = Dns.GetHostName(); // Retrive the Name of HOST

            // Get the IP
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            //Здесь я получаю локальный айпи адрес машины.
            label2.Text = myIP;



            //тут внешний который видят сайты которые я посещаю.Тут идет обращение к сайту icanhazip  с которого берется мой айпи
            string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            var externalIp = IPAddress.Parse(externalIpString);

            label4.Text = externalIp.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/spbkit1337");
        }
    }
}
