using System.Numerics;
using NapicuEngine.Engine.Math;
using NapicuEngine.Engine.utils;
using static OpenGL.GL;
namespace NapicuEngine.Engine;

public class Shader
{
    public uint ProgramID { get;  set; }

    private Dictionary<String, int> _locationCache = new Dictionary <String, int>();
    
    public int getUniform(String name) {
        if (_locationCache.ContainsKey(name))
            return _locationCache[name];      
		
        int result = glGetUniformLocation(ProgramID, name);
        if (result == -1) 
            Console.Error.WriteLine("Shader error uniform: '" + name + "'!");
        else
            _locationCache.Add(name, result);
        return result;
    }
    
    public void setUniform2f(String name) //TODO RENAME
    {

        //TODO HERE
        // var i =  Matrix4f.translate(new Vector2f(-0.5f, -0.5f));
        // glUniformMatrix4fv(getUniform(name), 1, false, i.elements);
        
        //glUniformMat4f(getUniform(name), 0.5f, 0.5f);
    }

    
    
    public Shader(string vertex, string fragment)
    {
        this.ProgramID = ShaderUtils.Load(vertex, fragment);
    }
    
}