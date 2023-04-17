using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class EventSystem : MonoBehaviour
    {
        [SerializeField] private GameObject panelPause;
        private bool _isPanelActive;
        private float delay = 10f;

        [SerializeField] private float sceneActive;
        private void Start()
        {
            if (sceneActive == 4)
            {
                Debug.Log("1");
                StartCoroutine(DelayCredits(delay));
            }
        }

        private void Update()
        {
            PauseInput();
        }

        public void ResetScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void NextScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void ExitGame()
        {
            Application.Quit();
            Debug.Log("Saliendo...");
        }
        private void PauseInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPanelActive)
                {
                    UnPause();
                }
                else {
                    Pause();
                }
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
            _isPanelActive = true;
            panelPause.SetActive(_isPanelActive);
            Cursor.lockState = CursorLockMode.Confined;
        
        }

        public void UnPause()
        {
            Time.timeScale = 1;
            _isPanelActive = false;
            panelPause.SetActive(_isPanelActive);
            Cursor.lockState = CursorLockMode.Locked;
        }

        private IEnumerator DelayCredits(float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(0);
        }
    }
}