using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.ViewModels
{
    public class TelefoneViewModel
    {
        public TelefoneViewModel()
        {
            TelefoneId = Guid.NewGuid();
        }

        [Key]
        public Guid TelefoneId { get; set; }

        [Required(ErrorMessage = "Preencha o campo DDD")]
        public int DDD { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        public int NumeroTelefone { get; set; }

        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }
    }
}