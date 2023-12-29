using System;
using System.ComponentModel.DataAnnotations;

namespace biblioteca{

    public class Livro
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Autor { get; set;}
        [Required]
        public string? Categoria { get; set; }
        public  Editora? Editora ;
    }
}