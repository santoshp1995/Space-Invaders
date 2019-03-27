using System.Diagnostics;

namespace SpaceInvaders
{
    class BoxSpriteManager : Manager
    {
        private static BoxSpriteManager pInstance = null;
        private readonly BoxSprite pNodeCompare;

        private static BoxSpriteManager getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private BoxSpriteManager(int reserveNum, int reserveGrow) : base() 
        {
            this.BaseInitialize(reserveNum, reserveGrow);
            this.pNodeCompare = new BoxSprite();
        }

        public static void Create(int reserveNum, int reserveGrow)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new BoxSpriteManager(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
            BoxSpriteManager boxSpriteManager = BoxSpriteManager.getInstance();
            Debug.Assert(boxSpriteManager != null);
        }
        public static BoxSprite Add(BoxSprite.Name name, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            BoxSpriteManager boxSpriteManager = BoxSpriteManager.getInstance();
            Debug.Assert(boxSpriteManager != null);

            BoxSprite pNode = (BoxSprite)boxSpriteManager.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, x, y, width, height, pColor);

            return pNode;
        }
        public static BoxSprite Find(BoxSprite.Name name)
        {
            BoxSpriteManager boxSpriteManager = BoxSpriteManager.getInstance();
            Debug.Assert(boxSpriteManager != null);
            boxSpriteManager.pNodeCompare.name = name;

            BoxSprite pData = (BoxSprite)boxSpriteManager.baseFind(boxSpriteManager.pNodeCompare);
            return pData;
        }
        public static void Remove(BoxSprite pNode)
        {
            BoxSpriteManager boxSpriteManager = BoxSpriteManager.getInstance();
            Debug.Assert(boxSpriteManager != null);

            Debug.Assert(pNode != null);
            boxSpriteManager.baseRemove(pNode);
        }
        public static void Dump()
        {
            BoxSpriteManager boxSpriteManager = BoxSpriteManager.getInstance();
            Debug.Assert(boxSpriteManager != null);

            boxSpriteManager.baseDump();
        }

        // overriding abstract methods

        override protected DLink derivedCreateNode()
        {
            DLink pNode = new BoxSprite();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        { 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            BoxSprite pDataA = (BoxSprite)pLinkA;
            BoxSprite pDataB = (BoxSprite)pLinkB;

            bool status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            BoxSprite pNode = (BoxSprite)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            BoxSprite pData = (BoxSprite)pLink;
            pData.Dump();
        }
    }
}
