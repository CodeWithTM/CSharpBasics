namespace CApp_Lib
{
    public class Class1
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.OpenRead("C:\\DumpStack.log"))
            {
                byte[] data = new byte[fs.Length];
            }
        }
    }
}
