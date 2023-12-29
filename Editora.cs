using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace biblioteca {

    public class Editora
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? NomeEditora { get; set; }
    }


}