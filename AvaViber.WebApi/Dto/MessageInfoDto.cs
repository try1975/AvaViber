using AvaViber.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AvaViber.WebApi.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageInfoDto
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public int ChatId { get; set; }
        /// <summary>
        /// Наименование чата
        /// </summary>
        public string ChatName { get; set; }
        /// <summary>
        /// Тип сообщения
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType MessageType { get; set; }
        /// <summary>
        /// Время сообщения UTC
        /// </summary>
        public long TimeStamp { get; set; }

        public string Body { get; set; }

        /// <summary>
        /// Ссылка на миниатюру
        /// </summary>
        public string ThumbnailLink { get; set; }

        /// <summary>
        /// Ссылка на содержимое
        /// </summary>
        public string PayloadLink { get; set; }
    }
}