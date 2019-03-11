using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileFlyingState : ShipState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipManager.State.ShipSpawnState);
        }


        public override void MoveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
        }

        public override void ShootMissile(Ship pShip)
        {
            
            this.Handle(pShip);   
        }
    }
}
