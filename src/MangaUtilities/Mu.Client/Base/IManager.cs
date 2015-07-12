namespace Mu.Client.Base
{
    public interface IManager
    {
        IActionResult Execute(IAction action);
    }
}
