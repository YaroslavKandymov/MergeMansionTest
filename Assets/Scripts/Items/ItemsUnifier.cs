using MergeMansion.StaticData;

namespace MergeMansion.Items
{
    public class ItemsUnifier
    {
        private readonly ItemsHierarchy _itemsHierarchy;
        private readonly ItemsFactory _factory;

        public ItemsUnifier(ItemsHierarchy itemsHierarchy, ItemsFactory factory)
        {
            _itemsHierarchy = itemsHierarchy;
            _factory = factory;
        }

        public ItemView TryUnite(ItemView uniteObject, ItemView targetObject)
        {
            var nextItem = _itemsHierarchy.GetNextItem(targetObject.ItemType);

            if (nextItem == ItemType.None)
            {
                return null;
            }
            
            _factory.Destroy(uniteObject.gameObject);
            _factory.Destroy(targetObject.gameObject);

            return _factory.CreateItem(nextItem);
        }
    }
}