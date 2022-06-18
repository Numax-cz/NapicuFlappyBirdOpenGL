using Napicu.Engine.Math;
using Napicu.Engine.Physics;
using static OpenGL.GL;

namespace Napicu.Engine
{
    public abstract class GameObject
    {
        protected abstract VertexArray Mesh { get; set; }
        public Vector2f Position { get; set; }
        public float Rotate { get; set; } = 0;
        protected  Shader Shader { get; set; } = new Shader("default.vert", "default.frag");
        protected abstract float GravityForce { get; set; }
        public Vector2f Velocity { get; set; }
        protected abstract float VelocityForce { get; set; }
        
        protected abstract Texture Texture { get; set; }

    


        protected GameObject()
        {
            Velocity = new Vector2f(0, 0);
            
        }

        protected virtual void OnUpdate()
        {
            
        }
        
        public void Render()
        {
            glUseProgram(Shader.ProgramID);
            glActiveTexture( GL_TEXTURE0 );
            glBindTexture( GL_TEXTURE_2D, Texture.Id );
            
            Shader.setUniformMatrix4fv("pMatrix", DisplayManager.Camera.GetProjection().elements);
            Shader.setUniformMatrix4fv("vMatrix", DisplayManager.Camera.GetViewMatrix().elements);
            
            // Gravity
            Gravity.ApplyGravity(this, this.GravityForce);
            // Update the position
            UpdatePosition();
            // Update
            this.OnUpdate();
            // Render the mesh
            Mesh.Render();
        }

        protected void UpdatePosition()
        {
            Matrix4f newPost = Matrix4f.Translate(new Vector2f(Position.x, Position.y)).And(Matrix4f.Rotate(this.Rotate));
            Shader.setUniformMatrix4fv("mMatrix", newPost.elements);
        }

        public void SetX(int x)
        {
            this.Position.x = x;
        }

        public void SetY(int y)
        {
            this.Position.y = y;
        }

        public void SetXY(int x, int y)
        {
            this.SetX(x);
            this.SetY(y);
        }

    }

}

