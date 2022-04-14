using Napicu.Engine;
using Object = Napicu.Engine.GameObject;

namespace NapicuGame
{
    public class Renderer
    {
        private List<GameObject> Objects { get; set; }

        public Renderer()
        {
            this.Objects = new List<GameObject>();
        }
        
        public void Add(Object obj)
        {
            this.Objects.Add(obj);
        }
        
        public void Render()
        {
            
            foreach (GameObject obj in this.Objects)
            {
                obj.Render();
            }
        }
    }
}
    