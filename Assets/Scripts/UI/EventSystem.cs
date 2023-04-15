using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class EventSystem : MonoBehaviour
    {
        [SerializeField] private GameObject panelPause;
        private bool _isPanelActive;

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
    }
}