using System;

namespace SpaceInvaders
{
    public class WallGroup : Composite
    {
        

        public WallGroup(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY)
            :base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(0, 0, 1);
        }

        ~WallGroup()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitWallGroup(this);
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public override void VisitGrid(AlienGrid grid)
        {
            GameObject pGameObject = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(grid, pGameObject);

            
            
        }

        public override void VisitMissileGroup(MissileGroup group)
        {
            // Missile Root vs Wall Root
            GameObject pGameObject = (GameObject)Iterator.GetChild(group);
            ColPair.Collide(pGameObject, this);

            
        }

        public override void VisitMissile(Missile missile)
        {
            // Missile vs WallRoot
            GameObject pGameObject = (GameObject)Iterator.GetChild(missile);
            ColPair.Collide(missile, pGameObject);

            
        }

        public override void VisitShipRoot(ShipRoot root)
        {
            // Ship Root vs Wall Root

            GameObject pGameObject = (GameObject)Iterator.GetChild(root);
            ColPair.Collide(pGameObject, this);

            
        }

        public override void VisitShip(Ship ship)
        {
            // Ship vs Wall Root
            GameObject pGameObject = (GameObject)Iterator.GetChild(ship);
            ColPair.Collide(ship, pGameObject);
        }

        public override void VisitBombRoot(BombRoot root)
        {
            // Bomb Root vs Wall Root
            GameObject pGameObject = (GameObject)Iterator.GetChild(root);
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitBomb(Bomb bomb)
        {
            // Bomb vs Wall Root
            GameObject pGameObject = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(bomb, pGameObject);
        }
    }
}
