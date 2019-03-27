using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveBombObserver : ColObserver
    {
        private GameObject pBomb;
        
        public RemoveBombObserver()
        {
            this.pBomb = null;
        }

        public RemoveBombObserver(RemoveBombObserver b)
        {
            this.pBomb = b.pBomb;
        }

        public override void Notify()
        {
            this.pBomb = (Bomb)this.pSubject.pObjA;
            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                RemoveBombObserver pObserver = new RemoveBombObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            
            this.pBomb.Remove();
        }
    }
}
