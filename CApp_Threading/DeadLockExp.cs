using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    internal class DeadLockExp
    {
        public void Main(string[] args)
        {
            ATMDetails atmD1 = new ATMDetails(10000, 101);
            ATMDetails atmD2 = new ATMDetails(5000, 102);

            ATMSystem atmS1 = new ATMSystem(atmD1, atmD2, 1000);
            ATMSystem atmS2 = new ATMSystem(atmD2, atmD1, 1000);


            Thread t1 = new Thread(atmS1.Transfer) { Name = "T1"};
            t1.Start();

            Thread t2 = new Thread(atmS2.Transfer) { Name = "T2" };
            t2.Start();

            t1.Join();
            t2.Join();

            
            
            Console.WriteLine("completed..");
            Console.ReadLine();
        }


    }

    public class ATMSystem
    {
        private ATMDetails _fromATM;
        private ATMDetails _toATM;
        private double _amountToTransfer;

        public ATMSystem(ATMDetails fromATM, ATMDetails toATM, double amountToTransfer)
        {
            this._fromATM = fromATM;
            this._toATM = toATM;    
            this._amountToTransfer = amountToTransfer;
        }

        //Method which is causing DEADLOCK
        public void Transfer()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is acquiring lock with OBJ: " + _fromATM.ID);
            lock (_fromATM)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is performing long running op.. " + _fromATM.ID);
                Thread.Sleep(5000);

                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is awake now and acquiring lock with OBJ: " + _toATM.ID);
                lock (_toATM)
                {
                    _fromATM.WithDraw(_amountToTransfer);
                    _toATM.Deposit(_amountToTransfer);
                }
            }
        }

        //Solution 1: Acquiring lock in specific ORDER to avoid deadlock
        public void Transfer1()
        {
            object _lock1, _lock2;

            if (_fromATM.ID < _toATM.ID)
            {
                _lock1 = _fromATM;
                _lock2 = _toATM;
            }
            else
            {
                _lock1 = _toATM;
                _lock2 = _fromATM;
            }

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is acquiring lock with OBJ: " + _fromATM.ID);
            lock (_lock1)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is performing long running op.. " + _fromATM.ID);
                Thread.Sleep(5000);

                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is awake now and acquiring lock with OBJ: " + _toATM.ID);
                lock (_lock2)
                {
                    _fromATM.WithDraw(_amountToTransfer);
                    _toATM.Deposit(_amountToTransfer);
                }
            }
        }

        //Solution 2: using Moniter

        public void Transfer2()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is acquiring lock with OBJ: " + _fromATM.ID);
            lock (_fromATM)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is performing long running op.. " + _fromATM.ID);
                Thread.Sleep(5000);

                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Thread is awake now and acquiring lock with OBJ: " + _toATM.ID);

                if(Monitor.TryEnter(_toATM, 5000))
                {
                    try
                    {
                        _fromATM.WithDraw(_amountToTransfer);
                        _toATM.Deposit(_amountToTransfer);
                    }
                    finally
                    {
                        Monitor.Exit(_toATM);
                    }
                }
                else
                {
                    Console.WriteLine("unable to acquire lock..");
                }

            }
        }
    }

    public class ATMDetails
    {
        private double _balance;
        private int _id;

        public ATMDetails(int balance, int id)
        {
            _balance = balance;
            _id = id;
        }

        public int ID { get { return _id; } }

        public void WithDraw(double amount)
        {
            _balance -= amount;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }
    }
}
