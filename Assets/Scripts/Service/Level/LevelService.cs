using TDS.Game;
using TDS.Infrastructure.Locator;
using UnityEngine;

namespace TDS.Service.Level
{
    public class LevelService : IService
    {
        #region Variables

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
        }

        #endregion
    }
}