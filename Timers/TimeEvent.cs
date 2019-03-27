using System.Diagnostics;

namespace SpaceInvaders
{
 
    public class TimeEvent : DLink
    {
        // TimeEvent class data
        public Name name;
        public Command pCommand;
        public float triggerTime;
        public float deltaTime;

        public enum Name
        {
            SpriteAnimation,
            SpriteMovement,
            UFOMovement,
            Uninitialized
        }

        public TimeEvent() : base()
        {
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public void Set(TimeEvent.Name eventName, Command pCommand, float deltaTimeToTrigger)
        {
            Debug.Assert(pCommand != null);

            this.name = eventName;
            this.pCommand = pCommand;
            this.deltaTime = deltaTimeToTrigger;

            // set the trigger time
            this.triggerTime = TimerManager.GetCurrTime() + deltaTimeToTrigger;
        }

        public void SetFloat(float deltaTime)
        {
            this.floatPriority = deltaTime;
        }
        public void Process()
        {
            // make certain that command is valid
            Debug.Assert(this.pCommand != null);

            this.pCommand.Execute(deltaTime);
        }

        public new void Clear()
        {
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public void Wash()
        {
            // wash - clear the entire hierarchy
            base.Clear();
            this.Clear();
        }

        public void Dump()
        {
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("      Command: {0}", this.pCommand);
            Debug.WriteLine("   Event Name: {0}", this.name);
            Debug.WriteLine(" Trigger Time: {0}", this.triggerTime);
            Debug.WriteLine("   Delta Time: {0}", this.deltaTime);

            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Image pTmp = (Image)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                Image pTmp = (Image)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }
        }
    }
}
