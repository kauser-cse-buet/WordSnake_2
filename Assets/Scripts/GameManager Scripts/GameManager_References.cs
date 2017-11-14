using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S1 {
    public class GameManager_References : MonoBehaviour
    {
        public string playerTag;
        public static string _playerTag;

        public static GameObject _player;

        private void OnEnable()
        {
            if (playerTag == "")
            {
                Debug.LogWarning("Please type in the name of the player tag in the GameManager_References" +
                    "Slot in the inspector or else the Main S1 will not work.");
            }

            _playerTag = playerTag;

            _player = GameObject.FindGameObjectWithTag(_playerTag);
        }

        private void OnDisable()
        {
            
        }
    }

}

