namespace Napicu.Engine.Math;

public class Vector3f
{
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }
    
    public Vector3f() {
        x = 0.0f;
        y = 0.0f;
        z = 0.0f;
    }

    public Vector3f(float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }



}