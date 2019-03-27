using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ColObserver : DLink
    {
        public abstract void Notify();
        public virtual void Execute()
        {
            // default implementation
        }

        public ColSubject pSubject;
    }
}