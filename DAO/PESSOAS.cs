using System;
using System.ComponentModel.DataAnnotations;

namespace DAO
{
    public class PESSOAS
    {
        public decimal COD_PESSOA { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "RG é obrigatório.")]
        [StringLength(15, ErrorMessage = "O RG deve ter no máximo 15 caracteres.")]
        public string RG { get; set; }

        [Phone(ErrorMessage = "O número de telefone deve ser válido.")]
        [StringLength(20, ErrorMessage = "O TELEFONE deve ter no máximo 20 caracteres.")]
        public string TELEFONE { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        [StringLength(200, ErrorMessage = "O TELEFONE deve ter no máximo 200 caracteres.")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório.")]
        [RegularExpression(@"^(M|F)$", ErrorMessage = "Sexo deve ser 'M' para Masculino ou 'F' para Feminino.")]
        public string SEXO { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento deve ser uma data válida.")]
        public DateTime DATA_NASCIMENTO { get; set; }
    }
}
