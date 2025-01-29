using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;
        public float musicFadeInTime = 1;

        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;
        public AudioSource musicAudioSource;

        private const float RELOAD_WAIT_TIME = 3;
    

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            musicAudioSource.volume = 0;
						musicAudioSource.DOFade(0.5f, musicFadeInTime);
				}

        public void GameOver()
        {
			playerGameObject.SetActive(false);
			GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
			deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
			player.deathState = false;
			StartCoroutine(ReloadLevelRoutine(RELOAD_WAIT_TIME));
		}

        public void CollectCoin()
        {
            coinsCounter++;
			coinText.text = coinsCounter.ToString(); 
		}

        IEnumerator ReloadLevelRoutine(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            ReloadLevel(SceneManager.GetActiveScene().buildIndex);
		}

        private void ReloadLevel(int levelIndex)
        {       
            SceneManager.LoadScene(levelIndex);
        }
    }
}
