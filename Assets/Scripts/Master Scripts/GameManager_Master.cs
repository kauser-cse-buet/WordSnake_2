using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_Master : MonoBehaviour
    {
        public delegate void GameManagerEventHandler();
        public event GameManagerEventHandler MenuToggleEvent;
        public event GameManagerEventHandler InventoryUIToggleEvent;
        public event GameManagerEventHandler RestartLevelEvent;
        public event GameManagerEventHandler GoToMenuSceneEvent;
        public event GameManagerEventHandler GameOverEvent;
        public event GameManagerEventHandler GameControlUIToggleEvent;

        public bool isGameOver;
        public bool isInventoryUIOn;
        public bool isMenuOn;
        public bool isGameControlUIOn;

        public void CallEventMenuToggle() {
            if (MenuToggleEvent != null) {
                MenuToggleEvent();
            }
        }

        public void CallMenuToggleEvent()
        {
            if (MenuToggleEvent != null)
            {
                MenuToggleEvent();
            }
        }

        public void CallInventoryUIToggleEvent()
        {
            if (InventoryUIToggleEvent != null)
            {
                InventoryUIToggleEvent();
            }
        }

        public void CallRestartLevelEvent()
        {
            if (RestartLevelEvent != null)
            {
                RestartLevelEvent();
            }
        }

        public void CallGoToMenuSceneEvent()
        {
            if (GoToMenuSceneEvent != null)
            {
                GoToMenuSceneEvent();
            }
        }

        public void CallGameOverEvent()
        {
            if (GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }
        }

        public void CallGameControlUIToggleEvent()
        {
            if (GameControlUIToggleEvent != null)
            {
                isGameControlUIOn = true;
                GameControlUIToggleEvent();
            }
        }
    }

}


