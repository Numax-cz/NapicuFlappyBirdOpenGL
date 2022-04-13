
using NapicuEngine;
using NapicuEngine.Engine;
using NapicuEngine.Engine.utils;

namespace Napicu
{
    class Program
    {


        public static void Main(string[] args)
        {
            NapicuGame game = new NapicuGame("Napicu", 1280, 720);
            game.Run();
        }
    }
    
};

