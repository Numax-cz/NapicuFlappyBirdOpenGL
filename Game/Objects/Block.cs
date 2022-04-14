using Napicu.Engine;
using Napicu.Engine.Math;

namespace NapicuGame.Objects{
    
    public class Block : Napicu.Engine.GameObject
    {
        
        protected override Shader Shader { get; set; } = new Shader("default.vert", "default.frag");
        protected override VertexArray Mesh { get; set; }
        public override Vector2f Position { get; set; }

        protected override float GravityForce { get; set; } = 0f;


        public Block(float x, float y, float width, float height)
        {
            
            Position = new Vector2f(x, y);

            float [] pos = new float [] {
                0.0f, 0.0f,    0f,  0f,  0f,
                0.0f, height,  0f,  0f,  0f,
                width,height,  0f,  0f,  0f,
                width, 0.0f,   0f,  0f,  0f,

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