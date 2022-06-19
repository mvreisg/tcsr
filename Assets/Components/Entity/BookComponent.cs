using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components.Entity
{
    public class BookComponent : MonoBehaviour,
        IModelComponent
    {
        private Book _book;

        public IModel Model => _book;

        private void Awake()
        {
            _book = new Book(transform);
        }

        private void Update()
        {
            _book.Update();
        }

        private void FixedUpdate()
        {
            _book.FixedUpdate();
        }
    }
}