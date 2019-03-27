using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienKilledObserver : ColObserver
    {
        Sound invaderKilled = SoundManager.Find(Sound.Name.Alien_Killed);
        private AlienGrid pGrid;
        private GameObject pMissile;

        public AlienKilledObserver()
        {
            this.pMissile = null;
            this.pGrid = null;
        }

        public AlienKilledObserver(AlienKilledObserver a)
        {
            this.pMissile = a.pMissile;
            this.pGrid = a.pGrid;
        }

        public override void Notify()
        {
            this.pMissile = (Missile)this.pSubject.pObjA;
            Debug.Assert(this.pMissile != null);

            if (pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;
                //   Delay
                AlienKilledObserver pObserver = new AlienKilledObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
        }

        private void AlienSplat()
        {
            ProxySprite alienSplat = ProxySpriteManager.Add(GameSprite.Name.AlienShotExplosion);
            alienSplat.x = pMissile.x;
            alienSplat.y = pMissile.y;
            SpriteBatch batch = SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders);
            batch.Attach(alienSplat);   
        }

        public override void Execute()
        {
            this.invaderKilled.PlaySound();
            this.AlienSplat();
            TimeEvent speedUp = TimerManager.Find(TimeEvent.Name.SpriteMovement);
            TimeEvent speedAnim = TimerManager.Find(TimeEvent.Name.SpriteAnimation);
            speedUp.deltaTime -= 0.01f;
            speedAnim.deltaTime -= 0.01f;
            
        }
    }
}
