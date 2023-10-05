using OpenTK.Graphics.OpenGL4;

namespace Greenmaster.TK.Core.Rendering.Shaders;

public class Shader
{
    public int ProgramId { get; private set; }
    public bool IsCompiled { get; private set; }
    private readonly ShaderProgramSource _shaderProgramSource;

    public Shader(ShaderProgramSource shaderProgramSource, bool compile = false)
    {
        _shaderProgramSource = shaderProgramSource;
        if (compile) CompileShader();
    }

    public bool CompileShader()
    {
        if (_shaderProgramSource == null)
        {
            Console.WriteLine("Shader Program Source is null!");
            return false;
        }

        if (IsCompiled)
        {
            Console.WriteLine("Shader already compiled!");
            return false;
        }
        var vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderId, _shaderProgramSource.VertexShaderSource);
        GL.CompileShader(vertexShaderId);
        GL.GetShader(vertexShaderId, ShaderParameter.CompileStatus, out var vertexShaderCompilationCode);
        if (vertexShaderCompilationCode != (int)All.True)
        {
            Console.WriteLine(GL.GetShaderInfoLog(vertexShaderId));
            return false;
        }

        var fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderId, _shaderProgramSource.FragmentShaderSource);
        GL.CompileShader(fragmentShaderId);
        GL.GetShader(fragmentShaderId, ShaderParameter.CompileStatus, out var fragmentShaderCompilationCode);
        if (fragmentShaderCompilationCode!= (int)All.True)
        {
            Console.WriteLine(GL.GetShaderInfoLog(fragmentShaderId));
            return false;
        }

        ProgramId = GL.CreateProgram();
        GL.AttachShader(ProgramId, vertexShaderId);
        GL.AttachShader(ProgramId, fragmentShaderId);
        GL.LinkProgram(ProgramId);
        
        GL.DetachShader(ProgramId, vertexShaderId);
        GL.DetachShader(ProgramId, fragmentShaderId);
        
        GL.DeleteShader(vertexShaderId);
        GL.DeleteShader(fragmentShaderId);
        IsCompiled = true;
        return true;
    }

    public static ShaderProgramSource ParseShader(string filePath)
    {
        var shaderSource = new string[2];
        var shaderType = EShaderType.None;
        var allLines = File.ReadAllLines(filePath);
        foreach (var line in allLines)
        {
            var currentLine = line.Trim();
            if (currentLine.ToLower().Contains("#shader"))
            {
                shaderType = ShaderTypeFromString(currentLine);
            }
            else
            {
                shaderSource[(int)shaderType] += currentLine + "\n";
            }
        }
        return new ShaderProgramSource(shaderSource[(int)EShaderType.Vertex], shaderSource[(int)EShaderType.Fragment]);
    }

    private static EShaderType ShaderTypeFromString(string currentLine)
    {
        var shaderType = EShaderType.None;
        
        if (currentLine.ToLower().Contains("vertex"))
        {
            shaderType = EShaderType.Vertex;
        }
        else if (currentLine.ToLower().Contains("fragment"))
        {
            shaderType = EShaderType.Fragment;
        }
        else
        {
            Console.WriteLine("Error: Unknown shader type!");
        }
        return shaderType;
    }

    public void Use()
    {
        if (!IsCompiled)
            Console.WriteLine("Shader is not compiled yet!");
        else
            GL.UseProgram(ProgramId);
    }
}