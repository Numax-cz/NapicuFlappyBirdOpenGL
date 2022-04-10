using static OpenGL.GL;
namespace NapicuEngine.Engine
{ 
    public class Shader
    {
        private string vertex;
        private string frament;
        public uint Program { get; set; }
        
        public Shader(string vertex, string fragment)  
        {
            this.vertex = vertex;
            this.frament = fragment;
        }

        public void Load()
        {
            uint vs, fs;

            vs = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(vs, vertex);
            glCompileShader(vs);
            
            int[] status =  glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string log = glGetShaderInfoLog(vs);
                Console.WriteLine(log);
                throw new Exception("Vertex shader failed to compile");
            }          
            
            fs = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(fs, frament);
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
            glDeleteShader(vs);
            glDeleteShader(fs);
        }

        public void Use()
        {
            glUseProgram(Program);
        }

    }
}

