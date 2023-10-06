using OpenTK.Graphics.OpenGL4;

namespace Greenmaster.TK.Core.Rendering;

public class Texture2D : IDisposable
{
    public int Handle { get; private set; }
    private bool _disposed;
    
    public Texture2D(int handle) {
        Handle = handle;
    }
    
    ~Texture2D() {
        Dispose(false);
    }

    public void Use() {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, Handle);
    }

    public void Dispose(bool disposing) {
        if (!_disposed)
        {
            GL.DeleteTexture(Handle);
            _disposed = true;
        }
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}