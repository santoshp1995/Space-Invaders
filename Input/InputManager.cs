using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        private InputManager()
        {
            this.pSubjectArrowLeft = new InputSubject();
            this.pSubjectArrowRight = new InputSubject();
            this.pSubjectSpace = new InputSubject();

            this.privSpaceKeyPrev = false;
        }

        private static InputManager privGetInstance()
        {
            if (pInstance == null)
            {
                pInstance = new InputManager();
            }
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static InputSubject GetArrowRightSubject()
        {
            InputManager pMan = InputManager.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputManager pMan = InputManager.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowLeft;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputManager pMan = InputManager.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectSpace;
        }

        public static void Update()
        {
            InputManager pMan = InputManager.privGetInstance();
            Debug.Assert(pMan != null);

            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.pSubjectArrowLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.pSubjectArrowRight.Notify();
            }

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if (spaceKeyCurr == true && pMan.privSpaceKeyPrev == false)
            {
                pMan.pSubjectSpace.Notify();
            }

            pMan.privSpaceKeyPrev = spaceKeyCurr;

        }

        // Data: ----------------------------------------------
        private static InputManager pInstance = null;
        private bool privSpaceKeyPrev;

        private InputSubject pSubjectArrowRight;
        private InputSubject pSubjectArrowLeft;
        private InputSubject pSubjectSpace;
    }
}
