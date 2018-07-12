
namespace BrSoftNet.App.UI.Win.Security.AutenticationSession
{
    public interface IWorkSession : ICommand
    {
        AppSession Session { get; set; }
    }
}
