namespace SpaceInvaders
{
    public class Scene
    {
        // scene data
        public SceneState pSceneState;
        public AttractMode pAttractMode;
        public Level1 pLv1;
        public Level2 pLv2;
        public GameWonState pGameWon;
        public GameLostState pGameLost;

        public enum SceneName
        {
            Attract,
            Level1,
            Level2,
            GameOver_GameWon,
            GameOver_GameLose
        }

        public Scene()
        {
            // reserve the diff scene states
            this.pAttractMode = new AttractMode();
            this.pLv1 = new Level1();
            this.pLv2 = new Level2();
            this.pGameWon = new GameWonState();
            this.pGameLost = new GameLostState();

            // initilize to the attract mode
            this.pSceneState = this.pAttractMode;
            this.pSceneState.Transition();
        }

        public SceneState GetState()
        {
            return this.pSceneState;
        }

        public void SetState(SceneName eScene)
        {
            switch(eScene)
            {
                case SceneName.Attract:
                    this.pSceneState = this.pAttractMode;
                    this.pSceneState.Transition();
                    break;

                case SceneName.Level1:
                    this.pSceneState = this.pLv1;
                    this.pSceneState.Transition();
                    break;

                case SceneName.Level2:
                    this.pSceneState = this.pLv2;
                    this.pLv2.Initialize();
                    this.pSceneState.Transition();
                    break;

                case SceneName.GameOver_GameWon:
                    this.pSceneState = this.pGameWon;
                    this.pSceneState.Transition();
                    break;

                case SceneName.GameOver_GameLose:
                    this.pSceneState = this.pGameLost;
                    this.pSceneState.Transition();
                    break;
            }
        }
    }
}
