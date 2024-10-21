using System.Collections;
using UnityEngine;

namespace TDS.Game
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private float _damage = 1f;

        #endregion

        #region Properties

        public float Damage => _damage;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = transform.up * _speed;

            StartCoroutine(DestroyWithLifetimeDelay());
        }

        #endregion

        #region Private methods

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);

            Destroy(gameObject);
        }

        #endregion
    }
}