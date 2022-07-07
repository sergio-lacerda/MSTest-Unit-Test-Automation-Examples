using System;

namespace ExemploAPI.Util
{
    // This class contains orders discount calculation rules.
    public class Desconto
    {
        /*
         *  This method calculates the order percentage discount based on
         *  its value (parameter: valorCompra).
         *  
         *      * value >  1,000.00 --> 3%
         *      * value >    500.00 --> 1%
         *      * value <=   500.00 --> 0%
         */
        public float percentualDesconto (float valorCompra)
        {
            if (valorCompra < 0)
                throw new ArgumentException();

            if (valorCompra > 1000.00)
                return 0.03f;

            if (valorCompra > 500.00)
                return 0.01f;

            return 0.00f;
        }

        /*
         *  This method calculates the order discount value based on
         *  its value (parameter: valorCompra).
         */
        public float valorDesconto (float valorCompra)
        {
            if (valorCompra < 0)
                throw new ArgumentException();

            return valorCompra * percentualDesconto(valorCompra);
        }

        /*
         *  This method calculates the order net value (with discount if have) 
         *  based on its total value (parameter: valorCompra).
         */
        public float valorFinalComDesconto (float valorCompra)
        {
            if (valorCompra < 0)
                throw new ArgumentException();

            return valorCompra - valorDesconto(valorCompra);
        }
    }
}
