﻿using Greenmaster.TK.Core;
using Greenmaster.TK.Core.Managment;
using Greenmaster.TK.Core.Rendering;
using Greenmaster.TK.Core.Rendering.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Greenmaster.TK.Impl;

public class TextureTest : Game
{
    private const string ShaderFilePath = @"Resources\Shaders\Texture.glsl";
    private const string TextureFilePath = @"Resources\Textures\wall.jpg";

    private readonly float[] _vertices =
    {
        //Positions       //Colors
        0.5f, 0.5f, 0.0f, 1.0f, 1.0f,    //top right
        0.5f, -0.5f, 0.0f, 1.0f, 0.0f,   //bottom right
        -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,  //bottom left
        -0.5f, 0.5f, 0.0f, 0.0f, 1.0f    //top left     
    };
    
    private readonly uint[] _indices =
    {
        0, 1, 3, //first triangle
        1, 2, 3 //second triangle
    };

    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private int _elementBufferObject;

    private Shader _shader;
    private Texture2D _texture;

    public TextureTest(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
    }

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
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices,
            BufferUsageHint.StaticDraw);

        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
        
        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
        
        _texture = ResourseManager.Instance.LoadTexture(TextureFilePath);
        _texture.Use();
    }

    protected override void Render(GameTime gameTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        _shader.Use();
        GL.BindVertexArray(_vertexArrayObject);
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}