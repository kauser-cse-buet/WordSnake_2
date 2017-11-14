using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManageraMaster;
        public GameObject menu;

        // Use this for initialization
        void Start()
        {
            ToggleMenu();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForMenuToggleRequest();
        }

        private void OnEnable()
        {
            SetInitialReferences();
            gameManageraMaster.GameOverEvent += ToggleMenu;

            
        }

        private void OnDisable()
        {
            gameManageraMaster.GameOverEvent -= ToggleMenu;
        }

        void SetInitialReferences()
        {
            gameManageraMaster = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest() {
            if (Input.GetKeyUp(KeyCode.Escape) && !gameManageraMaster.isGameOver && !gameManageraMaster.isInventoryUIOn) {
                ToggleMenu();
            }
        }

        void ToggleMenu()
        {
            if (menu != null)
            {
                menu.SetActive(!menu.activeSelf);
                gameManageraMaster.isMenuOn = !gameManageraMaster.isMenuOn;
                gameManageraMaster.CallEventMenuToggle();
            }
            else {
                Debug.LogWarning("You need to assign a ui game object to the Toggle menu script in the inspector.");

            }
        }
    }

}

