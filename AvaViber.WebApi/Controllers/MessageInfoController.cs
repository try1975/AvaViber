using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Http;
using AvaViber.Db.Entities;
using AvaViber.Db.Entities.QueryProcessors;
using AvaViber.WebApi.Dto;

namespace AvaViber.WebApi.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Получение сообщений вайбер
    /// </summary>
    [RoutePrefix("api/MessageInfo")]
    public class MessageInfoController : ApiController
    {
        private readonly IMessageInfoQuery _messageInfoQuery;

        /// <inheritdoc />
        public MessageInfoController(IMessageInfoQuery messageInfoQuery)
        {
            _messageInfoQuery = messageInfoQuery;
        }

        private static void FillMessages(IEnumerable<MessageInfoEntity> viberMessageEntities, string baseUrl, ICollection<MessageInfoDto> viberMessages)
        {
            foreach (var e in viberMessageEntities)
            {
                var messageInfoDto = new MessageInfoDto()
                {
                    Id = e.Id,
                    ChatId = e.ChatId,
                    ChatName = e.Chat.Name,
                    MessageType = e.MessageType,
                    TimeStamp = e.TimeStamp,
                    Body = e.Body
                };
                if (!string.IsNullOrWhiteSpace(e.ThumbnailPath))
                {
                    var filename = Path.GetFileName(e.ThumbnailPath);
                    if (!string.IsNullOrWhiteSpace(filename))
                    {
                        //messageInfoDto.ThumbnailLink = baseUrl + "?docPath=" + filename;
                        messageInfoDto.ThumbnailLink = baseUrl + filename;
                    }
                }

                if (!string.IsNullOrWhiteSpace(e.PayloadPath))
                {
                    var filename = Path.GetFileName(e.PayloadPath);
                    if (!string.IsNullOrWhiteSpace(filename))
                    {
                        messageInfoDto.PayloadLink = baseUrl + filename;
                    }
                }

                if (string.IsNullOrWhiteSpace(messageInfoDto.Body))
                {
                    if (!string.IsNullOrWhiteSpace(messageInfoDto.ThumbnailLink))
                        messageInfoDto.Body = messageInfoDto.ThumbnailLink;

                    if (!string.IsNullOrWhiteSpace(messageInfoDto.PayloadLink))
                        messageInfoDto.Body = messageInfoDto.PayloadLink;
                }

                viberMessages.Add(messageInfoDto);
            }
        }

        /// <summary>
        /// Сообщения из определенного чата в порядке убывания по времени
        /// </summary>
        /// <param name="chatId">Id чата</param>
        /// <param name="count">Количество возвращаемых записей, по умолчанию - последние 50</param>
        /// <returns></returns>
        [HttpGet]
        [Route("byChat")]
        public IEnumerable<MessageInfoDto> GetMessagesByChat(int chatId, int count = 50)
        {
            Logger.Log.Info($"GET {Request.Method} {Request.RequestUri}");
            try
            {
                var baseUrl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Files/";
                var viberMessages = new List<MessageInfoDto>();
                var viberMessageEntities = _messageInfoQuery.GetEntities()
                    .Where(z => z.ChatId == chatId)
                    .OrderByDescending(z => z.TimeStamp)
                    .Take(count)
                    .Include("Chat")
                    .ToList();

                FillMessages(viberMessageEntities, baseUrl, viberMessages);
                return viberMessages;
            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception);
                throw;
            }
            
        }

        /// <summary>
        /// Сообщения из всех чатов в порядке убывания по времени
        /// </summary>
        /// <param name="count">Количество возвращаемых записей, по умолчанию - последние 50</param>
        /// <returns></returns>
        [HttpGet]
        [Route("AllChat")]
        public IEnumerable<MessageInfoDto> GetAllChat(int count = 50)
        {
            Logger.Log.Info($"GET {Request.Method} {Request.RequestUri}");
            try
            {
                var baseUrl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Files/";
                var viberMessages = new List<MessageInfoDto>();
                var viberMessageEntities = _messageInfoQuery.GetEntities()
                    //.Where(z => z.Body  == null)
                    .OrderByDescending(z => z.TimeStamp)
                    .Take(count)
                    .Include("Chat")
                    .ToList();

                FillMessages(viberMessageEntities, baseUrl, viberMessages);
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
