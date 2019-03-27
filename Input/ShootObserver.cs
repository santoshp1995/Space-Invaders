using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShootObserver : InputObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();
            pShip.ShootMissile();       
        }
    }
}
