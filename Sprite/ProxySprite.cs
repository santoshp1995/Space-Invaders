using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ProxySprite : SpriteBase
    {
        // class data
        public ProxySprite.Name name;
        public float sx;
        public float sy;
        public float x;
        public float y;
        public GameSprite pSprite;

        public enum Name
        {
            Proxy,
            Uninitialized
        }

        public ProxySprite() : base()
        {
            this.name = ProxySprite.Name.Uninitialized;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.pSprite = null;
        }

        ~ProxySprite()
        {

        }

        public ProxySprite(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;

            this.pSprite = GameSpriteManager.Find(name);
            Debug.Assert(pSprite != null);
        }

        public void Set(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;

            this.pSprite = GameSpriteManager.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public new void Clear()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.name = Name.Uninitialized;
            this.pSprite = null;
            this.sx = 1.0f;
            this.sy = 1.0f;
        }

        public void Wash()
        {
            base.Clear();
            this.Clear();
        }

        private void PrivPushToReal()
        {
            Debug.Assert(this.pSprite != null);

            this.pSprite.x = this.x;
            this.pSprite.y = this.y;
            this.pSprite.sx = this.sx;
            this.pSprite.sy = this.sy; 
        }

        public override void Update()
        {
            // push the data from Proxy to real Game Sprite
            this.PrivPushToReal();
            this.pSprite.Update();
        }

        public override void Render()
        {
            // moves value over to real sprite
            this.PrivPushToReal();

            this.pSprite.Update();
            this.pSprite.Render();
        }

        public void SetName(Name inName)
        {
            this.name = inName;
        }

        public Name GetName()
        {
            return this.name;
        }

        public void Dump()
        {

        }
    }
}
