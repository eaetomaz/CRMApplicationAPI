using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRMApplicationAPI.Models
{
    public class Interacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required, StringLength(50)]
        public string Tipo { get; set; } // "E-mail", "Reunião", "Ligação"

        public string Descricao { get; set; }

        public DateTime DataInteracao { get; set; } = DateTime.Now;

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}
