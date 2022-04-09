using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class RecipeBis
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Time { get; set; }
        public string Difficulty { get; set; }
        public int Numberoflikes { get; set; }

        public string Ingredients { get; set; }
    }
}
