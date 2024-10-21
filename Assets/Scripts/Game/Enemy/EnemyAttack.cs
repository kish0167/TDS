using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

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

        private IEnumerator EndlessShooting()
        {
            while (_isShooting)
            {
                yield return new WaitForSeconds(_shootingPeriod);
                Fire();
            }
        }

        private void Fire()
        {
            //_animation.TriggerAttack();
            Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}