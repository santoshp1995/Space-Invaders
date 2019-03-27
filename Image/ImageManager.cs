using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageManager : Manager
    {
        // manager class data
        private static ImageManager pInstance = null;
        private readonly Image pNodeCompare;

        private static ImageManager getInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private ImageManager(int reserveNum, int reserveGrow) : base()
        {
            this.BaseInitialize(reserveNum, reserveGrow);

            this.pNodeCompare = new Image();
        }

        public static void Create(int reserveNum, int reserveGrow)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new ImageManager(reserveNum, reserveGrow);
            }

            Image pImage = ImageManager.Add(Image.Name.NullObject, Texture.Name.NullObject, 0, 0, 128, 128);
            Debug.Assert(pImage != null);

            // Default image manager
            pImage = ImageManager.Add(Image.Name.Default, Texture.Name.Default, 0, 0, 128, 128);
            Debug.Assert(pImage != null);
        }
        public static void Destroy()
        {
            ImageManager pMan = ImageManager.getInstance();
            Debug.Assert(pMan != null);
        }
        public static Image Add(Image.Name ImageName, Texture.Name TextureName, float x, float y, float width, float height)
        {
            ImageManager pMan = ImageManager.getInstance();
            Debug.Assert(pMan != null);

            Image pNode = (Image)pMan.baseAdd();
            Debug.Assert(pNode != null);

            Texture pTexture = TextureManager.Find(TextureName);
            Debug.Assert(pTexture != null);

            pNode.Set(ImageName, pTexture, x, y, width, height);

            return pNode;
        }
        public static Image Find(Image.Name name)
        {
            ImageManager pMan = ImageManager.getInstance();
            Debug.Assert(pMan != null);

            pMan.pNodeCompare.name = name;

            Image pData = (Image)pMan.baseFind(pMan.pNodeCompare);
            return pData;
        }
        public static void Remove(Image pNode)
        {
            ImageManager pMan = ImageManager.getInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Dump()
        {
            ImageManager pMan = ImageManager.getInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        // overriding abstract methods

        override protected DLink derivedCreateNode()
        {
            DLink pNode = new Image();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Image pDataA = (Image)pLinkA;
            Image pDataB = (Image)pLinkB;

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
            Image pNode = (Image)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Image pData = (Image)pLink;
            pData.Dump();
        }
    }
}
