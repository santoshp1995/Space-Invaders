using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGroup : Composite
    {
        public MissileGroup(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(0, 0, 1);
        }

        ~MissileGroup()
        {

        }

        public override void Accept(ColVisitor other)
        {     
            other.VisitMissileGroup(this);   
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
    }
}
