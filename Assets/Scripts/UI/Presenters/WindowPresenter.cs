using Cysharp.Threading.Tasks;
using MergeMansion.UI.Views;

namespace MergeMansion.UI.Presenters
{
    public class WindowPresenter<T> where T : UIScreenView
    {
        protected T View { get;}

        protected WindowPresenter(MainWindow mainWindow)
        {
            View = mainWindow.GetWindow<T>();
        }

        public virtual async UniTask Enable()
        {
            View.Show();

            await UniTask.CompletedTask;
        }

        public async virtual UniTask Disable()
        {
            View.Hide();
            
            await UniTask.CompletedTask;
        }
    }
}