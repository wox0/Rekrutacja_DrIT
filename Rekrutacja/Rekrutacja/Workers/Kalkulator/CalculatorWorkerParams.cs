using Soneta.Business;
using Soneta.Types;


namespace Rekrutacja.Workers.Kalkulator
{
    public class CalculatorWorkerParams : ContextBase
    {
        [Caption("A")]
        public double ValueA { get; set; }
        [Caption("B")]
        public double ValueB { get; set; }

        [Caption("Data obliczeń")]
        public Date CalculationDate { get; set; }

        [Caption("Operacja")]
        public string OperationSign{ get; set; }


        public CalculatorWorkerParams(Context context) : base(context)
        {
            CalculationDate = Date.Today;
        }
    }
}
