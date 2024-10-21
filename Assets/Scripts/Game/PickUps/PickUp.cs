using TDS.Utility;
using UnityEngine;

namespace TDS.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsRecipient(other.gameObject))
            {
                return;
            }

            PerformActions(other.gameObject);
            Destroy(gameObject);
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions(GameObject recipient) { }

        #endregion

        #region Private methods

        private bool IsRecipient(GameObject go)
        {
            return go.CompareTag(Tags.Player) || go.CompareTag(Tags.Player);
        }

        #endregion
    }
}