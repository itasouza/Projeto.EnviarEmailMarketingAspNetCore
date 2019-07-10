using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace EnviarEmailMarketingAspNetCore.Controllers
{
    public class HomeController : Controller
    {

        //https://stackify.com/net-core-loggerfactory-use-correctly/

        public IActionResult Index()
        {
            //   _logger.LogInformation("Action Index :: HomeController -> executou leitura do arquivo  " + DateTime.Now.ToLongTimeString());
            leituraArquivo();
            return View();
        }



        public void leituraArquivo()
        {

            //string nome = "Itamar P. Souza";
            //string email = "itasouza@yahoo.com.br";
            //string endereco = "www.sitexemplo.com.br/5454545445";
            //var BaseArquivo = ConfigurationManager.AppSettings["CaminhoModeloEmail"] + "index.html";
            //string Mensagem = System.IO.File.ReadAllText(BaseArquivo, Encoding.UTF8);
            //Mensagem = Mensagem.Replace("##NOME##", nome);
            //Mensagem = Mensagem.Replace("##ENDERECO##", endereco);
            //Email(Mensagem, nome, email);


            //string nome = "Lucas Silva";
            //string email = "lucas.silva@imperio.com.br";
            //string endereco = "www.sitexemplo.com.br/5454545445";
            //var BaseArquivo = ConfigurationManager.AppSettings["CaminhoModeloEmail"] + "index.html";
            //string Mensagem = System.IO.File.ReadAllText(BaseArquivo, Encoding.UTF8);
            //Mensagem = Mensagem.Replace("##NOME##", nome);
            //Mensagem = Mensagem.Replace("##ENDERECO##", endereco);
            //Email(Mensagem, nome, email);


            //string nome = "Paulo Lopes";
            //string email = "paulo.lopes-ext@imperio.com.br";
            //string endereco = "www.sitexemplo.com.br/5454545445";
            //var BaseArquivo = ConfigurationManager.AppSettings["CaminhoModeloEmail"] + "index.html";
            //string Mensagem = System.IO.File.ReadAllText(BaseArquivo, Encoding.UTF8);
            //Mensagem = Mensagem.Replace("##NOME##", nome);
            //Mensagem = Mensagem.Replace("##ENDERECO##", endereco);
            //Email(Mensagem, nome, email);


            //string nome = "Itamar Pedreira";
            //string email = "itamar.pedreira-ext@imperio.com.br";
            //string endereco = "www.sitexemplo.com.br/5454545445";
            //var BaseArquivo = ConfigurationManager.AppSettings["CaminhoModeloEmail"] + "index.html";
            //string Mensagem = System.IO.File.ReadAllText(BaseArquivo, Encoding.UTF8);
            //Mensagem = Mensagem.Replace("##NOME##", nome);
            //Mensagem = Mensagem.Replace("##ENDERECO##", endereco);
            //Email(Mensagem, nome, email);

            
        }




        public IActionResult Email(string mensagem, string nome, string email)
        {
           // _logger.LogInformation("Action Email :: HomeController -> Enviando o e-mail  " + DateTime.Now.ToLongTimeString());

            string recnome = nome;
            string recemail = email;
            string recmensagem = mensagem;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("itamarcontatosuporte@gmail.com", "");
            //client.Credentials = new System.Net.NetworkCredential("itamar.pedreira-ext@imperio.com.br", "");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("itamarcontatosuporte@gmail.com", "ENVIADOR");
            mail.From = new MailAddress(email, "Alertas On-Line");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Sistema de alerta de erro de integração";
            mail.Body = recmensagem;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception )
            {
             //   _logger.LogError("Action Email :: HomeController -> Ocorreram problemas no envio do e-mail  " + ex.Message + DateTime.Now.ToLongTimeString());
            }
            finally
            {
              //  _logger.LogInformation("Action Email :: HomeController -> email enviado com sucesso  " + DateTime.Now.ToLongTimeString());
                mail = null;
            }

            return View();
        }


    }
}

