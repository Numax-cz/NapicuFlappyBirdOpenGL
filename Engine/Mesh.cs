using NapicuEngine.Engine.Math;
using static OpenGL.GL;

namespace NapicuEngine.Engine
{
    public abstract class Mesh
    {
        protected abstract VertexArray VertexArray { get; set; }
        public abstract Vector2f Position { get; set; }
        protected abstract Shader Shader { get; set; }

        public void Render()
        {
            // Set the shader
            glUseProgram(Shader.ProgramID);
            // Update the position
            UpdatePosition();
            // Render the mesh
            VertexArray.Render();
        }

        protected void UpdatePosition()
        {
            Matrix4f newPost = Matrix4f.translate(new Vector2f(Position.x, Position.y));
            Shader.setUniformMatrix4fv("mMatrix", newPost.elements);
        }
    }

}

