using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        private readonly SpriteBatch pSpriteBatch;
        private readonly SpriteBatch pSpriteBatchBox;

        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pSpriteBatchBox = SpriteBatchManager.Find(boxSpriteBatchName);
            Debug.Assert(this.pSpriteBatchBox != null);

        }

        ~AlienFactory()
        {

        }

        public GameObject Create(GameObject.Name name, Alien.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case Alien.Type.Squid:
                    pGameObj = new SquidAlien(name, GameSprite.Name.SquidA, posX, posY);
                    break;

                case Alien.Type.Crab:
                    pGameObj = new CrabAlien(name, GameSprite.Name.AlienA, posX, posY);
                    break;

                case Alien.Type.Octopus:
                    pGameObj = new OctopusAlien(name, GameSprite.Name.OctopusA, posX, posY);
                    break;

                case Alien.Type.Grid:
                    pGameObj = new AlienGrid(name, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    break;

                case Alien.Type.Column:
                    pGameObj = new AlienColumn(name, GameSprite.Name.NullObject, 0.0f, 0.0f);

                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
           

            // Attached to Group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pSpriteBatchBox);


            return pGameObj;
        }
    }
}