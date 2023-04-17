using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class EventSystem : MonoBehaviour
    {
        [SerializeField] private GameObject panelPause, panelGuia;
        private bool _isPanelActive;
        private float delay = 25f;

        [SerializeField] private float sceneActive;
        private void Start()
        {
            if (sceneActive == 3)
            {
                StartCoroutine(DelayCredits(delay));
            }
        }

        private void Update()
        {
            PauseInput();
            PauseInputGuia();
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
            if (Input.GetKeyDown(KeyCode.Escape) && sceneActive is 1 or 2 && _isPanelActive == false)
            {
                if (_isPanelActive)
                {
                    UnPause(panelPause);
                }
                else {
                    Pause(panelPause);
                }
            }
        }

        private void PauseInputGuia()
        {
            if (Input.GetKeyDown(KeyCode.G) && sceneActive is 1 or 2 && _isPanelActive == false)
            {
                if (_isPanelActive)
                {
                    UnPause(panelGuia);
                }
                else {
                    Pause(panelGuia);
                }
            }
        }
        public void Pause(GameObject panel)
        {
            Time.timeScale = 0;
            _isPanelActive = true;
            panel.SetActive(_isPanelActive);
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void UnPause(GameObject panel)
        {
            Time.timeScale = 1;
            _isPanelActive = false;
            panel.SetActive(_isPanelActive);
            Cursor.lockState = CursorLockMode.Locked;
        }

        private IEnumerator DelayCredits(float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(0);
        }
    }
}