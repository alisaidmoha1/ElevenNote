using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Categories
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="You have exceeded the limit for this field")]
        public string Name { get; set; }
    }
}
