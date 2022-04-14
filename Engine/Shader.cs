using System.Numerics;
using NapicuEngine.Engine.Math;
using NapicuEngine.Engine.utils;
using static OpenGL.GL;
namespace NapicuEngine.Engine;

public class Shader
{
    public uint ProgramID { get;  set; }
    protected bool Enabled { get; set; }

    private Dictionary<String, int> _cache = new Dictionary <String, int>();
    
    public int getUniform(String name) {
        if (_cache.ContainsKey(name))
            return _cache[name];      
		
        int result = glGetUniformLocation(ProgramID, name);
        if (result == -1) 
            Console.Error.WriteLine("Shader error uniform: '" + name + "'!");
        else
            _cache.Add(name, result);
        return result;
    }
    
    public void setUniformMatrix4fv(string name, float[] elements)
    {
        if (!Enabled) Enable();
        glUniformMatrix4fv(getUniform(name), 1, false, elements);
    }

    public Shader(string vertex, string fragment)
    {
        this.ProgramID = ShaderUtils.Load(vertex, fragment);
    }
    
    public void Enable()
    {
        glUseProgram(ProgramID);
        Enabled = true;
    }
    
    public void Disable()
    {
        glUseProgram(0);
        Enabled = false;
    }
    
}