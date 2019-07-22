using BP.Domain.Core.MdrAgg;
using BP.Domain.Core.MdrAgg.Enums;
using BP.Domain.Core.TransactionAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Core.TransactionAgg
{
    public class Transaction
    {
        private Transaction()
        {
        }

        public static Transaction Create(Mdr mdrAdquirente, decimal valor, TipoTransaction tipo, BandeiraTipo bandeira)
        {
            var transaction = new Transaction();

            transaction.Valor = valor;
            transaction.ValorLiquido = mdrAdquirente.CalcularValorLiquido(valor: valor, tipoTransaction: tipo, bandeira: bandeira);
            transaction.Adquirente = mdrAdquirente.IdAdquirente;
            transaction.Bandeira = bandeira;
            transaction.Tipo = tipo;

            return transaction;
        }

        public decimal Valor { get; private set; }

        public decimal ValorLiquido { get; private set; }

        public string Adquirente { get; private set; }

        public BandeiraTipo Bandeira { get; private set; }

        public TipoTransaction Tipo { get; private set; }

    }
}
