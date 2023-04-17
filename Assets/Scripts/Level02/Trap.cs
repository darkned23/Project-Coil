using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level02
{
    public class Trap : MonoBehaviour
    {
        public GameObject trap;
        public GameObject door;
        public Questions questions;
        public ActiveAnswer activeAnswer;
        public float delay = 3f;
    
        public Player.Player player;
        public void FalseAnswear()
        {
            Destroy(trap);
            questions.quienstionActive.SetActive(false);
            activeAnswer.answerActive.SetActive(false);
            StartCoroutine(LoadNextSceneAfterDelay(delay));
        }

        public void TrueAnswear()
        {
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
            Destroy(door);
            questions.quienstionActive.SetActive(false);
            activeAnswer.answerActive.SetActive(false);
        }

        IEnumerator LoadNextSceneAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
