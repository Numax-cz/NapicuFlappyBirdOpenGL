using Napicu.Engine;

namespace Napicu
{
    class Program
    {


        public static void Main(string[] args)
        {
            NapicuGame.NapicuGame game = new NapicuGame.NapicuGame("Napicu", 1280, 720);
            game.Run();
        }
    }
    
};

