using System.ComponentModel.DataAnnotations;

namespace ControleProdutos.Models
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "O campo Unidade é obrigatorio")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O descrição deve conter entre 3 e 100 caractes")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Unidade é obrigatorio")]
        public int Unidade { get; set; }

    }
}
