using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundObserver : ColObserver
    {
        IrrKlang.ISoundEngine pSndEngine;

       public SoundObserver(IrrKlang.ISoundEngine pEng)
        {
            Debug.Assert(pEng != null);
            this.pSndEngine = pEng;
        }

        public override void Notify()
        {
            pSndEngine.SoundVolume = 0.2f;
            
        }
    }
}
