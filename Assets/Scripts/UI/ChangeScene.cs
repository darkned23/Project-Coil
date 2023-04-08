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
        SceneManager.LoadScene(indexScene);
    }
}
