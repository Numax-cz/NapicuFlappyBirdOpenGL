namespace NapicuEngine.Engine.Math;

public class Vector3f
{
    public float x { get; set; }
    public float y { get; set; }
    
    public Vector3f() {
        x = 0.0f;
        y = 0.0f;
    }

    public Vector3f(float x, float y) {
        this.x = x;
        this.y = y;
    }

}