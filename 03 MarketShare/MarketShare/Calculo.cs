using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShare
{
    /*
        This class have only one method that is responsible for calculating the
        market share of a company based on two parameters:

        + pVendas: Total sales of the company
        + pTotal: Total sales of all players together
    */
    public class Calculo
    {
        public float calculaMarketShare(float pVendas, float pTotal)
        {
            /* 
                If pTotal = 0.0, it will result in a C# Infinity, but we'd prefer
                to raise a DivisionByZeroExpcetion
            */
            if (pTotal == 0)
            {
                throw new DivideByZeroException();
            }

            /* 
                In the other hand, if ou method receives incoherent parameters 
                such as negative sales, or company sales higher than all players 
                sales togheter, etc., we can raise an exception, in this case, let´s
                use the ArgumentException.
            */
            if ((pVendas < 0) || (pTotal < 0) || (pVendas > pTotal))
            {
                throw new ArgumentException();
            }

            return (pVendas / pTotal) * 100;
        }
    }
}
