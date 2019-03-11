namespace SpaceInvaders
{
    public class NullGameObject : Leaf
    {
        public NullGameObject()
            : base(GameObject.Name.NullObject, GameSprite.Name.NullObject)
        {

        }

        public NullGameObject(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY)
            : base(gameName, spriteName)
        {

        }
        ~NullGameObject()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitNullGameObject(this);
        }
        public override void Update()
        {
            // do nothing - its a null object
        }

    }
}
