using TDS.Infrastructure.Locator;
using TDS.Service.Level;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class RestartGameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log("RestartGameState Enter");

            SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
            sceneLoaderService.Load(SceneName.Game);

            StateMachine.Enter<GameState>();
        }

        public override void Exit() { }

        #endregion
    }
}