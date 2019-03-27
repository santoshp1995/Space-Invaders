using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveLeftObserver : InputObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();
            pShip.MoveLeft();
        }
    }
}