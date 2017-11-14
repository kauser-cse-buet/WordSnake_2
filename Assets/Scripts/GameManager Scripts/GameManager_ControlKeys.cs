using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_ControlKeys : MonoBehaviour
    {

        private GameManager_Master gameManagerMaster;
        public GameObject panelGameControl;

        private void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GameControlUIToggleEvent += TurnOnGameControlUIPanel;
        }

        private void OnDisable()
        {
            gameManagerMaster.GameControlUIToggleEvent -= TurnOnGameControlUIPanel;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void TurnOnGameControlUIPanel()
        {
            if (panelGameControl != null)
            {
                panelGameControl.SetActive(!panelGameControl.activeSelf);   
            }
        }
    }
}
