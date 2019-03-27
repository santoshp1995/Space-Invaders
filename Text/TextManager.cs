using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextManager : Manager
    {
        private static TextManager pInstance = null;
        private TextFont pRefNode;

        private static TextManager getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private TextManager(int reserveNum, int growthSize) : base()
        {
            this.BaseInitialize(reserveNum, growthSize);
            this.pRefNode = (TextFont)this.derivedCreateNode();
        }

        ~TextManager()
        {

        }

        public static void Create(int reserveNum, int growthSize)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(growthSize > 0);

            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new TextManager(reserveNum, growthSize);
            }
        }

        public static void Destroy()
        {

        }

        public static TextFont Add(TextFont.Name name, SpriteBatch.Name SB_Name, String pMessage, Glyph.Name glyphName,
            float xStart, float yStart)
        {
            TextManager pTxtMan = TextManager.getInstance();
            TextFont pNode = (TextFont)pTxtMan.baseAdd();

            Debug.Assert(pNode != null);

            pNode.Set(name, pMessage, glyphName, xStart, yStart);

            // Add to Sprite Batch
            SpriteBatch pSB = SpriteBatchManager.Find(SB_Name);
            Debug.Assert(pSB != null);

            Debug.Assert(pNode.pTxtSprite != null);
            pSB.Attach(pNode.pTxtSprite);

            return pNode;
        }

        public static void AddXML(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            GlyphManager.AddXML(glyphName, assetName, textName);
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            TextManager pTxtMan = TextManager.getInstance();
            pTxtMan.baseRemove(pNode);
        }

        public static TextFont Find(TextFont.Name name)
        {
            TextManager pTxtMan = TextManager.getInstance();

            pTxtMan.pRefNode.name = name;

            TextFont pData = (TextFont)pTxtMan.baseFind(pTxtMan.pRefNode);
            return pData;
        }

        public static void Dump()
        {
            TextManager pTxtMan = TextManager.getInstance();
            Debug.Assert(pTxtMan != null);

            pTxtMan.baseDump();
        }

        // override abstract methods
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            TextFont pDataA = (TextFont)pLinkA;
            TextFont pDataB = (TextFont)pLinkB;

            Boolean status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new TextFont();
            Debug.Assert(pNode != null);
            return pNode;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TextFont pNode = (TextFont)pLink;
            pNode.Wash();
        }

        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TextFont pNode = (TextFont)pLink;

            Debug.Assert(pNode != null);
            
        }

    }
}
