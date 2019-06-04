using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AvaViber.Db.Entities;
using AvaViber.Db.Entities.QueryProcessors;

namespace AvaViber.WebApi.Controllers
{
    [RoutePrefix("api/MessageInfo")]
    public class MessageInfoController : ApiController
    {
        private readonly IMessageInfoQuery _messageInfoQuery;

        public MessageInfoController(IMessageInfoQuery messageInfoQuery)
        {
            _messageInfoQuery = messageInfoQuery;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId">Id чата</param>
        /// <param name="count">Количество возвращаемых записей, по умолчанию - последние 50</param>
        /// <returns></returns>
        [HttpGet]
        [Route("byChat")]
        public IEnumerable<MessageInfoEntity> GetMessagesByChat(int chatId, int count = 50)
        {
            Logger.Log.Info($"GET {Request.Method} {Request.RequestUri}");
            try
            {
                var viberMessages = _messageInfoQuery.GetEntities()
                    .Where(z => z.ChatId == chatId)
                    .OrderByDescending(z => z.TimeStamp)
                    .Take(count)
                    .ToList();
                return viberMessages;
            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception);
                throw;
            }
            
        }

        [HttpGet]
        [Route("AllChat")]
        public IEnumerable<MessageInfoEntity> GetMessagesByChat(int count = 50)
        {
            Logger.Log.Info($"GET {Request.Method} {Request.RequestUri}");
            try
            {
                var viberMessages = _messageInfoQuery.GetEntities()
                    .OrderByDescending(z => z.TimeStamp)
                    .Take(count)
                    .ToList();
                return viberMessages;
            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception);
                throw;
            }
            
        }

    }
}
