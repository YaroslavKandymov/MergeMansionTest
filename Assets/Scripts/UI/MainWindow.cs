using MergeMansion.UI.Views;
using UnityEngine;

namespace MergeMansion.UI
{
    public class MainWindow : MonoBehaviour
    {
        [SerializeField] private UIScreenView[] _windows;

        public T GetWindow<T>() where T : UIScreenView
        {
            for (int i = 0, count = _windows.Length; i < count; i++)
            {
                if (_windows[i] is T result)
                {
                    return result;
                }
            }

            return null;
        }
    }
}