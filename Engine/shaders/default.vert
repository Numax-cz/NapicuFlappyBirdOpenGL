#version 330 core
layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec3 aColor;
layout (location = 2) in vec2 aTexCoords;

out vec3 color;
out vec2 texCoords;

uniform mat4 mMatrix = mat4(1.0);
uniform mat4 pMatrix = mat4(1.0);
uniform mat4 vMatrix = mat4(1.0);
void main()
{
    //Resizezing the texture by mMatrix and pMatrix
    
    
    
    
    color = aColor;
    texCoords = aTexCoords;
    gl_Position = pMatrix * vMatrix * mMatrix * vec4(aPosition, 0.0, 1.0);
    
}
