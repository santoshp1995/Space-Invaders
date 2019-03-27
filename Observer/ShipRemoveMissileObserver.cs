using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRemoveMissileObserver : ColObserver
    {
        public ShipRemoveMissileObserver()
        {
            this.pMissile = null;
        }

        public ShipRemoveMissileObserver(ShipRemoveMissileObserver m)
        {
            Debug.Assert(m.pMissile != null);
            this.pMissile = m.pMissile;
        }

        public override void Notify()
        {
            this.pMissile = (Missile)this.pSubject.pObjA;

            if(pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;

                ShipRemoveMissileObserver pObserver = new ShipRemoveMissileObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pMissile.Remove();
        }

        // data
        private GameObject pMissile;
    }
}

