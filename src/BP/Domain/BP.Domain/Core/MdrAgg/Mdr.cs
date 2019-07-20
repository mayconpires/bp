using BP.Domain.Core.MdrAgg.EntityChild;
using BP.Domain.Core.MdrAgg.Enums;
using BP.Domain.Core.TransactionAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.Domain.Core.MdrAgg
{
    public class Mdr
    {
        protected Mdr()
        {
        }

        public static Mdr Criar(string idAdquirente , string adquirente)
        {
            var mdr = new Mdr();

            mdr.IdAdquirente = idAdquirente;
            mdr.Adquirente = adquirente;

            return mdr;
        }

        public string IdAdquirente { get; private set; }
        public string Adquirente { get; private set; }

        private List<Taxa> _taxas = new List<Taxa>();

        public IReadOnlyCollection<Taxa> Taxas
        {
            get
            {
                return _taxas.AsReadOnly();
            }

            private set => _taxas = new List<Taxa>();
        }

        public void AddTaxa(BandeiraTipo bandeira, decimal taxaCredito, decimal taxaDebito)
        {
            var taxa = Taxa.Add(bandeira: bandeira, taxaCredito: taxaCredito, taxaDebito: taxaDebito);

            _taxas.Add(taxa);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/7360432/c-sharp-rounding-midpointrounding-toeven-vs-midpointrounding-awayfromzero
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="tipoTransaction"></param>
        /// <param name="bandeira"></param>
        /// <returns></returns>
        public decimal CalcularValorLiquido(decimal valor, TipoTransaction tipoTransaction, BandeiraTipo bandeira)
        {
            decimal percentualTaxa = 0m;
            decimal valorLiquido = 0m;

            var taxa = _taxas.Where(t => t.Bandeira == bandeira).FirstOrDefault();

            if (tipoTransaction == TipoTransaction.Debito)
                percentualTaxa = taxa.Debito;
            else if (tipoTransaction == TipoTransaction.Credito)
                percentualTaxa = taxa.Credito;

            valorLiquido = aplicarTaxaSobreValor(valor, percentualTaxa);

            return valorLiquido;
        }

        protected static decimal aplicarTaxaSobreValor(decimal valor, decimal percentualTaxa)
        {
            decimal valorTotal = valor;
            decimal percentualTaxaMdr = percentualTaxa;

            decimal valorLiquido = valorTotal - (valorTotal * (percentualTaxaMdr / 100));

            valorLiquido = Math.Round(valorLiquido, 2, MidpointRounding.ToEven);

            return valorLiquido;
        }
    }
}
