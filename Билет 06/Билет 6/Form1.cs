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
using System.Net.Mail;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Билет_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task Send_email()
        {
            string[] lines = File.ReadAllLines("email.txt");
            List<string[]> em = new List<string[]>();
            foreach (string line in lines)
            {
                string[] ln = line.Split(';');
                em.Add(ln);
            }

            foreach (string[] ll in em)
            {
                string smtpServer = "smtp.mail.ru";
                int smtpPort = 587;
                string senderEmail = "a.ploskikh@list.ru";
                string senderPassword = "dRusv8QTzTAkxHWLZBMp";

                // Создание сообщения
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(ll[0]);
                mail.Subject = "Проверка";
                mail.Body = ll[1];

                // Настройка SMTP-клиента
                SmtpClient smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 10000
                };

                // Асинхронная отправка письма
                await smtpClient.SendMailAsync(mail);
            }
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Send_email();
        }
    }
}
