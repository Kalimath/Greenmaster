using Greenmaster.TK.Core;
using Greenmaster.TK.Impl;

namespace Greenmaster.TK;

public class Program
{
    public static void Main(string[] args)
    {
        var game = new TestGame("Test Game",800, 600);
        game.Run();
    }
}