using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColPair : DLink
    {
        public enum Name
        {
            Alien_Missile,
            Alien_Wall,
            Alien_Shield,
            Missile_Wall,
            Ship_Wall,
            Ship_Bomb,
            Bomb_Wall,
            Bomb_Shield,
            Missile_Shield,
            Missile_Bomb,
            Missile_UFO,
            Missile_NULL,
            NullObject,
            Not_Initialized
        }
        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;

            this.poSubject = new ColSubject();
            Debug.Assert(this.poSubject != null);
        }
        ~ColPair()
        {
        }
        public void Set(ColPair.Name colpairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = colpairName;
        }
        public void Wash()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }
        public ColPair.Name GetName()
        {
            return this.name;
        }
        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }
        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // who is being tested?
                    // Debug.WriteLine("ColPair:    test:  {0}, {1}", pNodeA.name, pNodeB.name);

                    // Get rectangles
                    ColRect rectA = pNodeA.GetColObject().poColRect;
                    ColRect rectB = pNodeB.GetColObject().poColRect;

                    // test them
                    if (ColRect.Intersect(rectA, rectB))
                    {
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)Iterator.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)Iterator.GetSibling(pNodeA);
            }
        }
        public void SetName(ColPair.Name inName)
        {
            this.name = inName;
        }
        public void Attach(ColObserver observer)
        {
            this.poSubject.Attach(observer);
        }
        public void NotifyListeners()
        {
            this.poSubject.Notify();
        }
        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            this.poSubject.pObjA = pObjA;
            this.poSubject.pObjB = pObjB;
        }
        public void Dump()
        {
            // TO DO ...
        }

        // Data: ---------------
        public ColPair.Name name;
        public GameObject treeA;
        public GameObject treeB;
        public ColSubject poSubject;
    }
}

// End of File
