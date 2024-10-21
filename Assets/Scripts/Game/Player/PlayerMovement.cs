using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerHealth _health;

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private float _speed = 10;

        private Camera _camera;

        #endregion

        #region Events

        public static event Action<PlayerMovement> OnCreated;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        #endregion

        #region Private methods

        private bool CanMove()
        {
            return _health.IsAlive;
        }

        private void Move()
        {
            if (!CanMove())
            {
                return;
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 direction = new(horizontal, vertical);
            Vector2 velocity = direction.normalized * _speed;
            _rb.velocity = velocity;
            _animation.SetMovement(direction.magnitude);
        }

        private void Rotate()
        {
            if (!CanMove())
            {
                return;
            }

            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
            mouseWorldPoint.z = transform.position.z;
            transform.up = mouseWorldPoint - transform.position;
        }

        #endregion
    }
}