using System.Diagnostics;

namespace SpaceInvaders
{
    public class SBNode : DLink
    {
        // class data
        public SpriteBase pBase;
        private SBNodeManager pBackSPNodeMan;

        public SBNode() : base()
        {
            this.pBase = null;
            this.pBackSPNodeMan = null;
        }

        public SpriteBase GetSpriteBase()
        {
            return this.pBase;
        }
        public void Set(SpriteBase pNode, SBNodeManager _pSBNodeManager)
        {
            Debug.Assert(pNode != null);
            this.pBase = pNode;

            // Set the Back Pointer. Allows easier deletion in the future
            Debug.Assert(pBase != null);
            this.pBase.SetSBNode(this);

            Debug.Assert(_pSBNodeManager != null);
            this.pBackSPNodeMan = _pSBNodeManager;

        }

        public SBNodeManager GetSBNodeMan()
        {
            Debug.Assert(this.pBackSPNodeMan != null);
            return this.pBackSPNodeMan;
        }

        public SpriteBatch GetSpriteBatch()
        {
            Debug.Assert(this.pBackSPNodeMan != null);
            return this.pBackSPNodeMan.GetSpriteBatch();
        }

        public void Wash()
        {
            this.pBase = null;
        }
    }
}
