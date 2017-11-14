using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace S1 {
    public class GameManager_GoToMenuScene : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;

        private void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
        }

        private void OnDisable()
        {
            gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;
        }

        private void SetInitialReferences() {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void GoToMenuScene() {
            Application.LoadLevel(0);
        }
    }
}
