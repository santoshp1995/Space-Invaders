namespace SpaceInvaders
{
    abstract public class BombCategory : Leaf
    {
        protected BombCategory.Type type;

        public enum Type
        {
            Bomb,
            BombRoot,
            Unitilized
        }

        protected BombCategory(GameObject.Name gameName, GameSprite.Name spriteName, BombCategory.Type bombType)
            :base(gameName, spriteName)
        {
            this.type = bombType;
        }

        ~BombCategory()
        {

        }
    }
}
