using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextureManager : Manager
    {


        private static TextureManager pInstance = null;
        private readonly Texture pNodeCompare;

        private static TextureManager getInstance()
        { 
            Debug.Assert(pInstance != null);

            return pInstance;
        }

       
        public static void Create(int reserveNum, int reserveGrow)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            
            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new TextureManager(reserveNum, reserveGrow);
            }

            // Null Object Texture
            Texture pTexture = TextureManager.Add(Texture.Name.NullObject, "HotPink.tga");
            Debug.Assert(pTexture != null);

            // Default texture
            pTexture = TextureManager.Add(Texture.Name.Default, "HotPink.tga");
            Debug.Assert(pTexture != null);
        }

        private TextureManager(int reserveNum, int reserveGrow) : base()
        {
            this.BaseInitialize(reserveNum, reserveGrow);

            this.pNodeCompare = new Texture();
        }
        public static void Destroy()
        {
            TextureManager tManager = TextureManager.getInstance();
            Debug.Assert(tManager != null);

            
        }
        public static Texture Add(Texture.Name name, string pTextureName)
        {
            TextureManager tManager = TextureManager.getInstance();
            Debug.Assert(tManager != null);

            Texture pNode = (Texture)tManager.baseAdd();
            Debug.Assert(pNode != null);

            // Initialize the data
            Debug.Assert(pTextureName != null);

            pNode.Set(name, pTextureName);

            return pNode;
        }
        public static Texture Find(Texture.Name name)
        {
            TextureManager tManager = TextureManager.getInstance();
            Debug.Assert(tManager != null);

            tManager.pNodeCompare.name = name;

            Texture pData = (Texture)tManager.baseFind(tManager.pNodeCompare);
            return pData;
        }
        public static void Remove(Texture pNode)
        {
            TextureManager tManager = TextureManager.getInstance();
            Debug.Assert(tManager != null);

            Debug.Assert(pNode != null);
            tManager.baseRemove(pNode);
        }
        public static void Dump()
        {
            TextureManager tManager = TextureManager.getInstance();
            Debug.Assert(tManager != null);

            tManager.baseDump();
        }
        // override abstract methods
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new Texture();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Texture pDataA = (Texture)pLinkA;
            Texture pDataB = (Texture)pLinkB;

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
            Texture pNode = (Texture)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Texture pData = (Texture)pLink;
            pData.Dump();
        }
    }
}
