using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipEndState : ShipState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipManager.State.Ready);
        }


        public override void MoveRight(Ship pShip)
        {

        }

        public override void MoveLeft(Ship pShip)
        {

        }

        public override void ShootMissile(Ship pShip)
        {

        }
    }
}