using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNode : DLink
    {
        public GameObject pGameObj;

        public GameObjectNode() : base()
        {
            this.pGameObj = null;
        }

        ~GameObjectNode()
        {

        }
        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.pGameObj = pGameObject;
        }

        public void Wash()
        {
            this.pGameObj = null;
        }

        public Enum GetName()
        {
            return this.pGameObj.name;
        }

        public void Dump()
        {
            Debug.Assert(this.pGameObj != null);
            Debug.WriteLine("\t\t     GameObject: {0}", this.GetHashCode());

            this.pGameObj.Dump();
        }
    }
}
