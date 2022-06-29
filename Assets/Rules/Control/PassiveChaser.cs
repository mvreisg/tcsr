using UnityEngine;

namespace Assets.Rules.Control
{
    public class PassiveChaser : 
        IRule,
        IOrder
    {
        public event IOrder.OrderEventHandler Ordered;

        private readonly Transform _transform;

        public Transform Transform => _transform;

        public PassiveChaser(Transform transform)
        {
            _transform = transform;
        }

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public void Order(Action action)
        {
            OnOrdered(new OrderInfo(this, action));
        }

        public void OnOrdered(OrderInfo info)
        {
            Ordered?.Invoke(info);
        }
    }
}