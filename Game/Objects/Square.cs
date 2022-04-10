using NapicuEngine.Engine;
using NapicuEngine.Engine.Math;
using OpenGL;
using static OpenGL.GL;

namespace NapicuEngine.Objects;

public class Square : Engine.Mesh
{
    protected override VertexArray VertexArray { get; set; }
    protected override Vector2f Position { get; set; }


    protected float[] m;

    public Square(float size, float x, float y)
    {
        Position = new Vector2f(x, y);

        
      
        // x + size, y + size,
        // x + size, y - size,
        // x - size, y - size,
        // x - size, y + size,
        
        
        
        float [] pos = new float [] {
            -size, -size,
            size, -size, 
            size, size, 
            -size, size,
        };

        int[] ints = new[]
        {
            0, 1, 2,
            2, 3, 0
        };
        
        VertexArray = new VertexArray(pos, ints);
        
    }
    

}