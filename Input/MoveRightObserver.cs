using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveRightObserver : InputObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();
            pShip.MoveRight();
        }
    }
}
