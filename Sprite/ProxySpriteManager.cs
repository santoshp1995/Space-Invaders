using System.Diagnostics;

namespace SpaceInvaders
{
    public class ProxySpriteManager : Manager
    {
        // manager data
        private static ProxySpriteManager pInstance = null;
        private ProxySprite pNodeCompare;

        private static ProxySpriteManager getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private ProxySpriteManager(int reserveNum, int growthSize) : base()
        {
            this.BaseInitialize(reserveNum, growthSize);

            this.pNodeCompare = new ProxySprite();
        }

        ~ProxySpriteManager()
        {
#if(TRACK_DESTRUCTOR)
            Debug.WriteLine("~GameSpriteMan():{0}", this.GetHashCode());
#endif
            this.pNodeCompare = null;
            ProxySpriteManager.pInstance = null;
        }

        public static void Create(int reserveNum, int growthSize)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(growthSize > 0);

            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new ProxySpriteManager(reserveNum,growthSize);
            }
        }

        public static void Destroy(){}

        public static ProxySprite Add(GameSprite.Name name)
        {
            ProxySpriteManager psMan = ProxySpriteManager.getInstance();
            Debug.Assert(psMan != null);

            ProxySprite pNode = (ProxySprite)psMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name);

            return pNode;
        }
        public static ProxySprite Find(ProxySprite.Name name)
        {
            ProxySpriteManager psMan = ProxySpriteManager.getInstance();
            Debug.Assert(psMan != null);

            psMan.pNodeCompare.SetName(name);

            ProxySprite pData = (ProxySprite)psMan.baseFind(psMan.pNodeCompare);
            return pData;
        }

        public static void Remove(SpriteBase pNode)
        {
            ProxySpriteManager psMan = ProxySpriteManager.getInstance();
            Debug.Assert(psMan != null);

            Debug.Assert(pNode != null);
            psMan.baseRemove(pNode);
        }

        public static void Dump()
        {
            ProxySpriteManager psMan = ProxySpriteManager.getInstance();
            Debug.Assert(psMan != null);

            psMan.baseDump();
        }

        // overriding abstract methods
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new ProxySprite();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            ProxySprite pDataA = (ProxySprite)pLinkA;
            ProxySprite pDataB = (ProxySprite)pLinkB;

            bool status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pNode = (ProxySprite)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pData = (ProxySprite)pLink;
            pData.Dump();
        }
    }
}
