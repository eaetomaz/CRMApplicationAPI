using System.ComponentModel.DataAnnotations;

namespace CRMApplicationAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Empresa { get; set; }

        [Required]
        public string Status { get; set; } // "Ativo" ou "Inativo"

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Interacao> Interacoes { get; set; } = new List<Interacao>();
    }
}
