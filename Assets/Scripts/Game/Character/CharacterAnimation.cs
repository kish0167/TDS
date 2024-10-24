using UnityEngine;

namespace TDS.Game.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("death");
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

        public void TriggerDeath()
        {
            _animator.SetTrigger(Death);
        }

        #endregion
    }
}
