using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        public Composite(GameObject.Name gameName, GameSprite.Name spriteName) : base(gameName, spriteName)
        {
            this.holder = Container.Composite;
            this.poHead = null;
            this.poLast = null;
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            this.privAddToLast(ref this.poHead, ref this.poLast, pComponent);
            pComponent.pParent = this;
        }

        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            this.privRemoveNode(ref this.poHead, ref this.poLast, pComponent);
        }

        public override void Print()
        {
            DLink pNode = this.poHead;

            while (pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.Print();

                pNode = pNode.pNext;
            }

        }
        override public Component GetFirstChild()
        {
            DLink pNode = this.poHead;

            
            return (Component)pNode;
        }
       
        public void privRemoveNode(ref DLink pHead, ref DLink pEnd, DLink pNode)
        {
            // protection
            Debug.Assert(pHead != null);
            Debug.Assert(pEnd != null);
            Debug.Assert(pNode != null);

            // Quick HACK... might be a bug... need to diagram

            // 4 different conditions... 
            if (pNode.pPrev != null)
            {	// middle part 1/2
                pNode.pPrev.pNext = pNode.pNext;

                // last node
                if (pNode == pEnd)
                {
                    pEnd = pNode.pPrev;
                }
            }
            else
            {  // first
                pHead = pNode.pNext;

                if (pNode == pEnd)
                {
                    // Only one node
                    pEnd = pNode.pNext;
                }
                else
                {
                    // Only first not the last
                    // do nothing more
                }
            }

            if (pNode.pNext != null)
            {	// middle node part 2/2
                pNode.pNext.pPrev = pNode.pPrev;
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();
        }
        private void privAddToLast(ref DLink pHead, ref DLink pLast, DLink pNode)
        {
            // Will work for Active or Reserve List

            // add to front
            Debug.Assert(pNode != null);

            // add node
            if (pLast == pHead && pHead == null)
            {
                // push to the front
                pHead = pNode;
                pLast = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                Debug.Assert(pLast != null);
                // add to end
                pLast.pNext = pNode;
                pNode.pPrev = pLast;
                pNode.pNext = null;

                pLast = pNode;
                // ---> no change for pHead
            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(pHead != null);
            Debug.Assert(pLast != null);
        }

        // -----------------------------------------------------
        //  Data:
        // -----------------------------------------------------

        public DLink poHead;
        public DLink poLast;
    }
}
