using Cysharp.Threading.Tasks;
using MergeMansion.StaticData;
using MergeMansion.StringFields;
using UnityEngine;
using Zenject;

namespace MergeMansion.Area
{
    public class AreaCreator
    {
        private readonly AreaFactory _areaFactory;
        private readonly AreaData _areaData;

        public AreaCreator(AreaFactory areaFactory, AreaData areaData)
        {
            _areaFactory = areaFactory;
            _areaData = areaData;
        }

        public async UniTask Initialize()
        {
            var view = _areaFactory.Create();
            await InitializeView(view);
        }

        private async UniTask InitializeView(FloorView view)
        {
            var transform = view.transform;

            transform.localScale = new Vector3(_areaData.Size.x, 
                transform.localScale.y,
                _areaData.Size.y);

            var textureScale = new Vector2(_areaData.Size.x / _areaData.AreaMaterialData.CellsCount, 
                _areaData.Size.y / _areaData.AreaMaterialData.CellsCount);
            
            view.MeshRenderer.material.SetTextureScale(MaterialFields.MainTex, textureScale);

            await UniTask.CompletedTask;
        }
    }
}