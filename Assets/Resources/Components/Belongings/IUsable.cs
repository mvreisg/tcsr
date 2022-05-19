using UnityEngine;

namespace Assets.Resources.Components.Belongings
{
    /// <summary>
    ///  <para>Defines a object that can be used.</para>
    /// </summary>
    public interface IUsable
    {
        /// <summary>
        ///     <para>The enumeration of types of usable items.</para>
        /// </summary>
        enum Type
        {
            INATE_POWER,
            BOOK
        }

        /// <summary>
        ///     <para>The delegate with the shape of the Get event.</para>
        /// </summary>
        /// <param name="getter">The "getter" object</param>
        /// <param name="getted">The "getted" object</param>
        delegate void GetEventHandler(GameObject getter, IUsable getted);

        /// <summary>
        ///     <para>The GetDelegate event. Must be trigged when this object is "getted up" by a "getter"</para>
        /// </summary>
        event GetEventHandler Get;

        /// <summary>
        ///     <para>The usable type.</para>
        /// </summary>
        Type TypeOf { get; }

        /// <summary>
        ///     <para>It Belong to someone?</para>
        /// </summary>
        bool Belong { get; }

        /// <summary>
        ///     <para>Is enabled ToUse?</para>
        /// </summary>
        bool ToUse { get; }

        /// <summary>
        ///     <para>Is Using?</para>
        /// </summary>
        bool Using { get; }

        /// <summary>
        ///     <para>Call this to allow use.</para>
        /// </summary>
        void AllowUse();

        /// <summary>
        ///     <para>Call this to forbid use.</para>
        /// </summary>
        void ForbidUse();

        /// <summary>
        ///     <para>Describe the use of the object here.</para>
        /// </summary>
        void Use();
    }
}