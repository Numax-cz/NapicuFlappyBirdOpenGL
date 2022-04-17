#version 330 core

out vec4 FragColor;
in vec3 color;
in vec2 texCoords;

uniform sampler2D tex;

void main()
{

    vec4 tex_color = texture(tex, texCoords);
    FragColor = tex_color;
}