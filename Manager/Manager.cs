using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Manager
    {
        // Class data
        private DLink pActive;
        private DLink pReserve;
        private int mGrowthSize;
        private int mTotalNodes;
        private int mInitialNumReserved;
        private int mNumReserved;
        private int mNumActive;

        protected Manager()
        {
            this.mGrowthSize = 0;
            this.mNumReserved = 0;
            this.mInitialNumReserved = 0;
            this.mNumActive = 0;
            this.mTotalNodes = 0;
            this.pActive = null;
            this.pReserve = null;
        }
        protected void BaseInitialize(int InitialNumReserved, int DeltaGrow)
        {
            Debug.Assert(InitialNumReserved >= 0);
            Debug.Assert(DeltaGrow > 0);

            this.mGrowthSize = DeltaGrow;
            this.mInitialNumReserved = InitialNumReserved;

            // Preload the reserve
            this.privFillReservedPool(InitialNumReserved);
        }

        private void privFillReservedPool(int count)
        {
            Debug.Assert(count >= 1);

            this.mTotalNodes += count;
            this.mNumReserved += count;

            // Preload the reserve
            for (int i = 0; i < count; i++)
            {
                DLink pNode = this.derivedCreateNode();
                Debug.Assert(pNode != null);

                Manager.privAddToFront(ref this.pReserve, pNode);
            }
        }
        public static void privAddToFront(ref DLink pHead, DLink pNode)
        {
            Debug.Assert(pNode != null);

            // add node
            if (pHead == null)
            {
                // push to the front
                pHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = pHead;

                // update head
                pHead.pPrev = pNode;
                pHead = pNode;
            }

            Debug.Assert(pHead != null);
        }

        private static void privSortedAdd(ref DLink pHead, DLink pNode)
        {
            Debug.Assert(pNode != null);

            // add node
            if (pHead == null)
            {
                // push to the front
                pHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }

            else if (pHead.priority > pNode.priority)
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = pHead;

                // update head
                pHead.pPrev = pNode;
                pHead = pNode;
            }

            else
            {
                DLink pTemp = pHead;

                while ((pTemp.pNext != null) && (pTemp.pNext.priority < pNode.priority))
                {
                    pTemp = pTemp.pNext;
                }

                // now pTemp is the LAST dlink on the list with a priority lower or equal to pNode's priority

                if (pTemp.pNext != null)
                {
                    pTemp.pNext.pPrev = pNode;
                    pNode.pNext = pTemp.pNext;
                    pTemp.pNext = pNode;
                    pNode.pPrev = pTemp;
                }

                else
                {
                    pTemp.pNext = pNode;
                    pNode.pPrev = pTemp;
                }
            }

            Debug.Assert(pHead != null);
        }

        private static void PrivSortTimer(ref DLink pHead, DLink pNode)
        {
            Debug.Assert(pNode != null);

            // add a node
            if(pHead == null)
            {
                // push to front
                pHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }

            else if(pHead.floatPriority > pNode.floatPriority)
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = pHead;

                // update head
                pHead.pPrev = pNode;
                pHead = pNode;
            }
            else
            {
                DLink pTemp = pHead;

                while ((pTemp.pNext != null) && (pTemp.pNext.floatPriority < pNode.floatPriority))
                {
                    pTemp = pTemp.pNext;
                }

                // now pTemp is the LAST dlink on the list with a priority lower or equal to pNode's priority

                if (pTemp.pNext != null)
                {
                    pTemp.pNext.pPrev = pNode;
                    pNode.pNext = pTemp.pNext;
                    pTemp.pNext = pNode;
                    pNode.pPrev = pTemp;
                }

                else
                {
                    pTemp.pNext = pNode;
                    pNode.pPrev = pTemp;
                }
            }

            Debug.Assert(pHead != null);
        }
        public static DLink privPullFromFront(ref DLink pHead)
        {
            Debug.Assert(pHead != null);

            DLink pNode = pHead;

            pHead = pHead.pNext;
            if (pHead != null)
            {
                pHead.pPrev = null;

            }
            else
            {

            }
            pNode.Clear();

            Debug.Assert(pNode.pNext == null);
            Debug.Assert(pNode.pPrev == null);

            return pNode;
        }
        public static void privRemoveNode(ref DLink pHead, DLink pNode)
        {
            Debug.Assert(pHead != null);
            Debug.Assert(pNode != null);

            if (pNode.pPrev != null)
            {	// middle part 1/2
                pNode.pPrev.pNext = pNode.pNext;
            }
            else
            {  // first
                pHead = pNode.pNext;
            }

            if (pNode.pNext != null)
            {	// middle node part 2/2
                pNode.pNext.pPrev = pNode.pPrev;
            }

            pNode.Clear();

            Debug.Assert(pNode.pNext == null);
            Debug.Assert(pNode.pPrev == null);
        }

        protected DLink baseAdd()
        {
            if (this.pReserve == null)
            {
                this.privFillReservedPool(this.mGrowthSize);
            }
            DLink pLink = Manager.privPullFromFront(ref this.pReserve);
            Debug.Assert(pLink != null);

            this.derivedWash(pLink);

            // Keep track of our stats
            this.mNumActive++;
            this.mNumReserved--;

            // copy to active
            Manager.privAddToFront(ref this.pActive, pLink);
            return pLink;
        }

        protected DLink sortedAdd(int priorityKey)
        {
            if (this.pReserve == null)
            {
                this.privFillReservedPool(this.mGrowthSize);
            }
            DLink pLink = Manager.privPullFromFront(ref this.pReserve);
            Debug.Assert(pLink != null);

            this.derivedWash(pLink);

            pLink.priority = priorityKey;

            // Keep track of our stats
            this.mNumActive++;
            this.mNumReserved--;

           
            // copy to active
            Manager.privSortedAdd(ref this.pActive, pLink);
            return pLink;
        }

        protected DLink sortedTimerAdd(float priorityKey)
        {
            if(this.pReserve == null)
            {
                this.privFillReservedPool(this.mGrowthSize);
            }

            DLink pLink = Manager.privPullFromFront(ref this.pReserve);
            Debug.Assert(pLink != null);

            this.derivedWash(pLink);

            pLink.floatPriority = priorityKey;

            // Keep track of our stats
            this.mNumActive++;
            this.mNumReserved--;

            // copy to active
            Manager.PrivSortTimer(ref this.pActive, pLink);
            return pLink;
        }
        protected DLink baseFind(DLink pNodeTarget)
        {
            DLink link = this.pActive;

            while (link != null)
            {
                if (derivedCompare(link, pNodeTarget))
                {
                    // found it
                    break;
                }
                link = link.pNext;
            }

            return link;
        }
        protected void baseRemove(DLink pNode)
        {
            Debug.Assert(pNode != null);

            Manager.privRemoveNode(ref this.pActive, pNode);
            this.derivedWash(pNode);

            // add it to the return list
            Manager.privAddToFront(ref this.pReserve, pNode);

            // keep track of active/reserved
            this.mNumActive--;
            this.mNumReserved++;
        }
        protected DLink baseGetActive()
        {
            return this.pActive;
        }

        protected void baseSetReserve(int reserveNum, int reserveGrow)
        {
            this.mGrowthSize = reserveGrow;

            if (reserveNum > this.mNumReserved)
            {
                // Preload the reserve
                this.privFillReservedPool(reserveNum - this.mNumReserved);
            }
        }

        protected void baseDump()
        {
            Debug.WriteLine("");
            Debug.WriteLine("   ****** Manager Begin ****************\n");

            Debug.WriteLine("         mDeltaGrow: {0} ", mGrowthSize);
            Debug.WriteLine("     mTotalNumNodes: {0} ", mTotalNodes);
            Debug.WriteLine("       mNumReserved: {0} ", mNumReserved);
            Debug.WriteLine("         mNumActive: {0} \n", mNumActive);

            DLink pNode = null;

            if (this.pActive == null)
            {
                Debug.WriteLine("    Active Head: null");
            }
            else
            {
                pNode = this.pActive;
                Debug.WriteLine("    Active Head: ({0})", pNode.GetHashCode());
            }

            if (this.pReserve == null)
            {
                Debug.WriteLine("   Reserve Head: null\n");
            }
            else
            {
                pNode = this.pReserve;
                Debug.WriteLine("   Reserve Head: ({0})\n", pNode.GetHashCode());
            }

            Debug.WriteLine("   ------ Active List: -----------\n");

            pNode = this.pActive;

            int i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("   {0}: -------------", i);
                this.derivedDumpNode(pNode);
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("   ------ Reserve List: ----------\n");

            pNode = this.pReserve;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("   {0}: -------------", i);
                this.derivedDumpNode(pNode);
                i++;
                pNode = pNode.pNext;
            }
            Debug.WriteLine("\n   ****** Manager End ******************\n");
        }

        abstract protected DLink derivedCreateNode();
        abstract protected bool derivedCompare(DLink pLinkA, DLink pLinkB);
        abstract protected void derivedWash(DLink pLink);
        abstract protected void derivedDumpNode(DLink pLink);
    }

}
