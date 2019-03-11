using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        public ShieldFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, Composite pTree)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteBatchManager.Find(collisionSpriteBatch);
            Debug.Assert(this.pCollisionSpriteBatch != null);

            Debug.Assert(pTree != null);
            this.pTree = pTree;
        }
        public void SetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }
        ~ShieldFactory()
        {
            this.pSpriteBatch = null;
        }
        public GameObject Create(ShieldCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pShield = null;

            switch (type)
            {
                case ShieldCategory.Type.Brick:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop1:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftTop1, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop0:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftTop0, posX, posY);
                    break;

                case ShieldCategory.Type.LeftBottom:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftBottom, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop1:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightTop1, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop0:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightTop0, posX, posY);
                    break;

                case ShieldCategory.Type.RightBottom:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightBottom, posX, posY);
                    break;

                case ShieldCategory.Type.Root:
                    pShield = new ShieldRoot(gameName, GameSprite.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    Debug.Assert(false);
                    break;
                case ShieldCategory.Type.Grid:
                    pShield = new ShieldGrid(gameName, GameSprite.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    break;

                case ShieldCategory.Type.Column:
                    pShield = new ShieldColumn(gameName, GameSprite.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(1.0f, 0.0f, 0.0f);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add to the tree
            this.pTree.Add(pShield);

            // Attached to Group
            pShield.ActivateGameSprite(this.pSpriteBatch);
            pShield.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pShield;
        }

        // Data: ---------------------
        private SpriteBatch pSpriteBatch;
        private readonly SpriteBatch pCollisionSpriteBatch;
        private Composite pTree;
    }
}

// End of File
