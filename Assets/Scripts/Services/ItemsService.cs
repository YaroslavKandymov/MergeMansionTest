using System;
using MergeMansion.Extensions;
using MergeMansion.Interfaces;
using MergeMansion.Items;
using MergeMansion.Other;
using UnityEngine;
using Zenject;

namespace MergeMansion.Services
{
    public class ItemsService : IInitializable, IDisposable
    {
        private readonly ItemsMover _itemsMover;
        private readonly GridGenerator _gridGenerator;
        private readonly ItemsUnifier _unifier;

        public ItemsService(ItemsMover itemsMover, GridGenerator gridGenerator, ItemsUnifier unifier)
        {
            _itemsMover = itemsMover;
            _gridGenerator = gridGenerator;
            _unifier = unifier;
        }

        void IInitializable.Initialize()
        {
            _itemsMover.Released += OnReleased;
        }

        void IDisposable.Dispose()
        {
            _itemsMover.Released -= OnReleased;
        }

        private void OnReleased(ITakeble takeble)
        {
            if (takeble is not ItemView view)
                return;

            var position = takeble.Transform.position.ConvertToVector3Int();

            var item = _gridGenerator.GetItem(position);

            if (item == null)
            {
                HandleEmptyGridPosition(position, view);
            }
            else
            {
                HandleBusyGridPosition(view, item, position);
            }
        }

        private void HandleEmptyGridPosition(Vector3Int position, ItemView view)
        {
            if (_gridGenerator.TryPutOnGrid(position, view))
            {
                _gridGenerator.RemoveItem(_itemsMover.GetStartPosition().ConvertToVector3Int());
            }
            else
            {
                _itemsMover.ReturnItem(view);
            }
        }

        private void HandleBusyGridPosition(ItemView view, ItemView item, Vector3Int position)
        {
            if (view.ItemType == item.ItemType)
            {
                var newItem = _unifier.TryUnite(view, item);

                if (newItem == null)
                {
                    _itemsMover.ReturnItem(view);
                }
                else
                {
                    _gridGenerator.TryPutOnGrid(position, newItem);
                    _gridGenerator.RemoveItem(_itemsMover.GetStartPosition().ConvertToVector3Int());
                }
            }
            else
            {
                _itemsMover.ReturnItem(view);
            }
        }
    }
}