namespace Greenmaster.TK.Core.Rendering.Shaders;

public class ShaderProgramSource
{
    public string VertexShaderSource { get; set; }
    public string FragmentShaderSource { get; set; }
    
    public ShaderProgramSource(string vertexShaderSource, string fragmentShaderSource)
    {
        VertexShaderSource = vertexShaderSource;
        FragmentShaderSource = fragmentShaderSource;
    }
    
}