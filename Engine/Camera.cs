using Napicu.Engine.Math;

namespace Napicu.Engine
{
    
    public class Camera
    {
        private Matrix4f  projectionMatrix, viewMatrix;
        public Vector2f Position;

        public Camera(Vector2f position)
        {
            Position = position;
            this.projectionMatrix = new Matrix4f();

        }
        
        public Matrix4f GetProjection()
        {
            projectionMatrix =  Matrix4f.Orthographic(0.0f, 1920, 0.0f, 1080, 0.0f, 100.0f);
            return projectionMatrix;
        }

        public Matrix4f GetViewMatrix()
        {
            viewMatrix = Matrix4f.Translate(Position);
            return viewMatrix;
        }

    }
}

