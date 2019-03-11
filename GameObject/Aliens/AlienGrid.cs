using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {
       
        private float delta;
        
        public AlienGrid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
        : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(1, 0, 1);

            this.delta = 10.0f;
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup group)
        {
            // Alien Group vs Missile Group
            Debug.WriteLine("         collide:  {0} <-> {1}", group.name, this.name);

            // Missile Group vs Columns
            GameObject pGameObject = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(group, pGameObject);

            
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);


            base.Update();
        }

        public void MoveGrid()
        {
            ForwardIterator pFor = new ForwardIterator(this);

            Component pNode = pFor.First();
            while(!pFor.IsDone())
            {
                GameObject pGameObject = (GameObject)pNode;
                pGameObject.x += delta;

                pNode = pFor.Next();
            }
        }

        public void MoveGridDown()
        {
            ForwardIterator pFor = new ForwardIterator(this);

            Component pNode = pFor.First();
            while(!pFor.IsDone())
            {
                GameObject pGameObject = (GameObject)pNode;
                pGameObject.y -= 10.0f;

                pNode = pFor.Next();
            }
        }

        public void SetDelta(float currDelta)
        {
            this.delta = currDelta;
        }
    }
}
