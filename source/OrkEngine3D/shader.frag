﻿#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec2 fUV;
in vec3 Pos;

uniform sampler2D mat_texture0;
uniform sampler2D mat_texture1;
uniform vec3 camera_pos;

struct Light{
    float strength;
    vec3 color;
    vec3 position;
};


uniform Light ambient;
uniform Light light;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float shininess;
};
  
uniform Material material;

void main()
{   
    vec3 objectColor = texture(mat_texture0, fUV).rgb;

    vec3 ambient = (ambient.color * ambient.strength) * material.ambient;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - Pos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = (light.color * light.strength) * (diff * material.diffuse);
    
    // specular
    vec3 viewDir = normalize(camera_pos - Pos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = (light.color * light.strength) * (spec * material.specular);  
        
    vec3 result = (ambient + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
}