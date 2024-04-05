using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZioMVC.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Nick { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }
        public List<Question>? Questions { get; set; }
        [NotMapped]
        public List<int>? SelectedAnswers { get; set; }
    }
}
