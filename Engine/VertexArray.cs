using GLFW;
using Napicu.Engine.utils;
using OpenGL;
using static OpenGL.GL;

namespace Napicu.Engine
{

    public class VertexArray
    {
        private uint Vao { get; set; }
        private uint Vbo { get; set; }

        private uint Ibo { get; set; }
        public float[] Vertices { get; set; }
        protected int[] _indices { get; set; }
        protected uint _textureId { get; set; }

        


        public unsafe VertexArray(float[] vertices, int[] indices)
        {
            // Bind buffer, Vao and Vbo and Ibo
            Vertices = vertices;
            
            // Set indices buffer 
            _indices = indices;

            
            //Generate 
            Vao = glGenVertexArray();
            Vbo = glGenBuffer();
            Ibo = glGenBuffer();

            // Generate the VAO and VBO
            glBindVertexArray(Vao);
            glBindBuffer(GL_ARRAY_BUFFER, Vbo);

            // Bind Ibo
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);

            // Set data to Vbo
            fixed (float* v = &vertices[0])
            {
               glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
            }

            // Set data to Ibo
            fixed (int* i = &indices[0])
            {
                glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(int) * indices.Length, i, GL_STATIC_DRAW);
            }

            // Set vertex attribute pointers
            glVertexAttribPointer(0, 2, GL_FLOAT, false, 5 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);

            glVertexAttribPointer(1, 3, GL_FLOAT, false, 5 * sizeof(float), (void*)(2 * sizeof(float)));
            glEnableVertexAttribArray(1);

//            glActiveTexture(GL_TEXTURE0);

            
            
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
            if(Ibo > 0) glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);
        }

        protected void UnBind()
        {
            if(Ibo > 0) glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);
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

