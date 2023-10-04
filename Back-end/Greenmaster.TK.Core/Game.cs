using OpenTK.Windowing.Desktop;

namespace Greenmaster.TK.Core;

public abstract class Game
{
    protected string WindowTitle { get; set; }
    protected int InitialWindowWidth { get; set; }
    protected int InitialWindowHeight { get; set; }
    
    private GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
    private NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

    public Game(string windowTitle, int initialWindowWidth, int initialWindowHeight)
    {
        WindowTitle = windowTitle;
        InitialWindowWidth = initialWindowWidth;
        InitialWindowHeight = initialWindowHeight;
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
        gameWindow.Run(); 
    }
    
    protected abstract void Initialize();
    protected abstract void Update(GameTime gameTime);
    protected abstract void LoadContent();
    protected abstract void Render(GameTime gameTime);
}