using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldRoot : Composite
    {
        public ShieldRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

        }
        ~ShieldRoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldRoot(this);
        }

        public override void VisitMissileGroup(MissileGroup group)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(group);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile missile)
        {
            GameObject pGameObject = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(missile, pGameObject);
        }

        public override void VisitBombRoot(BombRoot root)
        {
            ColPair.Collide((GameObject)Iterator.GetChild(root), this);
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair.Collide(bomb, (GameObject)Iterator.GetChild(this));
        }
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------


    }
}

// End of File
