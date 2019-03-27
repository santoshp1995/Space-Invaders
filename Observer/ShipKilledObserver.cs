using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipKilledObserver : ColObserver
    {
        public override void Notify()
        {
            Sound shipHit = SoundManager.Find(Sound.Name.Explosions);
            shipHit.PlaySound();
            Ship pShip = ShipManager.GetShip();
            pShip.SetState(ShipManager.State.End);


            pShip.Handle();

            pShip.x = 450;
            pShip.y = 175;
        }
    }
}
