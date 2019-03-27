using System.Diagnostics;

namespace SpaceInvaders
{
    public class ReverseIterator : Iterator
    {
        // class data
        private Component pRoot;
        private Component pCurr;
        private Component pPrev;

        public ReverseIterator(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.holder == Composite.Container.Composite);

            ForwardIterator pForward = new ForwardIterator(pStart);

            this.pRoot = pStart;
            this.pCurr = this.pRoot;
            this.pPrev = null;

            Component pPrevNode = this.pRoot;

            // Initilize the reverse pointer
            Component pNode = pForward.First();

            while(!pForward.IsDone())
            {
                pPrevNode = pNode;

                pNode = pForward.Next();

                if(pNode != null)
                {
                    pNode.pReverse = pPrevNode;
                }
            }
            pRoot.pReverse = pPrevNode;
        }

        public override Component First()
        {
            Debug.Assert(this.pRoot != null);

            this.pCurr = this.pRoot.pReverse;

            return this.pCurr;
        }

        public override Component Next()
        {
            Debug.Assert(this.pCurr != null);

            this.pPrev = this.pCurr;
            this.pCurr = this.pCurr.pReverse;
            return this.pCurr;
        }

        public override bool IsDone()
        {
            return (this.pPrev == this.pRoot);
        }
    }
}
