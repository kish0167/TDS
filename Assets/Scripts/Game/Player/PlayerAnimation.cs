using UnityEngine;

namespace TDS.Game
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Fire = Animator.StringToHash("fire");
        private static readonly int Movement = Animator.StringToHash("movement");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void SetMovement(float speed)
        {
            _animator.SetFloat(Movement, speed);
        }

        public void TriggerAttack()
        {
            _animator.SetTrigger(Fire);
        }

        #endregion
    }
}