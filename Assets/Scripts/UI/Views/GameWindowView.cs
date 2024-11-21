using UnityEngine;
using UnityEngine.UI;

namespace MergeMansion.UI.Views
{
    public class GameWindowView : UIScreenView
    {
        [SerializeField] private Button _generateButton;

        public Button GenerateButton => _generateButton;
    }
}