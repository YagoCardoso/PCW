using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCW.Models
{
    [Table("PESSOAS")]
    public class Pessoas
    {
        [Key] 
        public int SEQPESSOA { get; set; }
        [Required]
        public string NOME { get; set; }
        public string CIDADE { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string DTNASCIMENTO { get; set; }
        [Required]
        public string USUARIO { get; set; }
        [Required]
        public string SENHA { get; set; }
        public string TIPO { get; set; }
        public string TELEFONE { get; set; }
        public string ENDERECO { get; set; }
        public string NUMERO { get; set; }
        public string ESTADO { get; set; }
        public string CEP { get; set; }
    }
}
