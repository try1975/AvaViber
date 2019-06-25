namespace AvaViber.WebApi.Dto
{
    /// <summary>
    /// Информация о чате
    /// </summary>
    public class ChatInfoDto
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование чата
        /// </summary>
        public string Name { get; set; }
    }
}