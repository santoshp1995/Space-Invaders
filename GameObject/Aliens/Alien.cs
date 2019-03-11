namespace SpaceInvaders
{
    abstract public class Alien : Leaf
    {
        

        public enum Type
        {
            Crab,
            Octopus,
            Squid,
            Column,
            Grid,
        }
           
        public Alien(GameObject.Name name, GameSprite.Name spriteName)
            : base(name, spriteName)
        {

        }

        public void DropBomb()
        {
            BombRoot root = (BombRoot)GameObjectManager.Find(Name.BombRoot);

            int alienBomb = random.Next(1, 4);

            if (alienBomb == 1)
            {
                Bomb pBombStraight = new Bomb(GameObject.Name.Bomb, GameSprite.Name.RollingShotC, new FallStraight(), this.x, this.y);
                pBombStraight.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));
                pBombStraight.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders));
                root.Add(pBombStraight);
            }
            
            else if(alienBomb == 2)
            {
                Bomb pBombDagger = new Bomb(GameObject.Name.Bomb, GameSprite.Name.PlungerShotA, new FallDagger(), this.x, this.y);
                pBombDagger.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));
                pBombDagger.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders));
                root.Add(pBombDagger);
            }

            else
            {
                Bomb pBombZigZag = new Bomb(GameObject.Name.Bomb, GameSprite.Name.SquigglyShotD, new FallZigZag(), this.x, this.y);
                pBombZigZag.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));
                pBombZigZag.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders));
                root.Add(pBombZigZag);
            }

            GameObjectManager.Attach(root);
        }
    }
}

