using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundManager : Manager
    {
        // class data
        private static SoundManager pInstance;
        private IrrKlang.ISoundEngine sndEngine;
        private Sound pRefNode;
        
        public static SoundManager getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static void Create(int reserveNum, int growthSize)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(growthSize > 0);

            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new SoundManager(reserveNum, growthSize);
            }
        }

        private SoundManager(int reserveNum, int growthSize) : base()
        {
            this.BaseInitialize(reserveNum, growthSize);

            this.sndEngine = new IrrKlang.ISoundEngine();
            this.pRefNode = (Sound)this.derivedCreateNode();
        }

        public static Sound Add(Sound.Name name, string pAudioName)
        {
            SoundManager pSoundManager = SoundManager.getInstance();
            Debug.Assert(pSoundManager != null);

            Sound pNode = (Sound)pSoundManager.baseAdd();
            Debug.Assert(pNode != null);

            Debug.Assert(pAudioName != null);

            pNode.Set(name, pSoundManager.sndEngine.AddSoundSourceFromFile(pAudioName));

            return pNode;
        }

        public static Sound Find(Sound.Name name)
        {
            SoundManager pSoundManager = SoundManager.getInstance();
            Debug.Assert(pSoundManager != null);

            pSoundManager.pRefNode.name = name;

            Sound pData = (Sound)pSoundManager.baseFind(pSoundManager.pRefNode);
            return pData;
        }

        public static void Remove(Sound pNode)
        {
            SoundManager pSoundManager = SoundManager.getInstance();
            Debug.Assert(pSoundManager != null);

            Debug.Assert(pNode != null);

            pSoundManager.baseRemove(pNode);
        }

        public IrrKlang.ISoundEngine GetSoundEngine()
        {
            return this.sndEngine;
        }

        // overriding abstract methods
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new Sound();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Sound pDataA = (Sound)pLinkA;
            Sound pDataB = (Sound)pLinkB;

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
            Sound pNode = (Sound)pLink;
           // pNode.Wash();
        }
        override protected void derivedDumpNode(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Sound pData = (Sound)pLink;
            //pData.Dump();
        }
    }
}
