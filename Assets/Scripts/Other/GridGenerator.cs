using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MergeMansion.Items;
using MergeMansion.StaticData;
using UnityEngine;

namespace MergeMansion.Other
{
    public class GridGenerator
    {
        private readonly Dictionary<Vector3Int, ItemView> _collisionsMatrix;

        private readonly AreaData _areaData;

        public bool HaveEmptyPlace => HasPlace();

        public GridGenerator(AreaData areaData)
        {
            _areaData = areaData;

            _collisionsMatrix = new();
        }

        public async UniTask Initialize()
        {
            await CreateGrid();
        }
        
        public void TryPutOnGrid(ItemView template)
        {
            if (template == null)
                return;
            
            if(HasPlace() == false)
                return;

            var gridPosition = GetRandomPositionOnGrid();
            PutOnGrid(gridPosition, template);
        }

        public bool TryPutOnGrid(Vector3Int gridPosition, ItemView template)
        {
            if (template == null)
                return false;
            
            if(HasPlace() == false)
                return false;

            if(_collisionsMatrix.ContainsKey(gridPosition) == false)
                return false;
            
            PutOnGrid(gridPosition, template);

            return true;
        }

        public ItemView GetItem(Vector3Int position)
        {
            return (from pair in _collisionsMatrix where pair.Key == position select pair.Value).FirstOrDefault();
        }

        public void RemoveItem(Vector3Int position)
        {
            if(_collisionsMatrix.ContainsKey(position) == false)
                return;
            
            _collisionsMatrix[position] = null;
        }

        private void PutOnGrid(Vector3Int gridPosition, ItemView template)
        {
            _collisionsMatrix[gridPosition] = template;

            var position = GridToWorldPosition(gridPosition);
            var transform = template.transform;

            var targetPosition = new Vector3(position.x, gridPosition.y, position.z);

            transform.position = targetPosition;
        }

        private Vector3Int GetRandomPositionOnGrid()
        {
            var nullValueKeys = _collisionsMatrix
                .Where(pair => pair.Value == null)
                .Select(pair => pair.Key)
                .ToList();
            
            return nullValueKeys
                .OrderBy(x => Random.value)
                .First(); 
        }

        private async UniTask CreateGrid()
        {
            for (int i = -_areaData.Size.x / 2; i < _areaData.Size.x / 2 + 1; i++)
            {
                for (int j = -_areaData.Size.y / 2; j < _areaData.Size.y / 2 + 1; j++)
                {
                    _collisionsMatrix.Add(new Vector3Int(i, 0, j), null);
                }
            }

            await UniTask.CompletedTask;
        }

        private bool HasPlace()
        {
            return _collisionsMatrix.Any(i => i.Value == null);
        }

        private Vector3 GridToWorldPosition(Vector3Int gridPosition)
        {
            return new Vector3(
                gridPosition.x * _areaData.CellSize,
                gridPosition.y * _areaData.CellSize,
                gridPosition.z * _areaData.CellSize);
        }

        private Vector3Int WorldToGridPosition(Vector3 worldPosition)
        {
            return new Vector3Int(
                (int) (worldPosition.x / _areaData.CellSize),
                (int) (worldPosition.y / _areaData.CellSize),
                (int) (worldPosition.z / _areaData.CellSize));
        }
    }
}