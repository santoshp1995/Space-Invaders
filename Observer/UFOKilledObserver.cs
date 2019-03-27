using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOKilledObserver : ColObserver
    {
        Sound invaderKilled = SoundManager.Find(Sound.Name.Alien_Killed);
        private GameObject pMissile;

        public UFOKilledObserver()
        {
            this.pMissile = null;
        }

        public UFOKilledObserver(UFOKilledObserver u)
        {
            this.pMissile = u.pMissile;
        }

        public override void Notify()
        {
            this.pMissile = (Missile)this.pSubject.pObjA;
            Debug.Assert(this.pMissile != null);

            if (pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;
                //   Delay
                UFOKilledObserver pObserver = new UFOKilledObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
        }

        private void UFOSplat()
        {
            ProxySprite UFOSplat = ProxySpriteManager.Add(GameSprite.Name.AlienShotExplosion);
            UFOSplat.x = pMissile.x;
            UFOSplat.y = pMissile.y;
            SpriteBatch batch = SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders);
            batch.Attach(UFOSplat);
        }

        public override void Execute()
        {
            this.invaderKilled.PlaySound();
            this.UFOSplat();
        }
    }
}
