using Cysharp.Threading.Tasks;
using MergeMansion.Extensions;
using MergeMansion.Items;
using MergeMansion.Other;
using Zenject;

namespace MergeMansion.Area
{
    public class AreaItemsFiller
    {
        private readonly GridGenerator _gridGenerator;
        private readonly ItemsFactory _factory;
        private readonly int _startCount = 15;

        public AreaItemsFiller(GridGenerator gridGenerator, ItemsFactory factory)
        {
            _gridGenerator = gridGenerator;
            _factory = factory;
        }

        public async UniTask Initialize()
        {
            for (int i = 0; i < _startCount; i++)
            {
                if (_gridGenerator.HaveEmptyPlace == false)
                    return;

                var item = _factory.CreateItem(ItemType.None.GetRandomValue());
                _gridGenerator.TryPutOnGrid(item);
            }

            await UniTask.CompletedTask;
        }

        public void AddItem()
        {
            if (_gridGenerator.HaveEmptyPlace == false)
                return;
            
            var item = _factory.CreateItem(ItemType.None.GetRandomValue());
            _gridGenerator.TryPutOnGrid(item);
        }
    }
}