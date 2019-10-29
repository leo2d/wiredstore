using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Models.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        public string ReleaseYear { get; set; }
        public List<Image> Images { get; set; }

        public string Genre { get; set; }
    }
}
