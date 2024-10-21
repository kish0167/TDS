using TDS.Infrastructure.Locator;
using TDS.Service.Level;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class LoadGameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log("LoadGameState Enter");

            LevelService ls = new();
            ServicesLocator.Instance.Register(ls);

            SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
            sceneLoaderService.Load(SceneName.Game);

            StateMachine.Enter<GameState>();
        }

        public override void Exit() { }

        #endregion
    }
}