using UnityEngine;

namespace S1
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;

        private void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.MenuToggleEvent += TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
        }

        private void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void TogglePlayerController()
        {
            Debug.LogWarning("Todo: Need to disable change character when space is pressed.");
        }
    }
}

