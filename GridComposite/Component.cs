using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Component : ColVisitor
    {
        public Component pParent = null;
        public Component pReverse = null;
        public Container holder = Container.Unknown;

        public enum Container
        {
            Leaf,
            Composite,
            Unknown
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Print();
        public abstract Component GetFirstChild();

        
    }
}
