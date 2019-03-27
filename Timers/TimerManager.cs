using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerManager : Manager
    {
        // class data
        private static TimerManager pInstance = null;
        private TimeEvent pNodeCompare;
        protected float mCurrTime;

        private static TimerManager getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private TimerManager(int reserveNum, int growthSize) : base()
        {
            this.BaseInitialize(reserveNum, growthSize);

            this.pNodeCompare = new TimeEvent();
        }

        public static void Create(int reserveNum, int growthSize)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(growthSize > 0);

            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new TimerManager(reserveNum, growthSize);
            }
        }
        
        public static TimeEvent Add(TimeEvent.Name name, Command pCommand, float deltaTimeToTrigger)
        {
            TimerManager tMan = TimerManager.getInstance();
            Debug.Assert(tMan != null);

            TimeEvent pNode = (TimeEvent)tMan.sortedTimerAdd(deltaTimeToTrigger);
            Debug.Assert(pNode != null);

            Debug.Assert(pCommand != null);
            Debug.Assert(deltaTimeToTrigger >= 0.0f);

            pNode.SetFloat(deltaTimeToTrigger);

            pNode.Set(name, pCommand, deltaTimeToTrigger);
            return pNode;
        }

        public static TimeEvent Find(TimeEvent.Name name)
        {
            TimerManager tMan = TimerManager.getInstance();
            Debug.Assert(tMan != null);

            Debug.Assert(tMan.pNodeCompare != null);
            tMan.pNodeCompare.Wash();
            tMan.pNodeCompare.name = name;

            TimeEvent pData = (TimeEvent)tMan.baseFind(tMan.pNodeCompare);
            return pData;
        }

        public static void Remove(TimeEvent pNode)
        {
            TimerManager tMan = TimerManager.getInstance();
            Debug.Assert(tMan != null);

            Debug.Assert(pNode != null);
            tMan.baseRemove(pNode);
        }

        public static void Dump()
        {
            TimerManager tMan = TimerManager.getInstance();
            Debug.Assert(tMan != null);

            tMan.baseDump();
        }

        public static void Update(float totalTime)
        {
            TimerManager tMan = TimerManager.getInstance();
            Debug.Assert(tMan != null);

            tMan.mCurrTime = totalTime;

            // walk the list
            TimeEvent pEvent = (TimeEvent)tMan.baseGetActive();
            TimeEvent pNextEvent = null;

            // Walk the list until there is no more list OR currTime > timeEvent
            //TODO list should be sorted
            while(pEvent != null && (tMan.mCurrTime >= pEvent.triggerTime))
            {
                // Difficult to walk a list and remove itself from the list
                // so squirrel away the next event now, use it at bottom of while
                pNextEvent = (TimeEvent)pEvent.pNext;

                if(tMan.mCurrTime >= pEvent.triggerTime)
                {
                    // call it
                    pEvent.Process();

                    // remove from list
                    tMan.baseRemove(pEvent);
                }

                // advance the pointer
                pEvent = pNextEvent;
            }
        }

        public static float GetCurrTime()
        {
            TimerManager pTMan = TimerManager.getInstance();

            // return time
            return pTMan.mCurrTime;
        }

        // overriding the abstract methods
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new TimeEvent();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            TimeEvent pDataA = (TimeEvent)pLinkA;
            TimeEvent pDataB = (TimeEvent)pLinkB;

            bool status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TimeEvent pNode = (TimeEvent)pLink;
            pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TimeEvent pData = (TimeEvent)pLink;
            pData.Dump();
        }
    }
}
