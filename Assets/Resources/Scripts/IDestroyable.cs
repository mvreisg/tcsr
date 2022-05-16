using UnityEngine;

namespace Assets.Resources.Scripts
{
    /// <summary>
    ///     <para>RULE: Only IDestroyable can call Destroy(gameObject)</para>
    ///     <para>This interface allows the Component a.k.a MonoBehaviour to call Destroy on the gameObject</para>
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        ///     <para>The method shaper to destruction methods.</para>
        /// </summary>
        /// <param name="gameObject">The gameObject to be destroyed</param>
        delegate void DestroyDelegate(GameObject brinkToDestruction);

        /// <summary>
        ///     <para>If you want another class to react to the destruction of this object, add a method in the shape of DestroyDelegate to be notified.</para>
        /// </summary>
        event DestroyDelegate DestroyEvent;

        /// <summary>
        ///     <para>Is the object allowed to be destroyed?.</para>
        ///     <para>Reason: avoiding misuse of AtBrinkOfDestruction().</para>
        /// </summary>
        bool AllowedToBeDestroyed { get; }

        /// <summary>
        ///     <para>Notify all objects of their imminent destruction and then self-destruct.</para>
        ///     <para>Must:</para>
        ///     <list type="number">
        ///         <item>Check permission. Is AllowedToBeDestroyed?</item>
        ///         <item>Invoke DestroyEvent</item>
        ///         <item>Call Object.Destroy(gameObject)</item>
        ///     </list>
        /// </summary>
        void AtBrinkOfDestruction();
    }
}