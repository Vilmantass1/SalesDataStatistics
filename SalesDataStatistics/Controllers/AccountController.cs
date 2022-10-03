using Microsoft.AspNetCore.Mvc;
using SalesDataStatistics.Data;
using SalesDataStatistics.Entities;
using SalesDataStatistics.Services.Contracts;

namespace SalesDataStatistics.Controllers
{
   
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IXMLReaderService _IXMLReaderService;

        public AccountController(DataContext context, IXMLReaderService IXMLReaderService)
        {

            _context = context;
            _IXMLReaderService = IXMLReaderService;
        }
        [HttpGet("migrate")]
        public async Task ReadDataAndMigratetoDB()
        {
             await _IXMLReaderService.ReadXmlFile();
            //await _IXMLReaderService.ScheduledReport();
     
        }


        [HttpGet("{receiptNumber}")]
        public async Task<ActionResult<Transaction>> GetReceiptData(int receiptNumber)
        {
            

            var Receipts = _context.Transactions.Where(x => x.ReceiptNumber == receiptNumber).FirstOrDefault();

            return Receipts;

        }


    }
}
