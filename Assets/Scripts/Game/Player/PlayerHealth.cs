using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        #region Variables

        [SerializeField] private float _startHealth = 10f;

        #endregion

        #region Properties

        public float Health { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Health = _startHealth;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TakeCollisionEffect(other);
        }

        #endregion

        #region IDamageable

        public void TakeDamage(float damage)
        {
            Health -= damage;
            Debug.Log($"Player hp: {Health}");
        }

        #endregion

        #region Private methods

        private void TakeCollisionEffect(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);
            }
        }

        #endregion
    }
}