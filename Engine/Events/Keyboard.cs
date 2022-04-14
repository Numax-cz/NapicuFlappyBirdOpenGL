using GLFW;
using static OpenGL.GL;

namespace NapicuEngine.Engine.Events
{
    public class Keyboard
    {
        private static Keyboard ins;
        private bool[] keysPressed = new bool[350];

        private Keyboard() {

        }

        public static Keyboard Get() {
            if(Keyboard.ins == null){
                Keyboard.ins = new Keyboard();
            }
            return Keyboard.ins;
        }

        public static void KeyCallback(Window window, Keys key, int scanCode, InputState state, ModifierKeys mods){
            if(state == InputState.Press){
                Get().keysPressed[(int)key] = true;
            }else if(state == InputState.Release){
                Get().keysPressed[(int)key] = false;
            }
        }

        public static bool IsKeyPressed(int code){
            return Get().keysPressed[code];
        }
    }
    
}
