using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_RestartLevel : MonoBehaviour
    {
        private GameManager_Master gamemanagerMaster;

        private void OnEnable()
        {
            SetInitialReferences();
            gamemanagerMaster.RestartLevelEvent += RestartLevel;
        }

        private void OnDisable()
        {
            gamemanagerMaster.RestartLevelEvent -= RestartLevel;
        }

        void SetInitialReferences() {
            gamemanagerMaster = GetComponent<GameManager_Master>();
        }

        void RestartLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
