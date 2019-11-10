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
      
        public string TIPO { get; set; }
        public string TELEFONE { get; set; }
        public string ENDERECO { get; set; }
        public string NUMERO { get; set; }
        public string ESTADO { get; set; }
        public string CEP { get; set; }

        private string _senha;
        public string SENHA
        {
            get { if (_senha == null) { _senha = "0"; } return _senha; }
            set { _senha = value; }
        }

        private string _usuario;
        public string USUARIO
        {
            get { if (_usuario == null) { _usuario = "0"; } return _usuario; }
            set { _usuario = value; }
        }

        private string _cnh;
        public string CNH
        {
            get { if (_cnh == null) { _cnh = "0"; } return _cnh; }
            set { _cnh = value; }
        }
    }
}



