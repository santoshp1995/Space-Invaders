using System;

namespace SpaceInvaders

{
    public class WallLeft : WallCategory
    {
        private static int timeSinceLastUpdate = 0;

        public WallLeft(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(gameName,spriteName, Type.Left)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(1, 0, 1);
        }

        ~WallLeft()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitWallLeft(this);
        }

        public override void Update()
        {
            base.Update();
            ++timeSinceLastUpdate;
        }

        public override void VisitGrid(AlienGrid grid)
        {
            // BirdGroup vs WallRight
            Console.WriteLine("\ncollide: {0} with {1}", this, grid);
            Console.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairManager.GetActiveColPair();

            if (timeSinceLastUpdate > 950)
            {
                timeSinceLastUpdate = 0;
                grid.MoveGridDown();

                pColPair.SetCollision(grid, this);
                pColPair.NotifyListeners();


                grid.SetDelta(10.0f);
            }
        }
        public override void VisitShipRoot(ShipRoot root)
        {
            // Ship Root vs Wall Root
            GameObject pGameObject = (GameObject)Iterator.GetChild(root);
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitShip(Ship ship)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();

            pColPair.SetCollision(ship, this);
            pColPair.NotifyListeners();

            //Console.WriteLine("Collision Working");
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
