using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShipSpawnState : ShipState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipManager.State.Ready);
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
