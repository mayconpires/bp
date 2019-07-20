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

        public static Transaction Create(decimal valor, string adquirente, string bandeira, string tipo)
        {
            var transaction = new Transaction();

            transaction.Valor = valor;
            transaction.Adquirente = adquirente;
            transaction.Bandeira = bandeira;
            transaction.Tipo = tipo;

            return transaction;
        }

        public decimal Valor { get; private set; }

        public decimal ValorLiquido { get; private set; }

        public string Adquirente { get; private set; }

        public string Bandeira { get; private set; }

        public string Tipo { get; private set; }


    }
}
