using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SpriteBase : DLink
    {

        // data
        private SBNode pBackSBNode;

        public SpriteBase() : base()
        {
            this.pBackSBNode = null;
        }

        public SBNode GetSBNode()
        {
            Debug.Assert(this.pBackSBNode != null);
            return this.pBackSBNode;
        }

        public void SetSBNode(SBNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSBNode = pSpriteBatchNode;
        }
        abstract public void Update();
        abstract public void Render();

        
    }
}
