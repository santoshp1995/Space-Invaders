using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldColumn : Composite
    {
        public ShieldColumn(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        ~ShieldColumn()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldColumn(this);
        }

        public override void VisitMissile(Missile missile)
        {
            GameObject pGameObject = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(missile, pGameObject);

            missile.Remove();
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair.Collide(bomb, (GameObject)Iterator.GetChild(this));
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ---------------------------------------------
        // Data: 
        // ---------------------------------------------


    }
}

// End of File