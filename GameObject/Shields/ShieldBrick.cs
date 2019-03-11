namespace SpaceInvaders
{
    public class ShieldBrick : ShieldCategory
    {
        public ShieldBrick(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;


            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        ~ShieldBrick()
        {

        }
        public override void Accept(ColVisitor other)
        {           
            other.VisitShieldBrick(this);
        }

        public override void VisitMissile(Missile missile)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(missile, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(bomb, this);
            pColPair.NotifyListeners();
        }
        public override void Update()
        {
            base.Update();
        }

        // ---------------------------------
        // Data: 
        // ---------------------------------


    }
}

// End of File

