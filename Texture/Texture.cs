using System.Diagnostics;

namespace SpaceInvaders
{
    public class Texture : DLink
    {
        public Name name;
        private Azul.Texture pAzulTexture;
        static private readonly Azul.Texture psDefaultAzulTexture = new Azul.Texture("HotPink.tga");

        public enum Name
        {
            Default,
            SpaceInvaders,
            Birds,
            Consolas36pt,
            NullObject,
            Uninitialized
        }
        public Texture() : base()
        { 
            this.privClear();
        }
        public void Set(Name name, string pTextureName)
        {
            
            this.name = name;

            Debug.Assert(pTextureName != null);
            Debug.Assert(this.pAzulTexture != null);

            if (System.IO.File.Exists(pTextureName))
            {
                // Replace the Default with the new one
                this.pAzulTexture = new Azul.Texture(pTextureName, Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            }
            Debug.Assert(this.pAzulTexture != null);
        }
        private void privClear()
        {
            Debug.Assert(Texture.psDefaultAzulTexture != null);

            this.pAzulTexture = psDefaultAzulTexture;
            Debug.Assert(this.pAzulTexture != null);

            this.name = Name.Default;
        }
        public void Wash()
        {
            this.privClear();
        }
        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.pAzulTexture != null);
            return this.pAzulTexture;
        }
        public void Dump()
        { 
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            if (this.pAzulTexture != null)
            {
                Debug.WriteLine("   Texture: {0} ", this.pAzulTexture.GetHashCode());
            }
            else
            {
                Debug.WriteLine("   Texture: null ");
            }


            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Texture pTmp = (Texture)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                Texture pTmp = (Texture)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }
        }
    }
}
