using System;

namespace VintelerEricav2_Lab2
{
    internal class DoughnutMachine
    {
        public DoughnutMachine.DoughnutCompleteDelegate DoughnutComplete { get; internal set; }
        public bool Enabled { get; internal set; }

        internal void MakeDoughnuts(object glazed)
        {
            throw new NotImplementedException();
        }

        internal class DoughnutCompleteDelegate
        {
            private Action doughnutCompleteHandler;

            public DoughnutCompleteDelegate(Action doughnutCompleteHandler)
            {
                this.doughnutCompleteHandler = doughnutCompleteHandler;
            }
        }
    }
}