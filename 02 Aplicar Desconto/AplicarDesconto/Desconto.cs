using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicarDesconto
{
    /*
        This class encapsulates discount rules applied to a sales 
        process, based on its order value. Here, we aren´t testing
        yet for incoherent parameters.
    */
    public class Desconto
    {
        // Checking if an order is eligible for discount
        public bool recebeDesconto (float valor)
        {
            // Only orders which value is 350.00 or higher are eligible for discount.
            return (valor >= 350.00);
        }

        /* 
            Getting percentage discount based on the order value.

            + Value >= 5,000.00 --> Percentage discount: 3.0%
            + Value >= 3,000.00 --> Percentage discount: 2.0%
            + Value >= 1,000.00 --> Percentage discount: 1.0%
            + Value >=   350.00 --> Percentage discount: 0.5%
            + Value <    350.00 --> Percentage discount: 0.0%
        */
        public float percentualDesconto (float valor)
        {
            if (valor >= 5000.00)
                return 0.03f;

            if (valor >= 3000.00)
                return 0.02f;

            if (valor >= 1000.00)
                return 0.01f;

            if (valor >= 350.00)
                return 0.005f;

            return 0.00f;
        }

        // Getting discount value based on the order value.
        public float valorDesconto(float valor)
        {
            return valor * this.percentualDesconto(valor);
        }

        // Getting the final order value (total considering the discount if have).
        public float totalCompra(float valor)
        {
            return valor - this.valorDesconto(valor);
        }       
    }
}
