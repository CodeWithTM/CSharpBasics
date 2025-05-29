// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Tuple<int, string> tuple = new Tuple<int, string>(1,"TM");

ValueTuple<int> valueTuple = ValueTuple.Create(2);

(int, string) tuple2 = (2, "name");

Console.WriteLine(tuple2.Item1);

(int id, string name) tuple3 = (2, "id");
Console.WriteLine(tuple3.name);

public class Emploee
{

    public void ShowEmpDetails((int id, string name) emp)
    {
        Console.WriteLine(emp.name);
    }

    public (int, string) GetEmpDetails()
    {
        return ValueTuple.Create(2, "");
    }

}

//int? num3 = null;

//int? num4 = num3 ?? 0;
//int b = 10;

//num4 ??= b;





