using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   
    public class GameObjectManager : Manager
    {
        // class data
        private static GameObjectManager pInstance = null;
        private GameObjectNode pNodeCompare;
        private readonly NullGameObject pNullGameObject;

        private GameObjectManager(int reserveNum, int reserveGrow) : base()
        {
            this.BaseInitialize(reserveNum, reserveGrow);

            this.pNodeCompare = new GameObjectNode();
            this.pNullGameObject = new NullGameObject();

            this.pNodeCompare.pGameObj = this.pNullGameObject; ;
        }

        private static GameObjectManager getInstance()
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
                pInstance = new GameObjectManager(reserveNum, reserveGrow);
            }
        }

        public static void Destroy()
        {

        }

        public static GameObjectNode Attach(GameObject pGameObject)
        {
            GameObjectManager pGameObjectMan = GameObjectManager.getInstance();
            Debug.Assert(pGameObjectMan != null);

            GameObjectNode pNode = (GameObjectNode)pGameObjectMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(pGameObject);
            return pNode;
        }

        public static GameObject Find(GameObject.Name name)
        {
            GameObjectManager pGameObjectMan = GameObjectManager.getInstance();
            Debug.Assert(pGameObjectMan != null);

            pGameObjectMan.pNodeCompare.pGameObj.name = name;

            GameObjectNode pNode = (GameObjectNode)pGameObjectMan.baseFind(pGameObjectMan.pNodeCompare);
            Debug.Assert(pNode != null);

            return pNode.pGameObj;
        }

        public static void Remove(GameObjectNode pNode)
        {
            GameObjectManager pGameObjectMan = GameObjectManager.getInstance();
            Debug.Assert(pGameObjectMan != null);

            Debug.Assert(pNode != null);
            pGameObjectMan.baseRemove(pNode);
        }

        public static void Remove(GameObject pNode)
        {
            Debug.Assert(pNode != null);
            GameObjectManager pGameObjectMan = GameObjectManager.getInstance();

            GameObject pSafetyNode = pNode;

            GameObject pTemp = pNode;
            GameObject pRoot = null;

            while(pTemp != null)
            {
                pRoot = pTemp;
                pTemp = (GameObject)Iterator.GetParent(pTemp);
            }

            GameObjectNode pTree = (GameObjectNode)pGameObjectMan.baseGetActive();

            while(pTree != null)
            {
                if(pTree.pGameObj == pRoot)
                {
                    // found it!
                    break;
                }

                // go to next tree
                pTree = (GameObjectNode)pTree.pNext;
            }

            Debug.Assert(pTree != null);
            Debug.Assert(pTree.pGameObj != null);

            Debug.Assert(pTree.pGameObj != pNode);

            GameObject pParent = (GameObject)Iterator.GetParent(pNode);
            Debug.Assert(pParent != null);

            GameObject pChild = (GameObject)Iterator.GetChild(pNode);
            Debug.Assert(pChild == null);

            // remove the node
            pParent.Remove(pNode);

            pParent.Update();
        }

        public static void Update()
        {
            GameObjectManager pGameObjectMan = GameObjectManager.getInstance();
            Debug.Assert(pGameObjectMan != null);

            GameObjectNode pGameObjectNode = (GameObjectNode)pGameObjectMan.baseGetActive();
            
            while(pGameObjectNode != null)
            {
                ReverseIterator pReverse = new ReverseIterator(pGameObjectNode.pGameObj);

                Component pNode = pReverse.First();
                while(!pReverse.IsDone())
                {
                    GameObject pGameObj = (GameObject)pNode;

                    pGameObj.Update();

                    pNode = pReverse.Next();
                }
                pGameObjectNode = (GameObjectNode)pGameObjectNode.pNext;
            }

        }

        public static void Dump()
        {
            GameObjectManager pGameObjectMan = GameObjectManager.getInstance();
            Debug.Assert(pGameObjectMan != null);

            pGameObjectMan.baseDump();
        }

        // override abstract methods

        override protected DLink derivedCreateNode()
        {
            DLink pNode = new GameObjectNode();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            GameObjectNode pDataA = (GameObjectNode)pLinkA;
            GameObjectNode pDataB = (GameObjectNode)pLinkB;

            Boolean status = false;

            if (pDataA.pGameObj.GetName() == pDataB.pGameObj.GetName())
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pNode = (GameObjectNode)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pData = (GameObjectNode)pLink;
            pData.Dump();
        }
    }
}
