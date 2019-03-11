using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class Ship : ShipCategory
    { 
        public Ship(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
         : base(name, spriteName, ShipCategory.ShipType.Ship)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 15.0f;
            this.state = null;
        }

        public override void Update()
        {
            base.Update();

            if(this.x < 45.0f)
            {
                this.x = 45.0f;
            }

            if(this.x > 850.0f)
            {
                this.x = 850.0f;
            }
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.VisitShip(this);
        }

        public override void VisitBomb(Bomb bomb)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(bomb, this);
            pColPair.NotifyListeners();
        }

        public void SetShipDelta(float currSpeed)
        {
            this.shipSpeed = currSpeed;
        }

        public void MoveRight()
        {
            this.state.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.state.MoveLeft(this);
        }

        public void ShootMissile()
        {
            this.state.ShootMissile(this);
            
        }

        public void SetState(ShipManager.State inState)
        {
            this.state = ShipManager.GetState(inState);
            
        }
        public void Handle()
        {
            this.state.Handle(this);
        }
        public ShipState GetState()
        {
            return this.state;
        }

        // Data: --------------------
        public float shipSpeed;
        private ShipState state;
    }
}
