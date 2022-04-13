namespace NapicuEngine.Engine.Math;

public class Matrix4f
{
    public float[] elements = new float[16];
    
    public static Matrix4f identity() {
        Matrix4f result = new Matrix4f();
        for (int i = 0; i < 16; i++) {
            result.elements[i] = 0.0f;
        }
        result.elements[0 + 0 * 4] = 1.0f;
        result.elements[1 + 1 * 4] = 1.0f;
        result.elements[2 + 2 * 4] = 1.0f;
        result.elements[3 + 3 * 4] = 1.0f;
		
        return result;
    }
    
    public static Matrix4f translate(Vector2f vector) {
        Matrix4f result = identity();
        result.elements[0 + 3 * 4] = vector.x;
        result.elements[1 + 3 * 4] = vector.y;
        return result;
    }
    
    public static Matrix4f rotate(float angle) {
        Matrix4f result = identity();
        float r = (float) (angle * System.Math.PI)/180.0f;
        float cos = (float) System.Math.Cos(r);
        float sin = (float) System.Math.Sin(r);
		
        result.elements[0 + 0 * 4] = cos;
        result.elements[1 + 0 * 4] = sin;
		
        result.elements[0 + 1 * 4] = -sin;
        result.elements[1 + 1 * 4] = cos;
		
        return result;
    }
    


}