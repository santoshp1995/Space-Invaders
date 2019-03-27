using System.Diagnostics;

namespace SpaceInvaders
{
    class Sound : DLink
    {
        public IrrKlang.ISoundSource sndSource;
        public Name name;

        public enum Name
        {
            Alien_Walk1,
            Alien_Walk2,
            Alien_Walk3,
            Alien_Walk4,
            Player_Shoot,
            Alien_Killed,
            Explosions,
            UFO,
            Unitilizied
        }

        public Sound()
        {
            this.sndSource = null;
            this.name = Name.Unitilizied;
        }

        public void Set(Sound.Name name, IrrKlang.ISoundSource source)
        {
            this.name = name;

            Debug.Assert(source != null);
            this.sndSource = source;
        }

        public void PlaySound()
        {
            SoundManager pManager = SoundManager.getInstance();
            Debug.Assert(this.sndSource != null);

            IrrKlang.ISoundEngine engine = pManager.GetSoundEngine();
            engine.Play2D(this.sndSource, false, false, false);
        }
    }
}
