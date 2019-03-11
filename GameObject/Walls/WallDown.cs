namespace SpaceInvaders
{
    public class WallDown : WallCategory 
    {
        public WallDown(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            :base(name, spriteName, Type.Down)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(0, 1, 0);
        }

        ~WallDown()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitWallDown(this);
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(bomb, this);
            pColPair.NotifyListeners();
        }

        public override void VisitGrid(AlienGrid grid)
        {
            // For now this should stop from crashing when Grid hits ground.
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
;