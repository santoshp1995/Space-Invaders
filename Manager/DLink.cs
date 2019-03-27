
namespace SpaceInvaders
{
    public abstract class DLink
    {
       // DLink data
        public DLink pNext;
        public DLink pPrev;
        public int priority;
        public float floatPriority;
        protected DLink()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.pNext = null;
            this.pPrev = null;
            this.priority = 0;
            this.floatPriority = 0.0f;
        }
    }
}
