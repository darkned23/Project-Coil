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

        [SerializeField] private GameObject panelCorrect;
        [SerializeField] private float delayCorrect;

        [SerializeField] private AudioSource soundClick;
        private void Start()
        {
            if (sceneActive == 3)
            {
                StartCoroutine(DelayScene(delay, 0));
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
            StartCoroutine(DelayScene(0.5f, SceneManager.GetActiveScene().buildIndex));
        }
        public void NextScene()
        {
            Time.timeScale = 1;
            StartCoroutine(DelayScene(0.5f, SceneManager.GetActiveScene().buildIndex + 1));
        }
        public void ExitGame()
        {
            PlaySoundClick(soundClick);
            Application.Quit();
            Debug.Log("Saliendo...");
        }
        private void PauseInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && sceneActive is 1 or 2 && _isPanelActive == false)
            {
                if (_isPanelActive)
                {
                    PlaySoundClick(soundClick);
                    UnPause(panelPause);
                }
                else {
                    PlaySoundClick(soundClick);
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
                    PlaySoundClick(soundClick);
                    UnPause(panelGuia);
                }
                else {
                    PlaySoundClick(soundClick);
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

        private IEnumerator DelayScene(float delay, int nextScene)
        {
            PlaySoundClick(soundClick);
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(nextScene);
        }

        public void ActiveCorrect()
        {
            panelCorrect.SetActive(true);
            StartCoroutine(DelayCorrect(delayCorrect, panelCorrect));
        }
        private IEnumerator DelayCorrect(float delay, GameObject panel)
        {
            PlaySoundClick(soundClick);
            yield return new WaitForSeconds(delay);
            panel.SetActive(false);
        }

        public void PlaySoundClick(AudioSource sound)
        {
            sound.Play();
        }
    }
}