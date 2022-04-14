#version 330 core
layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec3 aColor;
out vec3 color;

uniform mat4 mMatrix;
uniform mat4 pMatrix = mat4(1.0);
uniform mat4 vMatrix = mat4(1.0);
void main()
{
    color = aColor;
    
    gl_Position = pMatrix * vMatrix * mMatrix * vec4(aPosition, 0.0, 1.0);
    
}
