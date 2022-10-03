using SalesDataStatistics.Data;
using SalesDataStatistics.Entities;
using SalesDataStatistics.Services.Contracts;
using System.Xml;
using System.Threading;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SalesDataStatistics.Services
{
    public class XMLReaderService : IXMLReaderService
    {
        private readonly string XmlFileFolder = @"C:\Users\Vilmantas\source\repos\SalesDataStatistics\SalesDataStatistics\Receipts";
        private readonly DataContext _context;

        public XMLReaderService(DataContext context)
        {

            _context = context;
        }

        public string[] FindCsvFiles(string directory)
        {
            var xmlFilesInfo = new DirectoryInfo(directory).GetFiles("*.xml");
            var xmlFilesPath = new string[xmlFilesInfo.Length];
            for (int i = 0; i < xmlFilesInfo.Length; i++)
            {
                xmlFilesPath[i] = xmlFilesInfo[i].FullName;
            }
            return xmlFilesPath;
        }


        public async Task ReadXmlFile()
        {

            XmlDocument xmlDoc = new XmlDocument();

            var XMLpath = FindCsvFiles(XmlFileFolder);
            //var Transactions = new List<Transaction>();
            var Transaction = new Transaction();
            var counter = 1;    
            foreach (var file in XMLpath)
            {
                xmlDoc.Load(file);

                XmlNodeList SList = xmlDoc.GetElementsByTagName("SequenceNumber");
                XmlNodeList UList = xmlDoc.GetElementsByTagName("UnitID");
                XmlNodeList QList = xmlDoc.GetElementsByTagName("Quantity");
                XmlNodeList EList = xmlDoc.GetElementsByTagName("ExtendedAmount");
                XmlNodeList DList = xmlDoc.GetElementsByTagName("DateTime");



                for (int i = 0; i < 1; i++)
               {
                    //Transactions.Add(new Transaction
                    //{
                    //    Id = counter++,
                    //    ReceiptNumber = int.Parse(SList[i].InnerText.ToString()),
                    //    StoreID = int.Parse(UList[i].InnerText.ToString()),
                    //    TotalItems = decimal.Parse(QList[i].InnerText.ToString()),
                    //    TotalAmount = decimal.Parse(EList[i].InnerText.ToString()),
                    //});
                    Transaction.Id = counter++;
                    Transaction.ReceiptNumber = int.Parse(SList[i].InnerText.ToString());
                    Transaction.StoreID = int.Parse(UList[i].InnerText.ToString());
                    Transaction.TotalItems = decimal.Parse(QList[i].InnerText.ToString());
                    Transaction.TotalAmount = decimal.Parse(EList[i].InnerText.ToString());
                    Transaction.Date = DateTime.Parse(DList[i].InnerText.ToString());

                    _context.Transactions.Add(Transaction);
                   

                }
                  await _context.SaveChangesAsync();


            }
            
        }

       



   

    }
}
