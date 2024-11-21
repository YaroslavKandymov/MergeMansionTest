using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace MergeMansion.Other
{
    public class UserInput : IInitializable
    {
        public event Action MouseDownClicked;
        public event Action MouseUpClicked;
        
        void IInitializable.Initialize()
        {
           StartWork().Forget();
        }

        private async UniTaskVoid StartWork()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    MouseDownClicked?.Invoke();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    MouseUpClicked?.Invoke();
                }

                await UniTask.Yield();
            }
        }
    }
}