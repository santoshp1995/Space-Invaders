using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missile :MissileCategory
    {
       
        //Ship pShip = new Ship(GameObject.Name.Ship, GameSprite.Name.Player, 200, 75);

        public Missile(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.enable = false;
            this.delta = 20.0f;
        }

        public override void Update()
        {
            base.Update();
            this.y += delta;

            if(this.y >= 1075)
            {
               
                this.Remove();
            }
        }

        ~Missile()
        {

        }


        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // now remove it
            base.Remove();
        }

        public override void Accept(ColVisitor other)
        {            
            other.VisitMissile(this);   
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(bomb, this);
            pColPair.NotifyListeners();

            this.Remove();
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void SetActive(bool state)
        {
            this.enable = state;
        }

        // Data -------------------------------------
        private bool enable;
        public float delta;

    }
}
