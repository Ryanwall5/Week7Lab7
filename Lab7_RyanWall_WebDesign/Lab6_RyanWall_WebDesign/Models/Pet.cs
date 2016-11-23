using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Lab6_RyanWall_WebDesign.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Type of Animal")]
        public string TypeOfAnimal { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Type of food")]
        public string TypeOfFood { get; set; }

        public List<User> Users { get; set; }


    }
}