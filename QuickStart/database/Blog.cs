using System.ComponentModel.DataAnnotations;

namespace database
{
    /// <summary>
    /// 博客
    /// </summary>
    public class Blog : Model
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Content { get; set; }

        public User Author { get; set; }

    }
}