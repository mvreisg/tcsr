namespace Assets.Rules
{
    public interface ICollisionListener
    {
        void ListenCollisionEntered(CollisionInfo info);

        void ListenCollisionExited(CollisionInfo info);
    }
}