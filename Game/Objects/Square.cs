using Napicu.Engine;
using Napicu.Engine.Math;
using Napicu.Engine;

namespace NapicuGame.Objects
{
    public class Square : Napicu.Engine.Object
    {
        protected override Shader Shader { get; set; } = new Shader("default.vert", "default.frag");
        protected override VertexArray Mesh { get; set; }
        public override Vector2f Position { get; set; }

        protected override float GravityForce { get; set; } = 0.85f;
        


        public Square(float size, float x, float y)
        {
            Position = new Vector2f(x, y);

            float [] pos = new float [] {
                0.0f, 0.0f,  1f, 0f, 1f,
                0.0f, size,  1f, 1f, 0f,
                size, size,  0f, 1f, 0f,
                size, 0.0f,  0f, 0f, 1f,

            };

            int[] ints = new[]
            {
                0, 1, 2,
                2, 3, 0
            };
            

            Mesh = new VertexArray(pos, ints);
        }
        

    }
    
}

