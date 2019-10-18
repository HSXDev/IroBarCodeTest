using IronOcr;
using IronOcr.Languages;
using System;
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
                var Ocr = new AdvancedOcr()
                {
                    CleanBackgroundNoise = true,
                    ColorDepth = 4,
                    ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                    EnhanceContrast = true,
                    DetectWhiteTextOnDarkBackgrounds = true,
                    RotateAndStraighten = true,
                    Language = IronOcr.Languages.English.OcrLanguagePack,
                    EnhanceResolution = false,
                    InputImageType = AdvancedOcr.InputTypes.Document,
                    ReadBarCodes = true,
                    Strategy = AdvancedOcr.OcrStrategy.Advanced
                };
                
                var Results = Ocr.ReadPdf(@"C:\\Users\\hudso\\source\\repos\\IroBarCodeTest\\IroBarCodeTest\\teste2.pdf");
                var Pages = Results.Pages;
                var Barcodes = Results.Barcodes;
                var FullPdfText = Results.Text;
                
                return Ok(Barcodes);

            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error");
            }
        }
    }
}
