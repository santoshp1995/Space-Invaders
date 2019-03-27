using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColPairManager : Manager
    {
        private static ColPairManager pInstance = null;
        private ColPair poNodeCompare;
        private ColPair pActiveColPair;
        private static ColPairManager privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        private ColPairManager(int reserveNum, int reserveGrow): base()
        {
            
            this.BaseInitialize(reserveNum, reserveGrow);

            // no link... used in Process
            this.pActiveColPair = null;

            // initialize derived data here
            this.poNodeCompare = new ColPair();
        }

        ~ColPairManager()
        {

        }

        public static void Create(int reserveNum, int reserveGrow)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new ColPairManager(reserveNum, reserveGrow);
            }

        }



        public static void Destroy()
        {
            // Get the instance

        }

        public static ColPair Add(ColPair.Name colpairName, GameObject treeRootA, GameObject treeRootB)
        {
            ColPairManager pMan = ColPairManager.privGetInstance();
            Debug.Assert(pMan != null);

            ColPair pColPair = (ColPair)pMan.baseAdd();
            Debug.Assert(pColPair != null);

            pColPair.Set(colpairName, treeRootA, treeRootB);

            return pColPair;
        }

        public static void Process()
        {
            // get the singleton
            ColPairManager pColPairMan = ColPairManager.privGetInstance();

            ColPair pColPair = (ColPair)pColPairMan.baseGetActive();

            while (pColPair != null)
            {
                pColPairMan.pActiveColPair = pColPair;

                pColPair.Process();

                pColPair = (ColPair)pColPair.pNext;
            }
        }

        public static ColPair Find(ColPair.Name name)
        {
            ColPairManager pMan = ColPairManager.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeCompare.SetName(name);

            ColPair pData = (ColPair)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }
        public static void Remove(ColPair pNode)
        {
            ColPairManager pMan = ColPairManager.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Dump()
        {
            ColPairManager pMan = ColPairManager.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }
        static public ColPair GetActiveColPair()
        {
            
            ColPairManager pMan = ColPairManager.privGetInstance();

            return pMan.pActiveColPair;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new ColPair();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            ColPair pDataA = (ColPair)pLinkA;
            ColPair pDataB = (ColPair)pLinkB;

            Boolean status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ColPair pNode = (ColPair)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ColPair pData = (ColPair)pLink;
            pData.Dump();
        }
    }
}
