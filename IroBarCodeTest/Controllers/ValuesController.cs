using IronBarCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IroBarCodeTest.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                BarcodeResult[] results = null;

                results = BarcodeReader.ReadBarcodesFromPdf(@"C:\\Users\\hudso\\source\\repos\\IroBarCodeTest\\IroBarCodeTest\\teste1.pdf", BarcodeEncoding.All, BarcodeReader.BarcodeRotationCorrection.Low, BarcodeReader.BarcodeImageCorrection.CleanNonBlackPixels);
                
                return Ok(results);

            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error");
            }
        }
    }
}
