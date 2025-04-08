using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRMApplicationAPI.Models
{
    [Table("CLIENTES")]
    public class Clientes
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Column("NOME")]
        public string Nome { get; set; }

        [EmailAddress, StringLength(100)]
        [Column("EMAIL")]
        public string Email { get; set; }

        [StringLength(20)]
        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [StringLength(100)]
        [Column("EMPRESA")]
        public string Empresa { get; set; }

        [Required]
        [Column("STATUS")]
        public string Status { get; set; }

        [Column("DATACADASTRO")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Interacao> Interacoes { get; set; } = new List<Interacao>();
    }
}
