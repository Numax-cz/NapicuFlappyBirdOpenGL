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
        protected int[] Indices { get; set; }

        


        public unsafe VertexArray(float[] vertices, int[] indices)
        {
  
            // Bind buffer, Vao and Vbo and Ibo
            Vertices = vertices;
            
            // Set indices buffer 
            Indices = indices;

            
            //Generate 
            Vao = glGenVertexArray();
            Vbo = glGenBuffer();
            Ibo = glGenBuffer();

            // Generate the VAO and VBO
            glBindVertexArray(Vao);
            // Bind the VBO
            glBindBuffer(GL_ARRAY_BUFFER, Vbo);
            // Bind Ibo
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);

       
            
            // Set data to Vbo
            fixed (float* i = &vertices[0])
            {
               glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, i, GL_STATIC_DRAW);
            }

            // Set data to Ibo
            fixed (int* i = &indices[0])
            {
                glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(float) * indices.Length, i, GL_STATIC_DRAW);
            }


                

            // Set vertex attribute pointers
            glVertexAttribPointer(0, 2, GL_FLOAT, false, 7 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);

            // Set indices attribute pointer
            glVertexAttribPointer(1, 3, GL_FLOAT, false, 7 * sizeof(float), (void*)(3* sizeof(float)));
            glEnableVertexAttribArray(1);
            
            // Set Texcoords attribute pointers
            glVertexAttribPointer(2, 2, GL_FLOAT, false, 7 * sizeof(float), (void*)(6 * sizeof(float)));
            glEnableVertexAttribArray(2);

           
  
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
            glDrawElements(GL_TRIANGLES, Indices.Length, GL_UNSIGNED_INT, (void*)0);
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

