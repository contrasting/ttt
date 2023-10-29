namespace ttt;

public class Input
{
    public Position Read()
    {
        Console.Write("Input position: ");
        
        try
        {
            return new Position(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Error, try again.");
            return Read();
        }
    }
}