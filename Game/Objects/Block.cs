using Napicu.Engine;
using Napicu.Engine.Math;

namespace NapicuGame.Objects{
    
    public class Block : GameObject
    {
        
        protected override Shader Shader { get; set; } = new Shader("default.vert", "default.frag");
        protected override VertexArray Mesh { get; set; }
        public sealed override Vector2f Position { get; set; }
        protected override float GravityForce { get; set; } = 0f;
        protected override Texture Texture { get; set; } = new Texture("D:/Dokumenty/NapicuEngine/Game/assets/wall.png");

        public Block(float x, float y, float width, float height)
        {
            Position = new Vector2f(x, y);

            float [] pos = new float [] {
                // positions          // colors           // texture coords
                width,  height, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f,   // top right
                width, -height, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,   // bottom right
                -width, -height, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f,   // bottom left
                -width,  height, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f    // top left 
            };

            int[] ints = new[]
            {
                0, 1, 3,
                1, 2, 3
            };
            


           
            
            Mesh = new VertexArray(pos, ints);
        }
        

    }
}