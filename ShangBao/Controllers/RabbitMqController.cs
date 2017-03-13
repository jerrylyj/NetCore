using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShangBao.Common;

namespace ShangBao.Controllers
{
    [Produces("application/json")]
    [Route("api/RabbitMq")]
    public class RabbitMqController : Controller
    {
        [HttpPost]
        [HttpPost, Route("test")]
        public void test()
        {
            RabbitSender rs = new RabbitSender();
            rs.SendForWork("Test");
        }
    }
}