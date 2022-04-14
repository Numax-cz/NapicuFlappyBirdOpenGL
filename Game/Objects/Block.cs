using Napicu.Engine;
using Napicu.Engine.Math;

namespace NapicuGame.Objects{
    
    public class Block : Napicu.Engine.Object
    {
        
        protected override Shader Shader { get; set; } = new Shader("square.vert", "square.frag");
        protected override VertexArray Mesh { get; set; }
        public override Vector2f Position { get; set; }

        protected override float GravityForce { get; set; } = 0f;
        


        public Block(float size, float x, float y)
        {
            
            Position = new Vector2f(x, y);

            float [] pos = new float [] {
                -size, -size, 1f, 0f, 1f,
                size, -size, 1f, 1f, 0f,
                size, size, 0f, 1f, 0f,
                -size, size,0f, 0f, 1f,

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