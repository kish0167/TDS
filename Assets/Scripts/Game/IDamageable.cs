namespace TDS.Game
{
    public interface IDamageable
    {
        #region Properties

        float Health { get; }

        #endregion

        #region Public methods

        void TakeDamage(float damage);

        #endregion
    }
}