using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameSprite : SpriteBase
    {
        // class data
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public Name name;
        public Image pImage;
        private readonly Azul.Color pAzulColor;
        private Azul.Sprite pAzulSprite;
        private readonly Azul.Rect pScreenRect;

        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        public enum Name
        {
            OctopusA,
            OctopusB,
            AlienA,
            AlienB,
            Player,
            PlayerShot,
            Saucer,
            Wall,

            SquigglyShotA,
            SquigglyShotB,
            SquigglyShotC,
            SquigglyShotD,
            PlungerShotA,
            PlungerShotB,
            PlungerShotC,
            PlungerShotD,
            RollingShotA,
            RollingShotB,
            RollingShotC,
            RollingShotD,
            AlienShotExplosion,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            SquidA,
            SquidB,

            NullObject,
            Uninitialized
        }

       
        public GameSprite() : base()  
        {
            this.name = GameSprite.Name.Uninitialized;
            this.pImage = ImageManager.Find(Image.Name.Default);

            Debug.Assert(this.pImage != null);


            this.pScreenRect = new Azul.Rect();
            Debug.Assert(this.pScreenRect != null);
            this.pScreenRect.Clear();

            // here is the actual new
            this.pAzulColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.pAzulColor != null);

            // here is the actual new
            this.pAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.pScreenRect, psTmpColor);
            Debug.Assert(this.pAzulSprite != null);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
        }

        public void Set(GameSprite.Name name, Image pImage, float x, float y, float width, float height, Azul.Color pColor)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(this.pScreenRect != null);
            Debug.Assert(this.pAzulSprite != null);

            this.pScreenRect.Set(x, y, width, height);
            this.pImage = pImage;
            this.name = name;

            if (pColor == null)
            {
                Debug.Assert(GameSprite.psTmpColor != null);
                GameSprite.psTmpColor.Set(1, 1, 1);

                this.pAzulColor.Set(psTmpColor);
            }
            else
            {
                this.pAzulColor.Set(pColor);
            }

            this.pAzulSprite.Swap(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.pScreenRect, this.pAzulColor);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
        }

        public void SetName(GameSprite.Name inName)
        {
            this.name = inName;
        }

        public GameSprite.Name GetName()
        {
            return this.name;
        }
        public override void Update()
        {
            this.pAzulSprite.x = this.x;
            this.pAzulSprite.y = this.y;
            this.pAzulSprite.sx = this.sx;
            this.pAzulSprite.sy = this.sy;
            this.pAzulSprite.angle = this.angle;

            this.pAzulSprite.Update();
        }

        public Azul.Rect GetScreenRect()
        {
            Debug.Assert(this.pScreenRect != null);
            return this.pScreenRect;
        }
        public void SwapImage(Image pSwapImage)
        {
            Debug.Assert(this.pAzulSprite != null);
            Debug.Assert(pSwapImage != null);
            this.pImage = pSwapImage;

            this.pAzulSprite.SwapTexture(this.pImage.GetAzulTexture());
            this.pAzulSprite.SwapTextureRect(this.pImage.GetAzulRect());
        }
        public override void Render()
        {
            this.pAzulSprite.Render();
        }

        private void privClear()
        {
            this.pImage = null;
            this.name = GameSprite.Name.Uninitialized;

            Debug.Assert(this.pAzulColor != null);
            this.pAzulColor.Set(1, 1, 1);
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void Wash()
        {
            this.privClear();
        }
        public void Dump()
        {
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("             Image: {0} ({1})", this.pImage.name, this.pImage.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.pAzulSprite.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);


            if (this.pNext == null)
            {
                Debug.WriteLine("              next: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pNext;
                Debug.WriteLine("              next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("              prev: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pPrev;
                Debug.WriteLine("              prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }
        }
    }
}
