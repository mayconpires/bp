using BP.Domain.Tests.Core.MdrAgg.Arrange;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BP.Domain.Tests.Core.MdrAgg.GivenMdr
{
    public class QuandoCalcularValorLiquido
    {

        [Theory(DisplayName = "DADO Mdr Adquirente A QUANDO Aplicar Taxa Mdr sobre Valor da Transaction ENTÃO Calcule")]
        [InlineData(100, 2.25, 97.75)]
        [InlineData(100, 2.00, 98)]
        [InlineData(100, 2.35, 97.65)]
        [InlineData(100, 1.98, 98.02)]
        public void QuandoAplicarTaxaSobreValorAdquirenteA(decimal valorTransacao, decimal percentualTaxa, decimal valorLiquidoEsperado)
        {
            decimal valorLiquido = ArrangeMdr.AplicarTaxaSobreValor(valor: valorTransacao, percentualTaxa: percentualTaxa);

            valorLiquido.Should().Be(valorLiquidoEsperado);
        }

        [Theory(DisplayName = "DADO Mdr Adquirente B QUANDO Aplicar Taxa Mdr sobre Valor da Transaction ENTÃO Calcule")]
        [InlineData(777.77, 2.50, 758.33)]
        [InlineData(777.77, 2.08, 761.59)]
        [InlineData(777.77, 2.65, 757.16)]
        [InlineData(777.77, 1.75, 764.16)]
        public void QuandoAplicarTaxaSobreValorAdquirenteB(decimal valorTransacao, decimal percentualTaxa, decimal valorLiquidoEsperado)
        {
            decimal valorLiquido = ArrangeMdr.AplicarTaxaSobreValor(valor: valorTransacao, percentualTaxa: percentualTaxa);

            valorLiquido.Should().Be(valorLiquidoEsperado);
        }

        [Theory(DisplayName = "DADO Mdr Adquirente C QUANDO Aplicar Taxa Mdr sobre Valor da Transaction ENTÃO Calcule")]
        [InlineData(313952754.01, 2.75, 305319053.27)]
        [InlineData(313952754.01, 2.16, 307171374.52)]
        [InlineData(313952754.01, 3.1, 304220218.64)]
        [InlineData(313952754.01, 1.58, 308992300.50)]
        public void QuandoAplicarTaxaSobreValorAdquirenteC(decimal valorTransacao, decimal percentualTaxa, decimal valorLiquidoEsperado)
        {
            decimal valorLiquido = ArrangeMdr.AplicarTaxaSobreValor(valor: valorTransacao, percentualTaxa: percentualTaxa);

            valorLiquido.Should().Be(valorLiquidoEsperado);
        }

        [Theory(DisplayName = "DADO Mdr Outras Adquirente QUANDO Aplicar Taxa Mdr sobre Valor da Transaction ENTÃO Calcule")]
        [InlineData(0.01, 1.58, 0.01)]
        [InlineData(1, 1.58, 0.98)]
        public void QuandoAplicarTaxaSobreValorOutrasAdquirentes(decimal valorTransacao, decimal percentualTaxa, decimal valorLiquidoEsperado)
        {
            decimal valorLiquido = ArrangeMdr.AplicarTaxaSobreValor(valor: valorTransacao, percentualTaxa: percentualTaxa);

            valorLiquido.Should().Be(valorLiquidoEsperado);
        }
    }
}
