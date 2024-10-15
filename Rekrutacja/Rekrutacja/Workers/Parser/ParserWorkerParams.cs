using Rekrutacja.Workers.Figura;
using Soneta.Business;
using Soneta.Types;


namespace Rekrutacja.Workers.Parser
{
    public class ParserWorkerParams : ContextBase
    {
        [Caption("A")]
        public string ValueA { get; set; }
        [Caption("B")]
        public string ValueB { get; set; }

        [Caption("Data obliczeń")]
        public Date CalculationDate { get; set; }

        [Caption("Figura")]
        public ShapeType ShapeType{ get; set; }


        public ParserWorkerParams(Context context) : base(context)
        {
            CalculationDate = Date.Today;
        }
    }
}
