using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallTop : WallCategory
    {
        public WallTop(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, Type.Top)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(1, 1, 1);   
        }
        ~WallTop()
        {

        }
        public override void Accept(ColVisitor other)
        {
            other.VisitWallTop(this);
        }
        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs WallTop
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj,this);

            Console.WriteLine("Collide with top");
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs WallTop
            ColPair pColPair = ColPairManager.GetActiveColPair();

            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();

            Console.WriteLine("Collide with top");
        }

        public override void VisitBombRoot(BombRoot root)
        {
            // MissileRoot vs WallTop
            GameObject pGameObj = (GameObject)Iterator.GetChild(root);
            ColPair.Collide(pGameObj, this);

            
        }
        public override void VisitBomb(Bomb bomb)
        {
            
        }
    }
}
