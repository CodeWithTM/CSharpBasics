using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    public class SingletonCls
    {
        //private constructor will restrict obj creation
        private SingletonCls() { }

        //this will hold reference for that 1 global instance created..
        private static SingletonCls instance; // = new SingletonCls(); //commented - bcoz even if we dont call GetInstance method, the global instance will get created


        private static object instanceLock = new object();

        //access point - which will be used to get that global instance variable
        public static SingletonCls GetInstance()
        {

            //in order to improve the performance we have added this outter null check
            //so that every time we dont have to perform the locker check, before entering the block
            if (instance == null)
            {
                lock (instanceLock) // in case of multi-threading, multiple instances can be created if 2 threads try to create instance at the same time
                {
                    //as we have applied lock on outter block only 1 thread is allowed to enter inside and create instance while other threads are waiting outside
                    
                    if (instance == null) //only once time it will be null
                    {
                        instance = new SingletonCls();
                    }
                }
            }

            return instance;

        }
    }


}
