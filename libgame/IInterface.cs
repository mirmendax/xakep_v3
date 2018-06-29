using System;
using System.Windows.Forms;
namespace libgame
{
    public interface IInitialized
    {
        void Initialize();
    }

    public interface IQuest
    {
        void CheckedComplete(GameScript handle);
    }

    public interface IEventX
    {
        ResponseData CheckedEvent(GameScript handle);
    }

    public interface IFileX
    {
        string Name { get; set; }
        ResponseData Run(GameScript handleGame, string[] args);
    }
}
