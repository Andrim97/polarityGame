using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AGDDPlatformer
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [Header("Players")]
        public PlayerController[] players;

        [Header("Level")]
        public PlayerGoal[] playerGoals;
        public bool timeStopped;
        public bool isGameComplete;
        public string firstLevel;
        public string nextLevel;

        [Header("Level Transition")]
        public GameObject startScreen;
        public GameObject endScreen;
        public GameObject gameOverScreen;
        public float startScreenTime = 1.0f;
        public float endScreenDelay = 1.0f;
        public float endScreenTime = 1.0f;

        [Header("Audio")]
        public AudioSource source;
        public AudioClip winSound;

        void Awake()
        {
            instance = this;

            if (playerGoals.Length == 0)
            {
                playerGoals = FindObjectsOfType<PlayerGoal>();
            }
        }

        IEnumerator Start()
        {
            timeStopped = true;

            endScreen.SetActive(false);
            gameOverScreen.SetActive(false);

            startScreen.SetActive(true);

            yield return new WaitForSeconds(startScreenTime);

            startScreen.SetActive(false);

            timeStopped = false;
        }

        void Update()
        {
            if (isGameComplete)
            {
                if (Input.GetButtonDown("Reset"))
                {
                    ResetGame();
                }
            }

            if (timeStopped)
                return;

            /* --- Check Player Goals --- */

            bool allGoalsSatisfied = true;
            foreach (PlayerGoal playerGoal in playerGoals)
            {
                if (!playerGoal.isSatisfied)
                {
                    allGoalsSatisfied = false;
                    break;
                }
            }

            if (allGoalsSatisfied)
            {
                source.PlayOneShot(winSound);
                StartCoroutine(LevelCompleted());
            }

            if (Input.GetButtonDown("Reset"))
            {
                ResetLevel();
            }
        }

        IEnumerator LevelCompleted()
        {
            timeStopped = true;

            yield return new WaitForSeconds(endScreenDelay);

            endScreen.SetActive(true);

            yield return new WaitForSeconds(endScreenTime);

            if (!string.IsNullOrEmpty(nextLevel))
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                isGameComplete = true;
                gameOverScreen.SetActive(true);
            }
        }

        void ResetGame()
        {
            SceneManager.LoadScene(firstLevel);
        }

        void ResetLevel()
        {
            foreach (PlayerController player in players)
            {
                player.ResetPlayer();
            }
        }
    }
}
