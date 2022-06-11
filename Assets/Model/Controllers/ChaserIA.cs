using UnityEngine;

namespace Assets.Model.Controllers
{
    public class ChaserIA : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        public void OnActed(Action action)
        {
            Acted?.Invoke(action);
        }

        public void ReceiveTarget(Vector3 me, Vector3 target)
        {
            float mx = me.x;
            float tx = target.x;
            if (mx > tx)
                OnActed(Action.BACK);
            else if (mx < tx)
                OnActed(Action.FORWARD);
            else
                OnActed(Action.STOP);
        }
    }
}