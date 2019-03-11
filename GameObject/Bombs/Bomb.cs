using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombCategory
    {
        // data
        public float delta;
        private FallStrategy pStrategy;
        public Bomb(GameObject.Name gameName, GameSprite.Name spriteName,FallStrategy strategy, float posX, float posY)
            :base(gameName,spriteName, BombCategory.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 0.5f;

            Debug.Assert(strategy != null);
            this.pStrategy = strategy;

            this.pStrategy.Reset(this.y);

            this.poColObj.pColSprite.SetLineColor(0, 0, 0);
        }

        public void Reset()
        {
            this.y = 700.0f;
            this.pStrategy.Reset(this.y);
        }
        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // update the parent
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();


            // now remove object
            base.Remove();
        }

        public override void Update()
        {
            base.Update();
            this.y -= 0.5f;

            this.pStrategy.Fall(this);
        }

        public float GetBoundingBoxHeight()
        {
            return this.poColObj.poColRect.height;
        }
  

        ~Bomb()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitBomb(this);
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public override void VisitMissile(Missile missile)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(missile, this);
            pColPair.NotifyListeners();
        }

        public override void VisitShip(Ship ship)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(ship, this);
            pColPair.NotifyListeners();
            Sound shipHit = SoundManager.Find(Sound.Name.Explosions);
            shipHit.PlaySound();
            this.Remove();
        }
        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.pProxySprite != null);

            this.pProxySprite.sx *= sx;
            this.pProxySprite.sy *= sy;
        }
    }
}
