using System;

namespace Izyplay.SliceItAll
{
    /// <summary>
    /// Interface used on objects able to be sliced.
    /// </summary>
    public interface ISlaceable
    {
        /// <summary>
        /// Action fired when this object is sliced.
        /// </summary>
        event Action OnSliced;

        /// <summary>
        /// Slice this object.
        /// </summary>
        void Slice();
    }
}