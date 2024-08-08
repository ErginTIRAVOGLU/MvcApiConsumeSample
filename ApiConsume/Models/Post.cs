using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiConsume.Models
{
    public class Post
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [JsonPropertyName("body")]
        [Display(Name ="İçerik")]
        public string Body { get; set; }

    }

    public class PostDeleteDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
