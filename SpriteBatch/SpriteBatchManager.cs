using System;
using System.Diagnostics;

namespace SpaceInvaders
{ 
    public class SpriteBatchManager : Manager
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteBatchManager(int reserveNum = 3, int reserveGrow = 1)
        : base() // <--- Kick the can (delegate)
        {
            // At this point SpriteBatchMan is created, now initialize the reserve
            this.BaseInitialize(reserveNum, reserveGrow);
        }

        private SpriteBatchManager()
        : base() // <--- Kick the can (delegate)
        {
            SpriteBatchManager.pActiveSBMan = null;
            // initialize derived data here
            SpriteBatchManager.poNodeCompare = new SpriteBatch();
        }


        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create()
        {
            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new SpriteBatchManager();
            }
        }
        public static void Destroy()
        {
           
        }

        public static SpriteBatch Add(SpriteBatch.Name name, int priority, int reserveNum = 3, int reserveGrow = 1)
        {
            SpriteBatchManager pMan = SpriteBatchManager.pActiveSBMan;

            SpriteBatch pNode = (SpriteBatch)pMan.sortedAdd(priority);
            Debug.Assert(pNode != null);

            pNode.SetPriority(priority);
            Debug.Assert(pNode != null);

            pNode.Set(name, reserveNum, reserveGrow);
            return pNode;
        }
        public static void SetActive(SpriteBatchManager pSBMan)
        {
            SpriteBatchManager pMan = SpriteBatchManager.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSBMan != null);
            SpriteBatchManager.pActiveSBMan = pSBMan;
        }
        public static void Draw()
        {

            SpriteBatchManager pMan = SpriteBatchManager.pActiveSBMan;

            // walk through the list and render
            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.baseGetActive();

            while (pSpriteBatch != null)
            {
                if (pSpriteBatch.GetDrawEnable())
                {
                    SBNodeManager pSBNodeMan = pSpriteBatch.GetSBNodeMan();
                    Debug.Assert(pSBNodeMan != null);

                    // Kick the can
                    pSBNodeMan.Draw();
                }
                pSpriteBatch = (SpriteBatch)pSpriteBatch.pNext;
            }

        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchManager pMan = SpriteBatchManager.pActiveSBMan;

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            SpriteBatchManager.poNodeCompare.SetName(name);

            SpriteBatch pData = (SpriteBatch)pMan.baseFind(SpriteBatchManager.poNodeCompare);
            return pData;
        }
        public static void Remove(SpriteBatch pNode)
        {
            SpriteBatchManager pMan = SpriteBatchManager.pActiveSBMan;


            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }

        public static void Remove(SBNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            SBNodeManager pSBNodeMan = pSpriteBatchNode.GetSBNodeMan();

            Debug.Assert(pSBNodeMan != null);
            pSBNodeMan.Remove(pSpriteBatchNode);
        }

        public static void Dump()
        {
           

            SpriteBatchManager pMan = SpriteBatchManager.pActiveSBMan;

            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new SpriteBatch();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            SpriteBatch pDataA = (SpriteBatch)pLinkA;
            SpriteBatch pDataB = (SpriteBatch)pLinkB;

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
            SpriteBatch pNode = (SpriteBatch)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteBatch pData = (SpriteBatch)pLink;
            pData.Dump();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static SpriteBatchManager privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        //----------------------------------------------------------------------
        // Data - unique data for this manager 
        //----------------------------------------------------------------------
        private static SpriteBatchManager pInstance = null;
        private static SpriteBatchManager pActiveSBMan = null;
        private static SpriteBatch poNodeCompare;
    }
}

// End of File
