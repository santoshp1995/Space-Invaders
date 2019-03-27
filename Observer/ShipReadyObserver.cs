using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipReadyObserver : ColObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();
            pShip.Handle();
        }
    }
}