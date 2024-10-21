using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log("GameState Enter");
        }

        public override void Exit() { }

        #endregion
    }
}