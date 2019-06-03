using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using SqLiteTest;

namespace AvaViber.WebApi.Controllers
{
    [RoutePrefix("api/MessageInfo")]
    public class MessageInfoController : ApiController
    {
        private readonly Model1 _db;
        
        public MessageInfoController()
        {
            _db = new Model1();
        }

        [HttpGet]
        [Route("byChat")]
        public IEnumerable<MessageInfoEntity> GetMessagesByChat(int chatId)
        {
            
            var viberMessages = _db.MessageInfo
                .Where(z => z.ChatId == chatId)
                .OrderByDescending(z => z.TimeStamp)
                .Take(20)
                .ToList();
            return viberMessages;
        }

    }
}
