namespace SpaceInvaders
{
    abstract public class WallCategory : Leaf
    {
        public WallCategory.Type type;

        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Top,
            Down,
            Unitilized
        }

        protected WallCategory(GameObject.Name gameName, GameSprite.Name spriteName, WallCategory.Type type)
            : base(gameName, spriteName)
        {
            this.type = type;
        }

        ~WallCategory()
        {

        }

        public WallCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}
