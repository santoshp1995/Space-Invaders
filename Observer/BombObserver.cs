using System;
namespace SpaceInvaders
{
    class BombObserver : ColObserver
    {
        public override void Notify()
        {
            Bomb pBomb = (Bomb)this.pSubject.pObjA;
            pBomb.Remove();
        }
    }
}
