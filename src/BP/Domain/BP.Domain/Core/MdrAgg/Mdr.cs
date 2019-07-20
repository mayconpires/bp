using BP.Domain.Core.MdrAgg.EntityChild;
using BP.Domain.Core.MdrAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Core.MdrAgg
{
    public class Mdr
    {
        private Mdr()
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

    }
}
