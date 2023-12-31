﻿namespace ttt;

public class Input
{
    public Position ReadPosition()
    {
        Console.Write("Input position: ");
        
        try
        {
            return new Position(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Error, try again.");
            return ReadPosition();
        }
    }

    public bool ReadBool()
    {
        Console.Write("y/n: ");
    
        var str = Console.ReadLine();
    
        if (str == null || (str != "y" && str != "n"))
        {
            Console.WriteLine("Error, try again.");
            return ReadBool();
        }

        return str == "y";
    }

    public Player ReadPlayer()
    {
        Console.Write("X/O: ");
        
        var str = Console.ReadLine();
    
        if (str == null || (str != "X" && str != "O"))
        {
            Console.WriteLine("Error, try again.");
            return ReadPlayer();
        }

        return str == "X" ? Player.X : Player.O;
    }
}