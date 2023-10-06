using Greenmaster.TK.Core.Managment.Textures;
using Greenmaster.TK.Core.Rendering;

namespace Greenmaster.TK.Core.Managment;

public sealed class ResourseManager
{
    private static ResourseManager _instance = null!;
    private static readonly object Lock = new();
    private IDictionary<string, Texture2D> _textureCache = new Dictionary<string, Texture2D>();

    public static ResourseManager Instance {
        get {
            lock (Lock) {
                if (_instance == null) {
                    _instance = new ResourseManager();
                }
                return _instance;
            }
        }
    }

    public Texture2D LoadTexture(string textureName)
    {
        _textureCache.TryGetValue(textureName, out var value);
        if (value is not null) return value;
        value = TextureFactory.Load(textureName);
        _textureCache.Add(textureName, value);
        return value;
    }
}