using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {
        // Data
        public GameObject.Name name;
        public float x;
        public float y;
        public ProxySprite pProxySprite;
        public ColObject poColObj;
        public bool bMarkForDeath;
        public static Random random = new Random();

        public enum Name
        {
            OctopusA,
            OctopusB,
            AlienA,
            AlienB,
            SquidA,
            SquidB,
           
            Ship,
            ShipRoot,

            Bomb,
            BombRoot,

            ShieldRoot,
            ShieldGrid,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldBrick,

            AlienGrid,
            AlienColumn1,
            AlienColumn2,
            AlienColumn3,
            AlienColumn4,
            AlienColumn5,
            AlienColumn6,
            AlienColumn7,
            AlienColumn8,
            AlienColumn9,
            AlienColumn10,
            AlienColumn11,

            WallGroup,
            WallRight,
            WallLeft,
            WallTop,
            WallDown,

            Missle,
            MissleGroup,


            NullObject,
            NullGrid,
            NullColumn,

            Uninitialized
        }


        protected GameObject(GameObject.Name gameName, GameSprite.Name spriteName)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.bMarkForDeath = false;
            this.pProxySprite = ProxySpriteManager.Add(spriteName);

            this.poColObj = new ColObject(this.pProxySprite);
            Debug.Assert(this.poColObj != null);
        }
        ~GameObject()
        {

        }
        public virtual void Remove()
        {
            // Remove from SpriteBatch
            Debug.Assert(this.pProxySprite != null);
            SBNode pSBNode = this.pProxySprite.GetSBNode();

            // remove it from manager
            Debug.Assert(pSBNode != null);
            SpriteBatchManager.Remove(pSBNode);

            // Remove Collision Sprite from sprite batch
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            pSBNode = this.poColObj.pColSprite.GetSBNode();

            Debug.Assert(pSBNode != null);
            SpriteBatchManager.Remove(pSBNode);

            // Remove from Game Object Manager
            GameObjectManager.Remove(this);


        }
        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;

            // point to ColTotal
            ColRect ColTotal = this.poColObj.poColRect;

            // Get the first child
            pNode = (GameObject)Iterator.GetChild(pNode);

            if (pNode != null)
            {
                // Initialized the union to the first block
                ColTotal.Set(pNode.poColObj.poColRect);

                // loop through sliblings
                while (pNode != null)
                {
                    ColTotal.Union(pNode.poColObj.poColRect);

                    // go to next sibling
                    pNode = (GameObject)Iterator.GetSibling(pNode);
                }
                this.x = this.poColObj.poColRect.x;
                this.y = this.poColObj.poColRect.y;
            }
        }
        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;

            Debug.Assert(this.poColObj != null);
            this.poColObj.UpdatePos(this.x, this.y);
            Debug.Assert(this.poColObj.pColSprite != null);
            this.poColObj.pColSprite.Update();
        }
        public void ActivateCollisionSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.poColObj != null);
            pSpriteBatch.Attach(this.poColObj.pColSprite);
        }
        public void ActivateGameSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.Attach(this.pProxySprite);
        }

        public void SetCollisionColor(float red, float green, float blue)
        {
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            this.poColObj.pColSprite.SetLineColor(red, green, blue);
        }
        public void Dump()
        {
            // Data:
            Debug.WriteLine("\t\t\t       name: {0} ({1})", this.name, this.GetHashCode());

            if (this.pProxySprite != null)
            {
                Debug.WriteLine("\t\t   pProxySprite: {0}", this.pProxySprite.name);
                Debug.WriteLine("\t\t    pRealSprite: {0}", this.pProxySprite.pSprite.GetName());
            }
            else
            {
                Debug.WriteLine("\t\t   pProxySprite: null");
                Debug.WriteLine("\t\t    pRealSprite: null");
            }
            Debug.WriteLine("\t\t\t      (x,y): {0}, {1}", this.x, this.y);

        }

        public ColObject GetColObject()
        {
            Debug.Assert(this.poColObj != null);
            return this.poColObj;
        }

        public GameObject.Name GetName()
        {
            return this.name;
        }
       
    }
}


