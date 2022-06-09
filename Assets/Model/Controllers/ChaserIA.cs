using UnityEngine;

namespace Assets.Model.Controllers
{
    public class ChaserIA : Controller
    {
        public delegate void ChaserIAEventHandler(Action action);
        public event ChaserIAEventHandler Act;

        public ChaserIA(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("ChaserIA...");
        }

        public void ReceiveTarget(Vector3 me, Vector3 target)
        {
            float mx = me.x;
            float tx = target.x;
            if (mx > tx)
                OnAct(Action.BACK);
            else if (mx < tx)
                OnAct(Action.FORWARD);
            else
                OnAct(Action.STOP);
        }

        private void OnAct(Action action)
        {
            Act?.Invoke(action);
        }
    }
}