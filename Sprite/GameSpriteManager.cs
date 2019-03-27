using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameSpriteManager : Manager
    {
        // class data
        private static GameSpriteManager pInstance = null;
        private readonly GameSprite pNodeCompare;

        private GameSpriteManager(int reserveNum, int reserveGrow) : base()
        {
            this.BaseInitialize(reserveNum, reserveGrow);

            this.pNodeCompare = new GameSprite();
        }

        public static void Create(int reserveNum, int reserveGrow)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new GameSpriteManager(reserveNum, reserveGrow);
            }

            // add null sprite - allows find
            GameSprite pGameSprite = GameSpriteManager.Add(GameSprite.Name.NullObject, Image.Name.NullObject, 0, 0, 0, 0);
            Debug.Assert(pGameSprite != null);
        }
        public static void Destroy()
        {
            GameSpriteManager gameSpriteManager = GameSpriteManager.privGetInstance();
            Debug.Assert(gameSpriteManager != null);

        }
        public static GameSprite Add(GameSprite.Name name, Image.Name ImageName, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            GameSpriteManager gameSpriteManager = GameSpriteManager.privGetInstance();
            Debug.Assert(gameSpriteManager != null);

            GameSprite pNode = (GameSprite)gameSpriteManager.baseAdd();
            Debug.Assert(pNode != null);

            Image pImage = ImageManager.Find(ImageName);
            Debug.Assert(pImage != null);

            pNode.Set(name, pImage, x, y, width, height, pColor);

            return pNode;
        }
        public static GameSprite Find(GameSprite.Name name)
        {
            GameSpriteManager gameSpriteManager = GameSpriteManager.privGetInstance();
            Debug.Assert(gameSpriteManager != null);

            gameSpriteManager.pNodeCompare.name = name;

            GameSprite pData = (GameSprite)gameSpriteManager.baseFind(gameSpriteManager.pNodeCompare);
            return pData;
        }
        public static void Remove(GameSprite pNode)
        {
            GameSpriteManager gameSpriteManager = GameSpriteManager.privGetInstance();
            Debug.Assert(gameSpriteManager != null);

            Debug.Assert(pNode != null);
            gameSpriteManager.baseRemove(pNode);
        }
        public static void Dump()
        {
            GameSpriteManager gameSpriteManager = GameSpriteManager.privGetInstance();
            Debug.Assert(gameSpriteManager != null);

            gameSpriteManager.baseDump();
        }

        // overriding abstract methods
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new GameSprite();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            GameSprite pDataA = (GameSprite)pLinkA;
            GameSprite pDataB = (GameSprite)pLinkB;

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
            GameSprite pNode = (GameSprite)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameSprite pData = (GameSprite)pLink;
            pData.Dump();
        }
        private static GameSpriteManager privGetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }
    }
}
