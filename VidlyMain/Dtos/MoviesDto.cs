﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMain.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
        public byte GenreId { get; set; }
    }
}