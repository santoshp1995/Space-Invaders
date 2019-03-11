using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRoot : Composite
    {
        public ShipRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(0, 0, 1);
        }

        ~ShipRoot()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShipRoot(this);
        }

        public override void VisitBombRoot(BombRoot root)
        {
            ColPair.Collide((GameObject)Iterator.GetChild(root), this);
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(bomb, this);
            pColPair.NotifyListeners();
            Console.WriteLine("Visited");
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // Data: ---------------


    }
}
