namespace SeaBattleWPF.Core.Services
{
    public interface INavigationService
    {
        void GoForward();

        void GoBack();

        bool Navigate(string page);
    }
}
