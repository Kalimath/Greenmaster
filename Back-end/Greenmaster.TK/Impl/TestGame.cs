using Greenmaster.TK.Core;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Greenmaster.TK.Impl;

public class TestGame : Game
{
    private readonly float[] _vertices = new[]
    {
        -0.5f, -0.5f,  0.0f,    //Bottom left
         0.5f, -0.5f,  0.0f,    //Bottom right
         0.0f,  0.5f,  0.0f     //top
    };
    
    public TestGame(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }
    
    private int _vertexBufferObject;
    private int _vertexArrayObject;
    
    private int _shaderHandle;

    protected override void Initialize()
    {
    }

    protected override void Update(GameTime gameTime)
    {
    }

    protected override void LoadContent()
    {
        const string vertexShaderSource = @"
            #version 330 core
            layout (location = 0) in vec3 aPosition;
            void main()
            {
                gl_Position = vec4(aPosition.xyz, 1.0);
            }";
        var vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderId, vertexShaderSource);
        GL.CompileShader(vertexShaderId);
        GL.GetShader(vertexShaderId, ShaderParameter.CompileStatus, out var vertexShaderCompilationCode);
        if (vertexShaderCompilationCode != (int)All.True) Console.WriteLine(GL.GetShaderInfoLog(vertexShaderId));
        
        var fragmentShader = 
            @"
            #version 330 core
            layout (location = 0) out vec4 color;
            void main()
            {
                color = vec4(1.0, 0.0, 0.0, 1.0);
            }";
        
        var fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderId, fragmentShader);
        GL.CompileShader(fragmentShaderId);
        GL.GetShader(fragmentShaderId, ShaderParameter.CompileStatus, out var fragmentShaderCompilationCode);
        if (fragmentShaderCompilationCode!= (int)All.True) Console.WriteLine(GL.GetShaderInfoLog(fragmentShaderId));

        _shaderHandle = GL.CreateProgram();
        GL.AttachShader(_shaderHandle, vertexShaderId);
        GL.AttachShader(_shaderHandle, fragmentShaderId);
        GL.LinkProgram(_shaderHandle);
        
        GL.DetachShader(_shaderHandle, vertexShaderId);
        GL.DetachShader(_shaderHandle, fragmentShaderId);
        
        GL.DeleteShader(vertexShaderId);
        GL.DeleteShader(fragmentShaderId);
        
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        GL.UseProgram(_shaderHandle);
        GL.BindVertexArray(_vertexArrayObject);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3); //count -> amount of numbers for each vertex
    }
}