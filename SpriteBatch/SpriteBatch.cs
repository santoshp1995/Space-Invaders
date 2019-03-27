using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatch : DLink
    {
        // class data
        public SpriteBatch.Name name;
        private readonly SBNodeManager pSBNodeMan;
        private bool EnableDraw;

        public enum Name
        {
            Boxes,
            SpaceInvaders,
            AngryBirds,
            Texts,
            Shields,
            Uninitialized
        }

        public SpriteBatch() : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.pSBNodeMan = new SBNodeManager();
            Debug.Assert(this.pSBNodeMan != null);
        }

        public void Set(SpriteBatch.Name name, int reserveNum, int reserveGrow)
        {
            this.name = name;
            this.EnableDraw = true;
            this.pSBNodeMan.Set(name, reserveNum, reserveGrow);
        }

        public void SetPriority(int priority)
        {
            this.priority = priority;
        }

        public void SetDrawEnable(bool status)
        {
            this.EnableDraw = status;
        }

        public bool GetDrawEnable()
        {
            return this.EnableDraw;
        }
        public void Attach(SpriteBase pNode)
        {
            Debug.Assert(pNode != null);

            SBNode pSBNode = (SBNode)this.pSBNodeMan.Attach(pNode);
            Debug.Assert(pSBNode != null);

            // Initilize the SpriteBatchNode
            pSBNode.Set(pNode, this.pSBNodeMan);

            // back pointer
            this.pSBNodeMan.SetSpriteBatch(this);
        }
        public void Wash()
        {
           
        }

        public void Dump()
        {
          
        }

        public void Remove()
        {
            base.Clear();
        }
        public void SetName(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        public SpriteBatch.Name GetName()
        {
            return this.name;
        }

        public SBNodeManager GetSBNodeMan()
        {
            return this.pSBNodeMan;
        }
    }
}
