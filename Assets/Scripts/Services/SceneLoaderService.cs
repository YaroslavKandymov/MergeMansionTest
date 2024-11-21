﻿using System;
using Cysharp.Threading.Tasks;
using MergeMansion.Enums;
using MergeMansion.Interfaces;
using MergeMansion.StringFields;
using UnityEngine.SceneManagement;

namespace MergeMansion.Services
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask GoToScene(CurrentScene scene)
        {
            switch (scene)
            {
                case CurrentScene.Game:
                    await ReloadGameScene();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scene), scene, null);
            }
        }

        private async UniTask ReloadGameScene()
        {
            await LoadGameScene(false);
        }

        private async UniTask LoadGameScene(bool additive)
        {
            await SceneManager.LoadSceneAsync(
                    SceneNames.Game,
                    additive ? LoadSceneMode.Additive : LoadSceneMode.Single)
                .ToUniTask();
        }
    }
}