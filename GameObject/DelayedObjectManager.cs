using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedObjectManager
    {
        // class data
        private ColObserver head;
        private static DelayedObjectManager instance = null;

        private static DelayedObjectManager getInstance()
        {
            if(instance == null)
            {
                instance = new DelayedObjectManager();
            }

            Debug.Assert(instance != null);
            return instance;
        }

        public static void Attach(ColObserver observer)
        {
            Debug.Assert(observer != null);

            DelayedObjectManager pDelayMan = DelayedObjectManager.getInstance();

            // add to the front
            if(pDelayMan.head == null)
            {
                pDelayMan.head = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = pDelayMan.head;
                observer.pPrev = null;
                pDelayMan.head.pPrev = observer;
                pDelayMan.head = observer;
            }
        }

        private void PrivDetach(ColObserver node, ref ColObserver head)
        {
            Debug.Assert(node != null);

            if(node.pPrev != null)
            {
                // middle or last node
                node.pPrev.pNext = node.pNext;
            }
            else
            {
                // first node
                head = (ColObserver)node.pNext;
            }

            if(node.pNext != null)
            {
                // middle node
                node.pNext.pPrev = node.pPrev;
            }
        }

        static public void Process()
        {
            DelayedObjectManager pDelayMan = DelayedObjectManager.getInstance();

            ColObserver pNode = pDelayMan.head;

            while (pNode != null)
            {
                pNode.Execute();

                pNode = (ColObserver)pNode.pNext;
            }

            // remove
            pNode = pDelayMan.head;
            ColObserver pTemp = null;

            while(pNode != null)
            {
                pTemp = pNode;
                pNode = (ColObserver)pNode.pNext;

                // remove 
                pDelayMan.PrivDetach(pTemp, ref pDelayMan.head);
            }
        }

        private DelayedObjectManager()
        {
            this.head = null;
        }
    }
}
