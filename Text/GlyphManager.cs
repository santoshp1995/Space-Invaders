using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GlyphManager : Manager
    {
        // class data
        private static GlyphManager pInstance = null;
        private Glyph pRefNode;

        private static GlyphManager getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private GlyphManager(int reserveNum, int growthSize) : base()
        {
            this.BaseInitialize(reserveNum, growthSize);

            this.pRefNode = (Glyph)this.derivedCreateNode();
        }

        ~GlyphManager()
        {

        }

        public static void Create(int reserveNum, int reserveGrow )
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // init the singleton here
            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new GlyphManager(reserveNum, reserveGrow);
            }
        }

        public static void Destroy()
        {

        }

        public static Glyph Add(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphManager pGlyphMan = GlyphManager.getInstance();

            Glyph pNode = (Glyph)pGlyphMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, key, textName, x, y, width, height);
            return pNode;
        }

        public static void AddXML(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            GlyphManager.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            GlyphManager pGlyphMan = GlyphManager.getInstance();
            pGlyphMan.baseRemove(pNode);
        }

        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphManager pGlyphMan = GlyphManager.getInstance();

            // Compare functions only compares two Nodes
            pGlyphMan.pRefNode.name = name;
            pGlyphMan.pRefNode.key = key;

            Glyph pData = (Glyph)pGlyphMan.baseFind(pGlyphMan.pRefNode);
            return pData;
        }

        // Overriding abstract methods
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Glyph pDataA = (Glyph)pLinkA;
            Glyph pDataB = (Glyph)pLinkB;

            Boolean status = false;

            if (pDataA.name == pDataB.name && pDataA.key == pDataB.key)
            {
                status = true;
            }

            return status;
        }

        override protected DLink derivedCreateNode()
        {
            DLink pNode = new Glyph();
            Debug.Assert(pNode != null);
            return pNode;
        }

        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Glyph pNode = (Glyph)pLink;
            pNode.Wash();
        }

        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Glyph pNode = (Glyph)pLink;

            Debug.Assert(pNode != null);
           
        }
    }
}
