using OpenGL;
using static OpenGL.GL;

namespace NapicuEngine.Engine
{
    
    public class VertexArray
    {
        public uint Vao { get; set; }
        public uint Vbo { get; set; }
        
        public uint Ibo { get; set; }



    public unsafe VertexArray(float[] pos, int[] indices)
        {
    
            Vao = glGenVertexArray();
            Vbo = glGenBuffer();
            glBindVertexArray(Vao);
            glBindBuffer(GL_ARRAY_BUFFER, Vbo);
            
            fixed (float* v = &pos[0])
            {
                glBufferData(GL_ARRAY_BUFFER,  6* 2* sizeof(float) * pos.Length,v, GL_STATIC_DRAW);
            }
            glVertexAttribPointer(0, 2, GL_FLOAT, false, 5 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);
            
            glVertexAttribPointer(1, 3, GL_FLOAT, false, 5 * sizeof(float), (void*)(2 * sizeof(float)));
            glEnableVertexAttribArray(1);
            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
            


        }



        public void Draw()
        {
            glBindVertexArray(Vao);
            glDrawArrays(GL_TRIANGLES, 0, 6);
            glBindVertexArray(0);
        }
    }
}

