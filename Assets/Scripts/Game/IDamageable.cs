namespace TDS.Game
{
    public interface IDamageable
    {
        #region Properties

        float Health { get; }

        #endregion

        #region Public methods

        void TakeDamage(float damage);

        void TakeHealing(float healing);

        #endregion
    }
}