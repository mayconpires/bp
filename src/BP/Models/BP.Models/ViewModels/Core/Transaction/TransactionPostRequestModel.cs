using BP.Models.ViewModels.Core.MDR;
using System.ComponentModel.DataAnnotations;

namespace BP.Models.ViewModels.Core.Transaction
{
    public class TransactionPostRequestModel
    {
        /// <summary>
        /// Valor da Transaction. Faixa de permitida de 0.01 até 999999999999999.
        /// </summary>
        [Required]
        [Range(type: typeof(decimal), minimum: "0.01", maximum: "999999999999999", ConvertValueInInvariantCulture = true, ErrorMessage = "Faixa de valores excedida de 0.01 até 999999999999999.")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "O Valor da Transaction deve conter no máximo duas casas decimais.")]
        public decimal Valor{ get; set; }

        /// <summary>
        /// Identificador da Adquirente
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string Adquirente { get; set; }

        /// <summary>
        /// Bandeira da Transaction
        /// </summary>
        [Required]
        public BandeiraTipoModel Bandeira { get; set; }

        /// <summary>
        /// Tipo da Transaction
        /// </summary>
        [Required]
        public TipoTransactionModel Tipo { get; set; }

    }
}
