﻿using System.ComponentModel.DataAnnotations;

namespace Db.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string CallingName { get; set; }

        public int PostHeight { get; set; }

        public int PostStartHeight { get; set; }

        public int PostWalkDistance { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public int DefaultPoints { get; set; }

        public Pictures[] Pictures { get; set; }

    }
}
