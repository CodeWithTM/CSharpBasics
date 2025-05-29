using System;

namespace CApp_Practice
{
    internal class ExceptionHandling
    {
        public void Main()
        {
            try
            {
                //TryWithoutCatch();

                ExInFinally();

                Console.WriteLine("Entering Main..");
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine("Calling base..");
                BaseMethod(number);

                Console.WriteLine("Finished base..");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception ::" + e.Message);

                Console.WriteLine(e.StackTrace);
                Console.WriteLine("--------------------------");
            }
        }

        private int BaseMethod(int i)
        {
            try
            {
                return ChildMethod(i);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ::" + ex.Message);

                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("--------------------------");



                //throw ex; --> consider this as ORIGIN / STARTING POINT of exception and forget all other exception that would have occured b4 this

                //dont use throw ex; for existing caught exception
                //use throw ex; with custom exceptions

                //lets take an example of custom exception.. 
                //from this methods points of view its an Argument exception, because we are passing an arguemnt which is larger than array length

                Exception customEx = new ArgumentException("Invalid argument", ex); // 2nd parameter ex -> INNER EXCEPTION
                throw customEx;
            }
        }

        private int ChildMethod(int index)
        {
            try
            {

                int[] intArray = new int[] { 1, 2, 0, 4, 5, 3 };

                return intArray[index];

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ::" + ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("--------------------------");
                //return 0; // this is not proper handling on exception
                throw ex;
                //throw;
                //at this point throw / throw ex doesnt matters, because this is the last point in call heirarchy. 
                //and all the details of exception willbe propogated / thrown..
            }
        }

        public void DBConn()
        {
            try
            {

            }
            //catch (Exception)
            //{
                //throw;
            //}
            finally
            {

                //if any exception occurs in finally block, it will be thrown to calling method
                string str = null;
                Console.WriteLine(str.ToUpper());
            }
            
        }

        public void ExInFinally()
        {
            try
            {
                int i = 5;

                int[] intArray = new int[] { 1, 2, 0 };

                int number = intArray[i];
            }
            catch
            {
                throw;
            }
            finally
            {
                //if Exception already occured in try block and
                //if there is exception in finally block also..
                //then the exception occured in FINALLY block is propogated and the exception in catch block is swallowed

                //so the exception will be Object reference rather than index out of bounds
                string str = null;
                Console.WriteLine(str.ToUpper());
            }
        }

        public void TryWithoutCatch()
        {
            //we can have try without catch, but finally needs to be provided..
            //expected catch / finally
            try
            {

            }
            finally
            {
                
            }
            
        }
    }
}
