using OpenGL;
using static OpenGL.GL;

namespace NapicuEngine.Engine
{

    public class VertexArray
    {
        private uint Vao { get; set; }
        private uint Vbo { get; set; }

        private uint Ibo { get; set; }
        private Shader Shader { get; set; }
        
        public float[] Vertices { get; set; }
        protected int[] _indices { get; set; }
        
        


        public unsafe VertexArray(float[] vertices, int[] indices)
        {
            // Bind buffer, Vao and Vbo and Ibo
            Vertices = vertices;
            
            // Set indices buffer 
            _indices = indices;

            string vertexShader = @"#version 330 core
                                    layout (location = 0) in vec2 aPosition;
                                    layout (location = 1) in vec3 aColor;
                                    out vec3 color;
    
                                    void main() 
                                    {
                                        color = aColor;
                                        gl_Position = vec4(aPosition.xy, 0, 1.0);
                                    }";

            string fragmentShader = @"#version 330 core
                                    out vec4 FragColor;
                                    in vec3 color;

                                    void main() 
                                    {
                                        FragColor = vec4(color, 1.0f);
                                    }";

            Shader = new Shader(vertexShader, fragmentShader);
            Shader.Load();
            

            
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
            Shader.Use();
            
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

