using TDS.Game.Character;
using UnityEngine;

namespace TDS.Game.PickUps
{
    public class FirstAidPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _healingValue;

        #endregion

        #region Protected methods

        protected override void PerformActions(GameObject recipient)
        {
            if (!recipient.TryGetComponent(out CharacterHealth characterHealth))
            {
                Debug.LogError($"Can't apply healing on {recipient.name} - {nameof(CharacterHealth)} not found");
                return;
            }

            characterHealth.TakeHealing(_healingValue);
        }

        #endregion
    }
}