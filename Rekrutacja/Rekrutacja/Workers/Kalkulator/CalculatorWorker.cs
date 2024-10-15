using Rekrutacja.Workers.Kalkulator;
using Soneta.Business;
using Soneta.Kadry;
using System;


[assembly: Worker(typeof(CalculatorWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers.Kalkulator
{
    public class CalculatorWorker
    {
        [Context]
        public Context context { get; set; }

        [Context]
        public CalculatorWorkerParams WorkerParams { get; set; }

        private Calculator calculator;

        public CalculatorWorker()
        {
            calculator = new Calculator();
        }

        [Action("Kalkulator",
            Description = "Prosty kalkulator",
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
                        var operationType = OperationConverter.Convert(WorkerParams.OperationSign); //niepotrzebne, ale enumy ładniejsze :P
                        var result = calculator.Calculate(WorkerParams.ValueA, WorkerParams.ValueB, operationType);

                        workerFromSession.Features["Wynik"] = result;
                        workerFromSession.Features["DataObliczen"] = WorkerParams.CalculationDate;
                    }

                    transaction.CommitUI();
                }

                newSession.Save();
            }
        }
    }
}
