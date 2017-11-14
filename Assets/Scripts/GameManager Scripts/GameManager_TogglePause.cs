using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_TogglePause : MonoBehaviour
    {
        private GameManager_Master gameManageraMaster;
        private bool isPaused;
        private void OnEnable()
        {
            SetInitialReferences();
            gameManageraMaster.MenuToggleEvent += TogglePause;
            gameManageraMaster.InventoryUIToggleEvent+= TogglePause;
        }

        private void OnDisable()
        {
            gameManageraMaster.MenuToggleEvent -= TogglePause;
            gameManageraMaster.InventoryUIToggleEvent -= TogglePause;
        }

        void SetInitialReferences() {
            gameManageraMaster = GetComponent<GameManager_Master>();
        }

        void TogglePause() {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

}

