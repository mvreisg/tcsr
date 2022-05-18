using UnityEngine;

namespace Assets.Resources.Classes {
    public class Layer
    {
        public static int GROUND => LayerMask.NameToLayer("Ground");
        public static int DIAGONAL => LayerMask.NameToLayer("Diagonal");
        public static int WALL => LayerMask.NameToLayer("Wall");
    }
}
