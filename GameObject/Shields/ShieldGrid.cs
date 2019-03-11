namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        public ShieldGrid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY) : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        ~ShieldGrid()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitShieldGrid(this);
        }

        public override void VisitMissile(Missile missile)
        {
            // Missile vs Shield Grid
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(missile, pGameObj);
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
