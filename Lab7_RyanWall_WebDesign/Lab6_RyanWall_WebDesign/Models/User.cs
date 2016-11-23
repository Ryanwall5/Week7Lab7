using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab6_RyanWall_WebDesign.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Nickname for yourself")]
        public string NickName { get; set; }

        [Required]
        [Display(Name = "House Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Favorite NBA Team Examples: Blazers, Warriors, etc")]
        public string FavoriteNBATeam{ get; set; }

        [Required]
        [Display(Name = "Do you play video games?")]
        public bool DoYouPlayVG { get; set; }

        public List<Pet> Pets { get; set; }

        [NotMapped]
        public bool Cool { get; set; }

    }
}