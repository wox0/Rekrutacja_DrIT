using Rekrutacja.Workers.Figura;
using Rekrutacja.Workers.Parser;
using Soneta.Business;
using Soneta.Kadry;
using System;


[assembly: Worker(typeof(ParserWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers.Parser
{
    public class ParserWorker
    {
        [Context]
        public Context context { get; set; }

        [Context]
        public ParserWorkerParams WorkerParams { get; set; }

        private ShapeCalculator calculator;

        public ParserWorker()
        {
            calculator = new ShapeCalculator();
        }

        [Action("Kalkulator + Parser",
            Description = "Kalkulator na stringach (☉ɷ⊙)",
            Priority = 12,
            Mode = ActionMode.ReadOnlySession,
            Icon = ActionIcon.Wizard,
            Target = ActionTarget.ToolbarWithText)]
        public void PerformAction()
        {
            DebuggerSession.MarkLineAsBreakPoint();

            var type = typeof(Pracownik[]);
            var workers = context.Contains(type) ? (Pracownik[])context[type] : null;

            using (var newSession = context.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
            {
                using (var transaction = newSession.Logout(true))
                {
                    foreach (var item in workers) 
                    {
                        var workerFromSession = newSession.Get(item);
                        var result = calculator.Calculate(StringToInt.Parse(WorkerParams.ValueA), StringToInt.Parse(WorkerParams.ValueB), WorkerParams.ShapeType);

                        workerFromSession.Features["Wynik(Int)"] = result;
                        workerFromSession.Features["DataObliczen"] = WorkerParams.CalculationDate;
                    }

                    transaction.CommitUI();
                }

                newSession.Save();
            }
        }
    }
}
