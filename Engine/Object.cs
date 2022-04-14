using Napicu.Engine.Math;
using Napicu.Engine.Physics;
using static OpenGL.GL;

namespace Napicu.Engine
{
    public abstract class Object
    {
        protected abstract VertexArray Mesh { get; set; }
        public abstract Vector2f Position { get; set; }
        protected abstract Shader Shader { get; set; }
        protected abstract float GravityForce { get; set; }
        public Vector2f Velocity { get; set; }
        
        protected Object()
        {
            Velocity = new Vector2f(0, 0);
        }
        
        public void Render()
        {
            
            // Set the shader
            glUseProgram(Shader.ProgramID);
            
            Shader.setUniformMatrix4fv("pMatrix", DisplayManager.Camera.GetProjection().elements);
            Shader.setUniformMatrix4fv("vMatrix", DisplayManager.Camera.GetViewMatrix().elements);
            
            // Gravity
            Gravity.ApplyGravity(this, this.GravityForce);
            // Update the position
            UpdatePosition();
            // Render the mesh
            Mesh.Render();
        }

        protected void UpdatePosition()
        {
            Matrix4f newPost = Matrix4f.Translate(new Vector2f(Position.x, Position.y));
            Shader.setUniformMatrix4fv("mMatrix", newPost.elements);
        }

        public void SetPrMatrix(Matrix4f matrix)
        {
            Shader.setUniformMatrix4fv("pMatrix", matrix.elements);
        }

    }

}

