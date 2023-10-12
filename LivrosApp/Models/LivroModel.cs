using LivrosApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace LivrosApp.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do livro")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do Autor do livro")]
        public string? Autor { get; set; }
        [Required]
        public CategoriaEnum Categoria { get; set; }
        [Required]
        public DateOnly DataPublicacao { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
    }
}
