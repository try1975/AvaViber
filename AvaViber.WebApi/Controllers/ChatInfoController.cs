using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AvaViber.Db.Entities.QueryProcessors;
using AvaViber.WebApi.Dto;

namespace AvaViber.WebApi.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Информация о чатах вайбер
    /// </summary>
    [RoutePrefix("api/ChatInfo")]
    public class ChatInfoController : ApiController
    {

        private readonly IChatInfoQuery _chatInfoQuery;

        /// <inheritdoc />
        public ChatInfoController(IChatInfoQuery chatInfoQuery)
        {
            _chatInfoQuery = chatInfoQuery ?? throw new ArgumentNullException(nameof(chatInfoQuery));
        }

        /// <summary>
        /// Получить список чатов
        /// </summary>
        /// <param name="count">Количество возвращаемых записей, по умолчанию - 50</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<ChatInfoDto> GetChats(int count = 50)
        {
            Logger.Log.Info($"GET {Request.Method} {Request.RequestUri}");
            try
            {
                var viberChats = new List<ChatInfoDto>();
                var chatInfoEntities = _chatInfoQuery.GetEntities()
                    .Take(count)
                    .ToList();

                foreach (var chatInfoEntity in chatInfoEntities)
                {
                    var viberChat = new ChatInfoDto
                    {
                        Id = chatInfoEntity.Id,
                        Name = chatInfoEntity.Name
                    };
                    viberChats.Add(viberChat);
                }
                return viberChats;
            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception);
                throw;
            }

        }
    }
}
