using Napicu.Engine.Math;
using Napicu.Engine.Physics;
using static OpenGL.GL;

namespace Napicu.Engine
{
    public abstract class GameObject
    {
        protected abstract VertexArray Mesh { get; set; }
        public abstract Vector2f Position { get; set; }
        protected abstract Shader Shader { get; set; }
        protected abstract float GravityForce { get; set; }
        public Vector2f Velocity { get; set; }
        
        protected abstract Texture Texture { get; set; }
        
        
        
        
        protected GameObject()
        {
            Velocity = new Vector2f(0, 0);
            
        }
        
        public void Render()
        {
            glUseProgram(Shader.ProgramID);
            glActiveTexture( GL_TEXTURE0 );
            glBindTexture( GL_TEXTURE_2D, Texture.Id );
            
            Shader.setUniformMatrix4fv("pMatrix", DisplayManager.Camera.GetProjection().elements);
            Shader.setUniformMatrix4fv("vMatrix", DisplayManager.Camera.GetViewMatrix().elements);
            //
            
            
            // Gravity
            Gravity.ApplyGravity(this, this.GravityForce);
            // Update the position
            UpdatePosition();
            // Render the mesh
            Mesh.Render();
        }

        protected void UpdatePosition()
        {
            Matrix4f newPost = Matrix4f.Translate(new Vector2f(Position.x, Position.y)); //TODO AL
            Shader.setUniformMatrix4fv("mMatrix", newPost.elements);
        }

        public void SetPrMatrix(Matrix4f matrix)
        {
            Shader.setUniformMatrix4fv("pMatrix", matrix.elements);
        }

    }

}

