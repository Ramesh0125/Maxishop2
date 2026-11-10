using System.ComponentModel.DataAnnotations;

namespace Shan.Api.Model
{
    public class Category
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Place {  get; set; }


    }
}
