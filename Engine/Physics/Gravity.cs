using Napicu.Engine.Math;
using OpenGL;

namespace Napicu.Engine.Physics
{
    public class Gravity
    {

        
        public static void ApplyGravity(Object meshObject, float GravityForce)
        {
            meshObject.Position.x += meshObject.Velocity.x;
            meshObject.Position.y += meshObject.Velocity.y;
            meshObject.Velocity.y *= GravityForce;
            meshObject.Velocity.x *= GravityForce;
            meshObject.Velocity.y -= GravityForce;
        }
    }
}

