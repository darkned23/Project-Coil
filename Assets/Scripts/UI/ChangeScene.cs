using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private byte indexScene;
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
        SceneManager.LoadScene(indexScene);
    }
}
