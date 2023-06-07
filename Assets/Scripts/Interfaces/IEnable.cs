namespace Izyplay.SliceItAll
{
    /// <summary>
    /// Interface used on objects able to be enabled/disabled.
    /// </summary>
    public interface IEnable
    {
        /// <summary>
        /// Enables or disables this object.
        /// </summary>
        /// <param name="enabled">Whether to enable.</param>
        void SetEnabled(bool enabled);
    }
}