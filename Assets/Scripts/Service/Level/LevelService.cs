using TDS.Game.Player;
using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using UnityEngine;

namespace TDS.Service.Level
{
    public class LevelService : IService
    {
        #region Variables

        private PlayerHealth _playerHealth;
        private PlayerMovement _playerMovement;

        #endregion

        #region Setup/Teardown

        public LevelService()
        {
            PlayerMovement.OnCreated += PlayerCreatedCallback;
        }

        ~LevelService()
        {
            PlayerMovement.OnCreated -= PlayerCreatedCallback;
        }

        #endregion

        #region Public methods

        public Vector3 GetPlayerPosition()
        {
            return _playerMovement.transform.position;
        }

        #endregion

        #region Private methods

        private void PlayerCreatedCallback(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
            _playerHealth = playerMovement.PlayerHealth;
            _playerHealth.OnDeath += PlayerDeathCallback;
        }

        private void PlayerDeathCallback()
        {
            RestartGame();
        }

        private void RestartGame()
        {
            ServicesLocator.Instance.Get<StateMachine>().Enter<RestartGameState>();
        }

        #endregion
    }
}