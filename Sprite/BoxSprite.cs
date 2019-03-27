using System.Diagnostics;

namespace SpaceInvaders
{
    public class BoxSprite : SpriteBase
    {
        // class data
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public Name name;
        public Azul.Color pLineColor;
        private Azul.SpriteBox pAzulBoxSprite;
        static private Azul.Rect psTmpRect = new Azul.Rect();
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        public enum Name
        {
            Box,
            Box1,
            Box2,
            Box3,
            Box4,
            Uninitialized
        }

        public BoxSprite() : base()
        {
            this.name = BoxSprite.Name.Uninitialized;

            Debug.Assert(BoxSprite.psTmpRect != null);
            BoxSprite.psTmpRect.Set(0, 0, 1, 1);
            Debug.Assert(BoxSprite.psTmpColor != null);
            BoxSprite.psTmpColor.Set(1, 1, 1);

            // Here is the actual new
            this.pAzulBoxSprite = new Azul.SpriteBox(psTmpRect, psTmpColor);
            Debug.Assert(this.pAzulBoxSprite != null);

            // Here is the actual new
            this.pLineColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.pLineColor != null);

            this.x = pAzulBoxSprite.x;
            this.y = pAzulBoxSprite.y;
            this.sx = pAzulBoxSprite.sx;
            this.sy = pAzulBoxSprite.sy;
            this.angle = pAzulBoxSprite.angle;
        }

        public void Set(BoxSprite.Name name, float x, float y, float width, float height, Azul.Color pLineColor)
        {
            Debug.Assert(this.pAzulBoxSprite != null);
            Debug.Assert(this.pLineColor != null);

            Debug.Assert(psTmpRect != null);
            BoxSprite.psTmpRect.Set(x, y, width, height);

            this.name = name;

            if (pLineColor == null)
            {
                this.pLineColor.Set(1, 1, 1);
            }
            else
            {
                this.pLineColor.Set(pLineColor);
            }

            this.pAzulBoxSprite.Swap(psTmpRect, this.pLineColor);

            this.x = pAzulBoxSprite.x;
            this.y = pAzulBoxSprite.y;
            this.sx = pAzulBoxSprite.sx;
            this.sy = pAzulBoxSprite.sy;
            this.angle = pAzulBoxSprite.angle;
        }

        public void Set(BoxSprite.Name boxName, float x, float y, float width, float height)
        {
            Debug.Assert(this.pAzulBoxSprite != null);
            Debug.Assert(this.pLineColor != null);

            Debug.Assert(psTmpRect != null);
            BoxSprite.psTmpRect.Set(x, y, width, height);

            this.name = boxName;

            this.pAzulBoxSprite.Swap(psTmpRect, this.pLineColor);
            Debug.Assert(this.pAzulBoxSprite != null);

            this.x = pAzulBoxSprite.x;
            this.y = pAzulBoxSprite.y;
            this.sx = pAzulBoxSprite.sx;
            this.sy = pAzulBoxSprite.sy;
            this.angle = pAzulBoxSprite.angle;
        }
        private void privClear()
        {
            this.name = BoxSprite.Name.Uninitialized;

            this.pLineColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void SwapColor(Azul.Color pColor)
        {
            Debug.Assert(pColor != null);
            this.pAzulBoxSprite.SwapColor(pColor);
        }
        public void Wash()
        {
            this.privClear();
        }

        public override void Update()
        {
            this.pAzulBoxSprite.x = this.x;
            this.pAzulBoxSprite.y = this.y;
            this.pAzulBoxSprite.sx = this.sx;
            this.pAzulBoxSprite.sy = this.sy;
            this.pAzulBoxSprite.angle = this.angle;

            this.pAzulBoxSprite.Update();
        }

        public void SetLineColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.pLineColor != null);
            this.pLineColor.Set(red, green, blue, alpha);
        }

        public void SetScreenRect(float x, float y, float width, float height)
        {
            this.Set(this.name, x, y, width, height);
        }

        public override void Render()
        {
            this.pAzulBoxSprite.Render();
        }

        public void Dump()
        { 
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("      Color(r,b,g): {0},{1},{2} ({3})", this.pLineColor.red, this.pLineColor.green, this.pLineColor.blue, this.pLineColor.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.pAzulBoxSprite.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);

            if (this.pNext == null)
            {
                Debug.WriteLine("              next: null");
            }
            else
            {
                BoxSprite pTmp = (BoxSprite)this.pNext;
                Debug.WriteLine("              next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("              prev: null");
            }
            else
            {
                BoxSprite pTmp = (BoxSprite)this.pPrev;
                Debug.WriteLine("              prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }
        }
    }
}
