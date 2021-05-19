using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameTutorial : MonoBehaviour
    {
        public GameObject Player;
        public GameTutorialRecord[] Items;
        public Text Text;
        public GameObject Panel;

        private bool _needToShowNextText = false;
        private PlayerController _playerController;
        
        private void OnEnable()
        {
            _playerController = Player.GetComponent<PlayerController>();
            _playerController.canMove = false;
            StartCoroutine(ShowTextCoroutine());
        }

        private IEnumerator ShowTextCoroutine()
        {
            Panel.SetActive(true);
            foreach (var item in Items)
            {
                Text.text = item.Text;
                yield return new WaitForSeconds(item.TimeToWatch);
            }
            
            _playerController.canMove = true;
            Panel.SetActive(false);
        }
    }

    [Serializable]
    public class GameTutorialRecord
    {
        public string Text;
        public int TimeToWatch;
    }
}