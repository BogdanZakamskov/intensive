using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool send = false;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime dd = DateTime.Now;
            if (dd.Hour == 10 && dd.Minute == 19 && send == false)
            {
                // настройки smtp-сервера, с которого мы и будем отправлять письмо
                SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("nim20101@yandex.ru", "madama98");

                // наш email с заголовком письма
                MailAddress from = new MailAddress("nim20101@yandex.ru", "Test");
                // кому отправляем
                MailAddress to = new MailAddress("nim20101@yandex.ru");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Test mail";
                // текст письма
                m.Body = "Рассылка сайта";
                smtp.Send(m);
                send = true;
            }
        }
    }
}
