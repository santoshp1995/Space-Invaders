namespace SpaceInvaders
{
    public abstract class Command
    {
        // define in concrete
        abstract public void Execute(float deltaTime);
    }
}
