using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MergeMansion.Interfaces;
using MergeMansion.Other;
using MergeMansion.StaticData;
using UnityEngine;
using Zenject;

namespace MergeMansion.Items
{
    public class ItemsMover : IInitializable, IDisposable
    {
        private readonly ItemMoverData _itemMoverData;
        private readonly InputRayCaster _inputRayCaster;
        private readonly Camera _camera;
        private readonly UserInput _userInput;

        private ITakeble _currentItem;
        
        private RaycastHit _hit;
        private bool _isWorking;
        private Vector3 _startPosition;

        public event Action<ITakeble> Released;

        public ItemsMover(ItemMoverData itemMoverData, 
            InputRayCaster inputRayCaster, 
            Camera camera, 
            UserInput userInput)
        {
            _itemMoverData = itemMoverData;
            _inputRayCaster = inputRayCaster;
            _camera = camera;
            _userInput = userInput;
        }

        void IInitializable.Initialize()
        {
            _userInput.MouseDownClicked += OnMouseDownClicked;
            _userInput.MouseUpClicked += OnMouseUpClicked;

            _isWorking = true;
            StartWork().Forget();
        }
        
        void IDisposable.Dispose()
        {
            _userInput.MouseDownClicked -= OnMouseDownClicked;
            _userInput.MouseUpClicked -= OnMouseUpClicked;
        }

        public Vector3 GetStartPosition()
        {
            return _startPosition;
        }

        public void ReturnItem(ITakeble takeble)
        {
            takeble.Transform.DOLocalMove(_startPosition, _itemMoverData.MoveTime).SetEase(_itemMoverData.Ease);
        }

        private void OnMouseDownClicked()
        {
            var cast = _inputRayCaster.CastRay(ref _hit);

            if(cast == false)
                return;

            if (_hit.collider.TryGetComponent(out ITakeble item))
            {
                _currentItem = item;
                _startPosition = _currentItem.Transform.position;
            }
        }

        private void OnMouseUpClicked()
        {
            Released?.Invoke(_currentItem);

            _currentItem = null;
        }

        private async UniTaskVoid StartWork()
        {
            while (_isWorking)
            {
                if (_currentItem != null)
                {
                    var position = new Vector3(Input.mousePosition.x, 
                        Input.mousePosition.y,
                        _camera.WorldToScreenPoint(_currentItem.Transform.position).z);
                    
                    var worldPosition = _camera.ScreenToWorldPoint(position);

                    _currentItem.Transform.position =
                        new Vector3(worldPosition.x, 
                            _itemMoverData.Height, 
                            worldPosition.z + _itemMoverData.HorizontalOffset);
                }

                await UniTask.Yield();
            }
        }
    }
}