using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace Greenmaster.TK.Core;

public abstract class Game
{
    protected string WindowTitle { get; set; }
    protected int InitialWindowWidth { get; set; }
    protected int InitialWindowHeight { get; set; }
    
    private readonly GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
    private readonly NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

    public Game(string windowTitle, int initialWindowWidth, int initialWindowHeight)
    {
        WindowTitle = windowTitle;
        InitialWindowWidth = initialWindowWidth;
        InitialWindowHeight = initialWindowHeight;
        _nativeWindowSettings.Size = new Vector2i(InitialWindowWidth, InitialWindowHeight);
        _nativeWindowSettings.Title = WindowTitle;
    }

    public void Run()
    {
        Initialize();
        var gameWindow = new GameWindow(_gameWindowSettings, _nativeWindowSettings);
        var gameTime = new GameTime();
        gameWindow.Load += LoadContent;
        gameWindow.UpdateFrame += (frameEventArgs =>
        {
            var time = frameEventArgs.Time;
            gameTime.ElapsedGameTime = TimeSpan.FromMilliseconds(time);
            gameTime.TotalGameTime += TimeSpan.FromMilliseconds(time);
            Update(gameTime);
        });
        gameWindow.RenderFrame += (frameEventArgs) =>
        {
            Render(gameTime);
            gameWindow.SwapBuffers();
        };
        gameWindow.Resize += (resizeEventArgs) =>
        {
            GL.Viewport(0, 0, gameWindow.Size.X, gameWindow.Size.Y);
        };
        gameWindow.Run(); 
    }
    
    protected abstract void Initialize();
    protected abstract void Update(GameTime gameTime);
    protected abstract void LoadContent();
    protected abstract void Render(GameTime gameTime);
}