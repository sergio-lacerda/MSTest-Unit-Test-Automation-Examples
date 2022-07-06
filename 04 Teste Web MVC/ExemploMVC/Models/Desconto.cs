using System;

namespace ExemploMVC.Models
{
    // This class contains orders discount calculation rules.
    public class Desconto
    {
        /*
         *  This method calculates the order percentage discount based on
         *  its value (parameter: valor).
         *  
         *      * value >  200.00 --> 1.5%
         *      * value >  100.00 --> 1.0%
         *      * value <= 100.00 --> 0.0%
         */
        public float percentualDesconto (float valor)
        {
            //Raising an ArgumentException for incoherent parameter.            
            if (valor < 0)
            {
                throw new ArgumentException();
            }

            if (valor > 200.0)
                return 1.5f;

            if (valor > 100.0)
                return 1.0f;

            return 0.0f;
        }

        /*
         *  This method calculates the order discount value based on
         *  its value (parameter: valor).
         */
        public float valorDesconto(float valor)
        {
            //Raising an ArgumentException for incoherent parameter.            
            if (valor < 0)
            {
                throw new ArgumentException();
            }

            return valor * percentualDesconto(valor)/100;
        }

        /*
         *  This method calculates the order net value (with discount if have) 
         *  based on its total value (parameter: valor).
         */
        public float valorFinal(float valor)
        {
            //Raising an ArgumentException for incoherent parameter.            
            if (valor < 0)
            {
                throw new ArgumentException();
            }

            return valor - valorDesconto(valor);
        }
    }
}
