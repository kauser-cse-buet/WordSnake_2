using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {
        [Tooltip("Does this game mode have an inventory? Set to true if that is the use")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameManagerMaster;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInventoryUIToggleRequest();
        }

        void SetInitialReferences() {
            gameManagerMaster = GetComponent<GameManager_Master>();

            if (toggleInventoryButton == "") {
                Debug.LogWarning("Please Type in the name of the button used to toggle the inventory in " +
                    "GameManager_ToggleInventoryUI.");
            }
        }

        void CheckForInventoryUIToggleRequest() {
            if (Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn && 
                !gameManagerMaster.isGameOver && hasInventory) {
                ToggleInventoryUI();
            }

        }

        void ToggleInventoryUI()
        {
            if (inventoryUI != null) {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
                gameManagerMaster.CallInventoryUIToggleEvent();
            }
        }
    }
}

