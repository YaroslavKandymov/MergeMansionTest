using Cysharp.Threading.Tasks;
using MergeMansion.Enums;

namespace MergeMansion.Interfaces
{
    public interface ISceneLoaderService
    {
        public UniTask GoToScene(CurrentScene scene);
    }
}