using Rekrutacja.Workers.Figura;
using Soneta.Business;
using Soneta.Kadry;
using System;


[assembly: Worker(typeof(ShapeAreaCalculatorWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers.Figura
{
    public class ShapeAreaCalculatorWorker
    {
        [Context]
        public Context context { get; set; }

        [Context]
        public ShapeAreaCalculatorParams WorkerParams { get; set; }

        private ShapeCalculator calculator;

        public ShapeAreaCalculatorWorker()
        {
            calculator = new ShapeCalculator();
        }

        [Action("Kalkulator figur",
            Description = "Kalkulator dla pola powierzchni figur",
            Priority = 10,
            Mode = ActionMode.ReadOnlySession,
            Icon = ActionIcon.Accept,
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
                        var result = calculator.Calculate(WorkerParams.ValueA, WorkerParams.ValueB, WorkerParams.Shape);

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
