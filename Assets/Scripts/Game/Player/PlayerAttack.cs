using TDS.Game.Character;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerHealth _health;

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        #endregion

        #region Private methods

        private bool CanFire()
        {
            return _health.IsAlive;
        }

        private void Fire()
        {
            if (!CanFire())
            {
                return;
            }

            _animation.TriggerAttack();
            Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}