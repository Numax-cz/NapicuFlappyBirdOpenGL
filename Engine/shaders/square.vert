#version 330 core
layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec3 aColor;
out vec3 color;

uniform mat4 AtrPos;
void main()
{
    color = aColor;

    
    gl_Position = vec4(aPosition.xy, 0f, 1f) * AtrPos;
}
