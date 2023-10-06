using Greenmaster.TK.Core;
using Greenmaster.TK.Core.Rendering.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Greenmaster.TK.Impl;

public class TestGame : Game
{
    private const string ShaderFilePath = @"Resources\Shaders\Default.glsl";

    private readonly float[] _vertices = new[]
    {
        //positions
        -0.5f, -0.5f,  0.0f, 1.0f, 0.0f, 0.0f,  //Bottom left red
         0.5f, -0.5f,  0.0f, 0.0f, 1.0f, 0.0f,  //Bottom right green
         0.0f,  0.5f,  0.0f, 0.0f, 0.0f, 1.0f   //top blue
    };
    
    public TestGame(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }
    
    private int _vertexBufferObject;
    private int _vertexArrayObject;
    
    private Shader _shader;
    
    private int _shaderHandle;

    protected override void Initialize()
    {
    }

    protected override void Update(GameTime gameTime)
    {
    }

    protected override void LoadContent()
    {
        _shader = new Shader(Shader.ParseShader(ShaderFilePath), true);
        
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        _shader.Use();
        GL.BindVertexArray(_vertexArrayObject);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3); //count -> amount of numbers for each vertex
    }
}