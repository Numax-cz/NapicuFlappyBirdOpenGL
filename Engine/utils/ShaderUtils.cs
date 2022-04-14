
using System.Runtime.CompilerServices;

using static OpenGL.GL;
namespace Napicu.Engine.utils
{ 
    public class ShaderUtils
    {
        protected static readonly string defaultFolder = @"Engine/shaders/";
        protected static string Vertex;
        protected static string Fragment;
        protected static uint Program;
        

        public static uint Load(string vert, string frag)
        {

            //TODO catch errors
            Vertex = System.IO.File.ReadAllText(defaultFolder + vert);
            Fragment = System.IO.File.ReadAllText(defaultFolder + frag);
            
            uint vs, fs;

            vs = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(vs, Vertex);
            glCompileShader(vs);
                
            int[] status =  glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string log = glGetShaderInfoLog(vs);
                Console.WriteLine(log);
                throw new Exception("Vertex shader failed to compile");
            }          
                
            fs = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(fs, Fragment);
            glCompileShader(fs);

            status =  glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string log = glGetShaderInfoLog(vs);
                Console.WriteLine(log);
                throw new Exception("Fragment shader failed to compile");
            }  
            
            Program = glCreateProgram();
            glAttachShader(Program, vs);
            glAttachShader(Program, fs);
                
            glLinkProgram(Program);
            
            glDetachShader(Program, vs);
            glDetachShader(Program, fs);
            glValidateProgram(Program);
            glDeleteShader(vs);
            glDeleteShader(fs);
            
            return Program;
        }
        

    }

}