using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CinemaTown.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required.")]
        [StringLength(50)]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please choose a genre.")]

        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        [Display(Name ="Release Date")]
        [Required(ErrorMessage = "Release Year is Required.")]
        public DateTime? ReleaseYear { get; set; }
        [Required(ErrorMessage = "Description is Required.")]
        public string Description { get; set; }
        [Display(Name = "Date Added")]
        [Required(ErrorMessage = "Date Added is Required.")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "In Stock")]
        [Required]
        [Range(1,20,ErrorMessage ="Value must be between 1 and 20.")]
        public int InStock { get; set; }
    }
}