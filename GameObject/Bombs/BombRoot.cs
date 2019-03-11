using System;

namespace SpaceInvaders
{
    public class BombRoot : Composite
    {
        public BombRoot(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY) : 
            base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;

           this.poColObj.pColSprite.SetLineColor(1, 1, 1);
        }
        
        ~BombRoot()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitBombRoot(this);
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

        public override void VisitShipRoot(ShipRoot root)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(root);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitShip(Ship ship)
        {
            GameObject pGameObject = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(ship, pGameObject);
           
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
