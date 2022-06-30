using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using DocGenerator.Certificate.Models;
using System.Threading.Tasks;
using DocGenerator.ClientDLL;
using DocGenerator.ClientDLL.Models;
using System.Net.Http;

namespace DocGenerator.Certificate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificateController : ControllerBase
    {
        [HttpPost]
        public string Post()
        {
            RequestDocGenerator requestDocGenerator = new RequestDocGenerator();
            HttpResponseMessage response =  requestDocGenerator.postDocument(
                new List<DocumentInfo>(){ 
                new DocumentInfo() { keyInFile="NameFull",value="Teste"}
                },
                Resource.Certificate
            );
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
