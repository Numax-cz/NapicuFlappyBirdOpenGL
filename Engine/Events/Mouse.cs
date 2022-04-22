using GLFW;

namespace Napicu.Engine.Events
{
    public class Mouse
    {
    private static Mouse _ins;
    private double _scrollX, _scrollY;
    private double _posX, _posY, _lastX, _lastY;
    private bool[] _buttonPressed = new bool[3];
    private bool _dragging;

    private Mouse(){
        this._scrollX = 0.0;
        this._scrollY = 0.0;
        this._posX = 0.0;
        this._posY = 0.0;
        this._lastX = 0.0;
        this._lastY = 0.0;
    }

    public static Mouse get(){
        if(Mouse._ins == null){
            Mouse._ins = new Mouse();
        }
        return Mouse._ins;
    }

    public static void PosCallback(Window window1, double x, double y){
        get()._lastX = get()._posX;
        get()._lastY = get()._posY;
        get()._posX = x;
        get()._posY = y;
        get()._dragging = get()._buttonPressed[0] || get()._buttonPressed[1] || get()._buttonPressed[2];
    }

    public static void ButtonCallback(Window window, MouseButton button, InputState inputState, ModifierKeys modifiers){
        if(inputState == InputState.Press){
            if((int)button < get()._buttonPressed.Length){
                get()._buttonPressed[(int)button] = true;
            }
        }else if(inputState == InputState.Release){
            get()._buttonPressed[(int)button] = false;
            get()._dragging = false;
        }
    }

    public static void ScrollCallback(Window window, double x, double y){
        get()._scrollX = x;
        get()._scrollY = y;
    }

    public static void Clear(){
        get()._scrollX = 0;
        get()._scrollY = 0;
        get()._lastX = get()._posX;
        get()._lastY = get()._posY;
    }


    public static float GetX(){
        return (float)get()._posX;
    }

    public static float GetY(){
        return (float)get()._posY;
    }

    public static float GetDx(){
        return (float)(get()._lastX - get()._posX);
    }

    public static float GetDy(){
        return (float)(get()._lastY - get()._posY);
    }

    public static float GetScrollX(){
        return (float)get()._scrollX;
    }

    public static float GetScrollY(){
        return (float)get()._scrollY;
    }

    public static bool IsDragging(){
        return get()._dragging;
    }

    public static bool ButtonDown(int button){
        if(button < get()._buttonPressed.Length){
            return get()._buttonPressed[button];
        }
        return false;
    }

    }
}
