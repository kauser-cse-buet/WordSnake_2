using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_ToggleCursor : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        private bool isCursorLocked = true; 

        private void OnEnable()
        {
            SetInitialReference();
            gameManagerMaster.MenuToggleEvent += ToggleCursorState;
            gameManagerMaster.InventoryUIToggleEvent += ToggleCursorState;
        }

        private void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= ToggleCursorState;
            gameManagerMaster.InventoryUIToggleEvent -= ToggleCursorState;
        }

        // Update is called once per frame
        void Update()
        {
            CheckIfCursorShouldBeLocked();
        }

        void SetInitialReference() {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void ToggleCursorState() {
            isCursorLocked = !isCursorLocked;

        }

        void CheckIfCursorShouldBeLocked() {
            if (isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

}
