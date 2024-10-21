using System;
using UnityEngine;

namespace TDS.Game.Character
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private CharacterAnimation _animation;

        [Header("Settings")]
        [SerializeField] private float _startHealth = 10f;

        #endregion

        #region Events

        public static event Action OnCreated;
        public event Action OnDeath;

        #endregion

        #region Properties

        public float Health { get; private set; }
        public bool IsAlive { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            IsAlive = true;
            Health = _startHealth;
            OnCreated?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TakeCollisionEffect(other);
        }

        #endregion

        #region IDamageable

        public void TakeDamage(float damage)
        {
            Health = Math.Max(Health - damage, 0f);
            Debug.Log($"{gameObject.name} hp is {Health}");
        }

        #endregion

        #region Private methods

        private void TakeCollisionEffect(Collider2D other)
        {
            if (!IsAlive || !other.gameObject.TryGetComponent(out Bullet bullet))
            {
                return;
            }

            TakeDamage(bullet.Damage);
            Destroy(bullet.gameObject);
            TryDie();
        }

        private void TryDie()
        {
            if (Health > 0)
            {
                return;
            }

            IsAlive = false;
            _animation.TriggerDeath();
            OnDeath?.Invoke();
        }

        #endregion
    }
}