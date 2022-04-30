using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMailDal : IMailDal
    {
        public void SendMail(SendMailDto sendMailDto)
        {
           using(MailMessage mail =new MailMessage())
            {
                mail.From=new MailAddress(sendMailDto.mailParameters.EMail);
                mail.To.Add(sendMailDto.email);
                mail.Subject=sendMailDto.subject;
                mail.Body=sendMailDto.body;
                mail.IsBodyHtml=true;

                using(SmtpClient smtp = new SmtpClient(sendMailDto.mailParameters.SMTP))
                {
                    smtp.UseDefaultCredentials=false;
                    smtp.Credentials = new NetworkCredential(sendMailDto.mailParameters.EMail,sendMailDto.mailParameters.Password);
                    smtp.EnableSsl = sendMailDto.mailParameters.SSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
