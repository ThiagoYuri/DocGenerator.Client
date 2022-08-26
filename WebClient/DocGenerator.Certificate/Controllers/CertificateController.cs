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
        public string Post(string nameCourse, string nameFullUser)
        {
            RequestDocGenerator requestDocGenerator = new RequestDocGenerator();
            HttpResponseMessage response =  requestDocGenerator.postDocument(
                new List<DocumentInfo>(){ 
                new DocumentInfo() { keyInFile="NAMEFULL",value=nameFullUser},
                new DocumentInfo() { keyInFile="COURSENAME",value=nameCourse },
                new DocumentInfo() { keyInFile="DATEEMISS", value=DateTime.Now.ToString("dd/MM/yyyy") }
                },
                Resource.Certificate
            );
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
