using NapicuEngine.Engine;

namespace NapicuEngine.Objects;

public class Square : Engine.Mesh
{
    protected override VertexArray _vertexArray { get; set; } 
    
    public Square(float size)
    {
        _vertexArray = new VertexArray(new float[]
        {
            -size, -size,
            size, -size, 
            size, size, 
            -size, size,
        }, new []
        {
            0, 1, 2,
            2, 3, 0
        });

    }
}