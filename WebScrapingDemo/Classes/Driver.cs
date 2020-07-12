using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapingDemo.Classes
{
    class Driver
    {
        private static Random random = new Random();
        private static string NomeJanelaNavegador = string.Empty;
        private static ChromeDriver driver { get; set; }

        public static void AddComment(List<string> articleList, string URL)
        {
            //if (driver == null)
            //{
            //    driver = new ChromeDriver();

            //}

            driver = new ChromeDriver();
            //**
            //foreach (Process proc in Process.GetProcessesByName("chrome"))
            //{
            //    proc.Kill();
            //}
            //if (string.IsNullOrEmpty(NomeJanelaNavegador))
            //{
            //    driver.Navigate().GoToUrl("https://www.japaoemfoco.com");
            //}

            driver.Navigate().GoToUrl(URL);

            Process[] updatedInfopathProcessList = Process.GetProcessesByName("chrome");
            //if (updatedInfopathProcessList[0].Id == 0)
            //{
            //    throw new ApplicationException("No Infopath processes exist");
            //}
            //var infopathProcessId = updatedInfopathProcessList[0].Id;
            //var infopathHwnd = updatedInfopathProcessList[0].MainWindowHandle;
            //**

            NomeJanelaNavegador = driver.WindowHandles.FirstOrDefault();

            driver.SwitchTo().Window(NomeJanelaNavegador);

            List<string> idArticles = articleList;
                //{
                //    "post-81119",
                //    "post-81039",
                //    "post-80897",
                //    "post-81072",
                //    "post-80960"
                //};

            List<string> Nomes = new List<string>
                {
                    "Adriana",
                    "Ana",
                    "Maria",
                    "Sandra",
                    "Juliana",
                    "Antonio",
                    "Carlos",
                    "Francisco",
                    "Joao",
                    "Jose",
                    "Bruna",
                    "Camila ",
                    "Jessica",
                    "Leticia",
                    "Amanda",
                    "Lucas ",
                    "Luiz",
                    "Mateus",
                    "Guilherme",
                    "Pedro"
                };

            List<string> Sobrenome = new List<string>
                {
                    "ANDRADE",
                    "BARBOSA",
                    "BARROS",
                    "BATISTA",
                    "BORGES",
                    "CAMPOS",
                    "CARDOSO",
                    "CARVALHO",
                    "CASTRO",
                    "COSTA",
                    "DIAS",
                    "DUARTE ",
                    "FREITAS",
                    "FERNANDES",
                    "FERREIRA",
                    "GARCIA ",
                    "GOMES",
                    "GONÇALVES",
                    "LIMA",
                    "LOPES",
                    "MACHADO",
                    "MARQUES",
                    "MARTINS",
                    "MEDEIROS",
                    "MELO",
                    "MENDES",
                    "MIRANDA",
                    "MONTEIRO",
                    "MORAES",
                    "MOREIRA",
                    "MOURA",
                    "NASCIMENTO ",
                    "NUNES",
                    "PEREIRA",
                    "RAMOS",
                    "REIS ",
                    "RIBEIRO",
                    "ROCHA",
                    "RODRIGUES",
                    "SANTANA"
                };

            List<string> Emails = new List<string>
                {
                    "hotmail.com",
                    "gmail.com",
                    "outlook.com",
                    "yahoo.com"
                };


            foreach (var id in idArticles)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));

                //driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromMilliseconds(10000));
                var article = driver.FindElementById(id);
                article = article.FindElement(By.ClassName("readmore"));

                driver.ExecuteScript("arguments[0].click();", article);
                //WebDriverWait.Until<Action>(driver.ExecuteScript("arguments[0].click();", article));

                //driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromMilliseconds(5000));
                var indexNome = random.Next(Nomes.Count);
                var indexSobrenome = random.Next(Sobrenome.Count);

                var nome = Nomes.ToArray().GetValue(indexNome);
                var sobrenome = Sobrenome.ToArray().GetValue(indexSobrenome);

                int numeroEmail = random.Next(1000, 9999);
                int indedxEmail = random.Next(Emails.Count);

                var tipoEmail = Emails.ToArray().GetValue(indedxEmail);

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("comment")));
                var comment = driver.FindElementById("comment");
                comment.SendKeys("Nem imagina que isso existia, ainda mais no Japao.");



                var author = driver.FindElementById("author");
                author.SendKeys(nome.ToString() + " " + string.Format("{0}{1}", sobrenome.ToString().Substring(0)[0].ToString().ToUpper(), sobrenome.ToString().Substring(1).ToLower()));

                var email = driver.FindElementById("email");
                email.SendKeys(nome.ToString().ToLower() + "." + sobrenome.ToString().ToLower() + numeroEmail.ToString() + "@" + tipoEmail.ToString());

                //var submit = driver.FindElementById("submit");
                //submit.Click();
                //driver.ExecuteScript("arguments[0].click();", submit);

                driver.Navigate().Back();
                //}

                driver.Dispose();
            }
        }
    }
}
