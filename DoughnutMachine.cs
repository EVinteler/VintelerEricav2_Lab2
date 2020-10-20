using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Text;
using System.Windows.Threading;

namespace VintelerEricav2_Lab2
{

    class DoughnutMachine : Component
    {
        DispatcherTimer doughnutTimer;
        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }

        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        private DoughnutType mFlavor;
        public DoughnutType Flavor
        { // indica tipul de doughnut
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
             
            private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
            public Doughnut this[int Index]
            {
                get
                {
                    return (Doughnut)mDoughnuts[Index];
                }
                set
                {
                    mDoughnuts[Index] = value;
                }
            }
            public DoughnutMachine()
            {
                InitializeComponent();
            }

            private void doughnutTimer_Tick(object sender, EventArgs e)
            {
                Doughnut aDoughnut = new Doughnut(this.Flavor);
                mDoughnuts.Add(aDoughnut);
                DoughnutComplete();
            }

            public bool Enabled
            {
                set
                {
                    doughnutTimer.IsEnabled = value;
                }
            }
            public int Interval
            {
                set
                {
                    doughnutTimer.Interval = new TimeSpan(0, 0, value);
                }
            }
            public void MakeDoughnuts(DoughnutType aFlavor)
            {
                Flavor = aFlavor;
                switch (Flavor)
                {
                    case DoughnutType.Glazed: Interval = 3; break;
                    case DoughnutType.Sugar: Interval = 2; break;
                    case DoughnutType.Lemon: Interval = 5; break;
                    case DoughnutType.Chocolate: Interval = 7; break;
                    case DoughnutType.Vanilla: Interval = 4; break;
                }
                doughnutTimer.Start();
            }
        }

        public enum DoughnutType
        {
            Glazed,
            Sugar,
            Lemon,
            Chocolate,
            Vanilla
        }
        class Doughnut
        {
            public DoughnutType mFlavor;
            public DoughnutType Flavor
            {
                get
                {
                    return mFlavor;
                }
                set
                {
                    mFlavor = value;
                }
            }

            public float mPrice = 0.50F;
            public float Price
            {
                get
                {
                    return mPrice;
                }
                set
                {
                    mPrice = value;
                }
            }

            public readonly DateTime mTimeOfCreation;
            public DateTime TimeOfCreation
            {
                get
                {
                    return mTimeOfCreation;
                }
            }

            public Doughnut(DoughnutType aFlavor)
            {
                mTimeOfCreation = DateTime.Now;
                mFlavor = aFlavor;
            }
        }
    
}
