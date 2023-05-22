using System.ComponentModel.DataAnnotations;

namespace API.Models {
    public class GarconModel {
        public int? GarconID { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public int? NumIdentificao { get; set; }
        [RegularExpression(@"^\(\d{2}\)\d{9}$", ErrorMessage = "Formato inválido de telefone.")]
        public string? Telefone { get; set; }
    }
}