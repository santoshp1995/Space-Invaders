using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FallStraight : FallStrategy
    {
        // class data
        private float oldPosY;

        public FallStraight()
        {
            this.oldPosY = 500.0f;
        }

        public override void Reset(float posY)
        {
            this.oldPosY = posY;
        }

        public override void Fall(Bomb pBomb)
        {
            Debug.Assert(pBomb != null);

            // Do nothing for this strategy
        }


    }
}
