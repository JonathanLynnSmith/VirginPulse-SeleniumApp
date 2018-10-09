using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace VirginPulse.Helpers
{
    public class AccountInformation
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountInformation()
        {
            ValidateDataXML();
            Username = GetUsername();
            Password = GetPassword();
        }
        private void ValidateDataXML()
        {
            string dataXML = "./data.xml";
            bool xmlIsNotFound = !(File.Exists(dataXML));
            if (xmlIsNotFound)
            {
                Console.WriteLine("Missing Account File");
                RequestAccountInformation();
            }

            bool missingInformation = string.IsNullOrEmpty(GetUsername()) || string.IsNullOrEmpty(GetUsername());
            if (missingInformation)
            {
                Console.WriteLine("Missing Account Information");
                RequestAccountInformation();
            }           
        }
        public void RequestAccountInformation()
        {
            Console.Write("Username: ");
            string newUsername = Console.ReadLine();
            Console.Write("Password: ");
            string newPassword = Console.ReadLine();
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                Console.WriteLine("Missing Username or Password");
                RequestAccountInformation();
            }
            else
            {
                CreateXMLDocument(newUsername, newPassword);
            }

            void CreateXMLDocument(string username, string password)
            {
                using (XmlWriter writer = XmlWriter.Create("./data.xml"))
                {
                    writer.WriteStartElement("account");
                    writer.WriteElementString("username", username);
                    writer.WriteElementString("password", password);
                    writer.Flush();
                }
            }
        }
        private string GetUsername()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./data.xml");
            var node = doc.DocumentElement.SelectSingleNode("/account/username").InnerText;
            return node.ToString();
        }
        private string GetPassword()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./data.xml");
            var node = doc.DocumentElement.SelectSingleNode("/account/password").InnerText;
            return node.ToString();
        }
    }
}
