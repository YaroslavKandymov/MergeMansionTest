using MergeMansion.Extensions;
using UnityEngine;

namespace MergeMansion.UI.Views
{
    public class UIScreenView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public void Show()
        {
            _canvasGroup.Open();
        }

        public void Hide()
        {
            _canvasGroup.Close();
        }
    }
}