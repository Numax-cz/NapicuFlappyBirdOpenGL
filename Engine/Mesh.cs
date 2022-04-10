using NapicuEngine.Engine.Math;

namespace NapicuEngine.Engine
{
    public abstract class Mesh
    {
        protected abstract VertexArray VertexArray { get; set; }
        protected abstract Vector2f Position  { get; set; }

        public void Render()
        {
            VertexArray.Render();
        }
    }

}

