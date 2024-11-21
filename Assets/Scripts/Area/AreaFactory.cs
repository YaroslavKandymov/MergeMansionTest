using MergeMansion.StaticData;
using Zenject;

namespace MergeMansion.Area
{
    public class AreaFactory
    {
        private readonly DiContainer _diContainer;
        private readonly AreaData _areaData;

        public AreaFactory(DiContainer diContainer, AreaData areaData)
        {
            _diContainer = diContainer;
            _areaData = areaData;
        }

        public FloorView Create()
        {
            return _diContainer.InstantiatePrefabForComponent<FloorView>(_areaData.FloorView);
        }
    }
}