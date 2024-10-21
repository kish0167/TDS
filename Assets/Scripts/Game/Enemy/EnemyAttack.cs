using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyHealth _health;

        [Header("Settings")]
        [SerializeField] private float _shootingPeriod;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        [Header("Debug control")]
        [SerializeField] private bool _isShooting = true;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartCoroutine(EndlessShooting());
        }

        #endregion

        #region Private methods

        private bool CanFire()
        {
            return _health.IsAlive && _isShooting;
        }

        private IEnumerator EndlessShooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(_shootingPeriod);

                if (!CanFire())
                {
                    continue;
                }

                Fire();
            }
        }

        private void Fire()
        {
            _animation.TriggerAttack();
            Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}