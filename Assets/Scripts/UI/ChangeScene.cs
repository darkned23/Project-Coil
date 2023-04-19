using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int indexScene;
    [SerializeField] private AudioSource soundClick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goScene();
        }
    }
    public void goScene()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        StartCoroutine(DelayScene(0.5f, indexScene, soundClick));
    }

    private IEnumerator DelayScene(float delay, int nextScene, AudioSource click)
    {
        click.Play();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextScene);
    }
}
