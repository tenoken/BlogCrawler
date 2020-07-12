using BlogCrawler.Class;
using BlogCrawler.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BlogCrawler.Driver
{
    public class CommentService : ICommentService
    {
        private const string clickScript = "arguments[0].click();";

        private readonly List<string> _firstNames = new List<string>
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
                    "Camila",
                    "Jessica",
                    "Leticia",
                    "Amanda",
                    "Lucas",
                    "Luiz",
                    "Mateus",
                    "Guilherme",
                    "Pedro"
                };

        private readonly List<string> _lastNames = new List<string>
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

        private readonly List<string> _emailSufixes = new List<string>
                {
                    "hotmail.com",
                    "gmail.com",
                    "outlook.com",
                    "yahoo.com"
                };

        private readonly List<string> _comments = new List<string>
                {
                    "Incrivel!",
                    "Muito interessante",
                    "Nem imaginava que isso existia, ainda mais no Japao",
                    "Interessante...",
                    "Como pode ser possivel...simplesmente perfeito"
                };

        private Random random = new Random();

        private readonly IComment _comment;

        private ChromeDriver driver { get; set; }

        public CommentService(IComment comment)
        {
            _comment = comment;
        }

        /// <summary>
        /// Post a comment for all articles in the page
        /// </summary>
        /// <param name="articlesIdList">article's ids</param>
        /// <param name="articlesList">list of article to be commented</param>
        /// <param name="url">URL to be crawled. Must be the same of the articles list</param>
        public void PostComment(List<string> articlesIdList, List<Article> articlesList, string url)
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            CreateComment(articlesIdList, articlesList);

            driver.Navigate().Back();
            driver.Dispose();
        }

        /// <summary>
        /// Post a comment list for each article
        /// </summary>
        /// <param name="idList">article's id list</param>
        /// <param name="articlesList">article list that contais comments to be posted</param>
        private void CreateComment(List<string> idList, List<Article> articlesList)
        {

            int index = 0;

            foreach (var id in idList)
            {

                // Waits for the document load successfuly
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));

                var article = driver.FindElementById(id);
                article = article.FindElement(By.ClassName("readmore"));
                driver.ExecuteScript(clickScript, article);           

                // Waits for the document load successfuly
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("comment")));
                var commentLocation = driver.FindElementById("comment");

                var comments = articlesList[index].CommentsList;                

                foreach (var cmt in comments)
                {

                    FillPostFields(cmt, commentLocation);

                }

                // Uncomment the line bellow to post the created comment
                //SubmitComment();

                driver.Navigate().Back();
                index++;
            }
        }

        /// <summary>
        /// Create 20 random comments
        /// </summary>
        /// <returns>A list of Comments</returns>
        public List<Comment> CreateRandomComments()
        {
            random = new Random();
            List<Comment> commentsList = new List<Comment>();
            string firstName, lastName, emailNumber, emailSufix, commentText;

            for (int i = 0; i < 20; i++)
            {
                var firstNameIndex = random.Next(_firstNames.Count);
                var lastNameIndex = random.Next(_lastNames.Count);
                var commentIndex = random.Next(_comments.Count);
                var indedxEmail = random.Next(_emailSufixes.Count);

                firstName = _firstNames.ToArray().GetValue(firstNameIndex).ToString();
                lastName = _lastNames.ToArray().GetValue(lastNameIndex).ToString();
                commentText = _comments.ToArray().GetValue(commentIndex).ToString();
                emailNumber = random.Next(1000, 9999).ToString();
                emailSufix = _emailSufixes.ToArray().GetValue(indedxEmail).ToString();

                Comment objComment = _comment.CreateComment(firstName, lastName, emailNumber, emailSufix, commentText);

                commentsList.Add(objComment);
            };

            return commentsList;
        }

        /// <summary>
        /// Fills de required fields to post a comment
        /// </summary>
        /// <param name="comment">Comment to be posted</param>
        /// <param name="commentElement">Textarea element to be commented</param>
        private void FillPostFields(Comment comment, IWebElement commentElement)
        {
            var author = driver.FindElementById("author");
            author.SendKeys(FormatAuthor(comment));

            var emailLocation = driver.FindElementById("email");
            emailLocation.SendKeys(FormatEmail(comment));

            commentElement.SendKeys(GetComment(comment));     
        }

        /// <summary>
        /// Format the author name
        /// </summary>
        /// <param name="comment">Comment to be formated</param>
        /// <returns>Formated author name, with initals letters to upper. Example: John Smith</returns>
        private string FormatAuthor(Comment comment)
        {
            return _comment.FormatAuthor(comment);
        }

        /// <summary>
        /// Format email for the user that commented
        /// </summary>
        /// <param name="comment">Comment to be formated</param>
        /// <returns>Formated email. Example: fistnamelastname1234@domain.com</returns>
        private string FormatEmail(Comment comment)
        {
            return _comment.FormatEmail(comment);
        }

        /// <summary>
        /// Get comment text
        /// </summary>
        /// <param name="comment">Comment wich has comment text value</param>
        /// <returns>The comment text</returns>
        private string GetComment(Comment comment)
        {
            return _comment.GetComment(comment);
        }

        /// <summary>
        /// Action to post a comment
        /// </summary>
        private void SubmitComment()
        {
            var submit = driver.FindElementById("submit");
            submit.Click();
            driver.ExecuteScript(clickScript, submit);
        }
    }
}
