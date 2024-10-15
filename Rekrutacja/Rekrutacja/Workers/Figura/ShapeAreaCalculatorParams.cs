using Soneta.Business;
using Soneta.Types;


namespace Rekrutacja.Workers.Figura
{
    public class ShapeAreaCalculatorParams : ContextBase
    {
        [Caption("A")]
        public double ValueA { get; set; }
        [Caption("B")]
        public double ValueB { get; set; }

        [Caption("Data obliczeń")]
        public Date CalculationDate { get; set; }

        [Caption("Figura")]
        public ShapeType Shape{ get; set; }


        public ShapeAreaCalculatorParams(Context context) : base(context)
        {
            CalculationDate = Date.Today;
        }
    }
}
