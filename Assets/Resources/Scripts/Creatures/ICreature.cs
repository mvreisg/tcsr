using UnityEngine;
using Assets.Resources.Scripts.Characters;

namespace Assets.Resources.Scripts.Creatures
{
    public interface ICreature
    {
        /// <summary>
        /// They are aware of the character
        /// </summary>
        public Blu Blu { get; }

        /// <summary>
        /// They are visible
        /// </summary>
        public SpriteRenderer SpriteRenderer { get; }
    }
}
