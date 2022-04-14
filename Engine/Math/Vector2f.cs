namespace Napicu.Engine.Math
{
    public class Vector2f
    {
        public float x { get; set; }
        public float y { get; set; }
        
        public Vector2f() {
            x = 0.0f;
            y = 0.0f;
        }

        public Vector2f(float x, float y) {
            this.x = x;
            this.y = y;
        }
    }
    
}

