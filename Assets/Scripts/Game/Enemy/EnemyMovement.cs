using TDS.Infrastructure.Locator;
using TDS.Service.Level;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        private Camera _camera;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Rotate();
        }

        #endregion

        #region Private methods

        private void Rotate()
        {
            Vector3 targetPosition = ServicesLocator.Instance.Get<LevelService>().GetPlayerPosition();
            targetPosition.z = transform.position.z;
            transform.up = targetPosition - transform.position;
        }

        #endregion
    }
}