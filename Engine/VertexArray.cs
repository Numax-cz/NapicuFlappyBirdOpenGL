using OpenGL;
using static OpenGL.GL;

namespace NapicuEngine.Engine
{

    public class VertexArray
    {
        public uint Vao { get; set; }
        public uint Vbo { get; set; }

        public uint Ibo { get; set; }

        public float[] Vertices { get; set; }
        protected int[] _indices { get; set; }

        


        public unsafe VertexArray(float[] pos, int[] indices)
        {
            // Bind buffer, Vao and Vbo and Ibo
            Vertices = pos;
            
            // Set indices buffer 
            _indices = indices;

            Vao = glGenVertexArray();
            Vbo = glGenBuffer();
            Ibo = glGenBuffer();

            // Generate the VAO and VBO
            glBindVertexArray(Vao);
            glBindBuffer(GL_ARRAY_BUFFER, Vbo);

            // Bind Ibo
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);

            // Set data to Vbo
            fixed (float* v = &pos[0])
            {
               glBufferData(GL_ARRAY_BUFFER, sizeof(float) * pos.Length, v, GL_STATIC_DRAW);
            }

            // Set data to Ibo
            fixed (int* i = &indices[0])
            {
                glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(int) * indices.Length, i, GL_STATIC_DRAW);
            }

            // Set vertex attribute pointers
            glEnableVertexAttribArray(0);
            glVertexAttribPointer(0, 2, GL_FLOAT, false, 0, (void*)0);


            // Unbind Vbo
            glBindBuffer(GL_ARRAY_BUFFER, 0);
            // Unbind Ibo
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);
            // Unbind Vao
            glBindVertexArray(0);
        }

        protected void Bind()
        {
            glBindVertexArray(Vao);
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);
        }

        protected void UnBind()
        {
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
        }

        protected unsafe void Draw()
        {
            //Render the mesh 
            glBindVertexArray(Vao);
            glDrawElements(GL_TRIANGLES, _indices.Length, GL_UNSIGNED_INT, (void*)0);
            glBindVertexArray(0);

            // glBindVertexArray(Vao);
            // glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);
            // glDrawElements(GL_TRIANGLES, _indices.Length , GL_UNSIGNED_BYTE, (void*)0);
            //glBindVertexArray(0);

        }

        public void Render()
        {
            Bind();
            Draw();
        }
    }
}   

