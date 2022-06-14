using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components.Entity.Useable
{
    public class BookComponent : MonoBehaviour,
        IEntityComponent
    {
        private Book _book;

        public IEntity Entity => _book;

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