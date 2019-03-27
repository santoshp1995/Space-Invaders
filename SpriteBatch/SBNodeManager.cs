using System.Diagnostics;

namespace SpaceInvaders
{
    public class SBNodeManager : Manager
    {
        // manager data
        private SpriteBatch.Name name;
        private readonly SBNode pNodeCompare;
        private SpriteBatch pBackSpriteBatch;

        public SBNodeManager(int reserveNum = 3, int reserveGrow = 3) : base()
        {
            this.BaseInitialize(reserveNum, reserveGrow);
            this.pBackSpriteBatch = null;

            this.pNodeCompare = new SBNode();
        }

        public void Set(SpriteBatch.Name name, int reserveNum, int reserveGrow)
        {
            this.name = name;

            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            this.baseSetReserve(reserveNum, reserveGrow);
        }
       
        public SBNode Attach(SpriteBase pNode)
        {
            SBNode pSBNode = (SBNode)this.baseAdd();
            Debug.Assert(pSBNode != null);

            pSBNode.Set(pNode, this);

            return pSBNode;
        }
        public void Draw()
        {
            SBNode pNode = (SBNode)this.baseGetActive();

            while (pNode != null)
            {
                pNode.GetSpriteBase().Render();

                pNode = (SBNode)pNode.pNext;
            }
        }

        public SpriteBatch GetSpriteBatch()
        {
            return this.pBackSpriteBatch;
        }

        public void SetSpriteBatch(SpriteBatch _pSpriteBatch)
        {
            this.pBackSpriteBatch = _pSpriteBatch;
        }
        public void Remove(SBNode pNode)
        {
            Debug.Assert(pNode != null);
            this.baseRemove(pNode);
        }
        public void Dump()
        {
            this.baseDump();
        }

        // override abstract methods
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new SBNode();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            SBNode pDataA = (SBNode)pLinkA;
            SBNode pDataB = (SBNode)pLinkB;

            bool status = false;

            if (pLinkB == pLinkA)
            {
                status = false;
            }
            else
            {
                status = false;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SBNode pNode = (SBNode)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SBNode pData = (SBNode)pLink;
        }
    }
}
