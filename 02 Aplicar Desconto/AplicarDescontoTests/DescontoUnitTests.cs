using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicarDesconto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicarDesconto.Tests
{
    [TestClass()]
    public class DescontoUnitTests
    {
        /* 
            In this example, let's implement a test initialization providing 
            the resources that should be available to all test methods.
        */
        private Desconto _desconto;

        [TestInitialize]
        public void Inicializar()
        {
            _desconto = new Desconto();
        }

        /* 
            Let´s introduce the use of DataRow to provide parameters for 
            tests methods and test all conditions in only one method.
            In this scenario, we are testing if an order is eligible for discount.
        */
        [TestMethod()]
        [DataRow(103.36f, false)]
        [DataRow(349.99f, false)]
        [DataRow(350.00f, true)]
        [DataRow(350.01f, true)]
        [DataRow(420.54f, true)]
        public void recebeValor_DeveTestarSeTemDesconto(float valor, bool esperado)
        {
            //Act - Executing the test
            bool obtido = _desconto.recebeDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        /*             
            In this scenario, we are testing for the order percentage discount.
            Here, we are also introducing the use of decimal places definition in
            the assert statement: Assert.AreEqual(esperado, obtido, 3);
        */
        [TestMethod()]
        [DataRow(103.36f, 0.000f)]
        [DataRow(349.99f, 0.000f)]
        [DataRow(350.00f, 0.005f)]
        [DataRow(350.01f, 0.005f)]
        [DataRow(420.54f, 0.005f)]
        [DataRow(999.99f, 0.005f)]
        [DataRow(1000.00f, 0.010f)]
        [DataRow(2999.99f, 0.010f)]
        [DataRow(3000.00f, 0.020f)]
        [DataRow(4999.99f, 0.020f)]
        [DataRow(5000.00f, 0.030f)]
        [DataRow(8654.27f, 0.030f)]
        public void recebeValor_DeveRetornarPercentualDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.percentualDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 3);
        }

        /*             
            In this scenario, we are testing for the order discount value.
        */
        [TestMethod()]
        [DataRow(103.36f, 0.00f)]
        [DataRow(349.99f, 0.00f)]
        [DataRow(350.00f, 1.75f)]
        [DataRow(350.01f, 1.75f)]
        [DataRow(420.54f, 2.10f)]
        [DataRow(999.99f, 5.00f)]
        [DataRow(1000.00f, 10.00f)]
        [DataRow(2999.99f, 30.00f)]
        [DataRow(3000.00f, 60.00f)]
        [DataRow(4999.99f, 100.00f)]
        [DataRow(5000.00f, 150.00f)]
        [DataRow(8654.27f, 259.63f)]
        public void recebeValor_DeveRetornarValorDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.valorDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        /*             
            In this scenario, we are testing for the final order value 
            (total considering the discount if have).
        */
        [TestMethod()]
        [DataRow(103.36f, 103.36f)]
        [DataRow(349.99f, 349.99f)]
        [DataRow(350.00f, 348.25f)]
        [DataRow(350.01f, 348.26f)]
        [DataRow(420.54f, 418.44f)]
        [DataRow(999.99f, 994.99f)]
        [DataRow(1000.00f, 990.00f)]
        [DataRow(2999.99f, 2969.99f)]
        [DataRow(3000.00f, 2940.00f)]
        [DataRow(4999.99f, 4899.99f)]
        [DataRow(5000.00f, 4850.00f)]
        [DataRow(8654.27f, 8394.64f)]
        public void recebeValor_DeveRetornarTotalCompra(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.totalCompra(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }
    }
}