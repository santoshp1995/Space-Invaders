using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class SLink
    {
        // SLink class data
        public SLink pSNext;

        protected SLink()
        {
            this.pSNext = null;
        }

        public static void AddToFront(ref SLink pHead, SLink pNode)
        {
            Debug.Assert(pNode != null);

            // add node
            if(pHead == null)
            {
                // push to front
                pHead = pNode;
                pNode.pSNext = null;
            }
            else
            {
                // push to front
                pNode.pSNext = pHead;
                pHead = pNode;
            }

            Debug.Assert(pHead != null);
        }
    }
}
