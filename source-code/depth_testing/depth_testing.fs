#version 330 core
out vec4 FragColor;

in vec2 TexCoords;
in vec4 FragPos;

uniform sampler2D texture1;

uniform float near; 
uniform float far; 

float LinearizeDepth(float depth) 
{
    float z = depth * 2.0 - 1.0; // back to NDC 
    return (2.0 * near * far) / (far + near - z * (far - near));
   //z = z * gl_FragCoord.w;//还原其次除法
    //return ((-2.0 * near * far) - z*(far - near))/(far + near);
}

void main()
{    
    //FragColor = texture(texture1, TexCoords);
    //FragColor = vec4(vec3(gl_FragCoord.z), 1.0);

    float depth = LinearizeDepth(gl_FragCoord.z) / far; // divide by far for demonstration
    FragColor = vec4(depth,0,0, 1.0);
}