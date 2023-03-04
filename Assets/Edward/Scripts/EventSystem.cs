using UnityEngine;
using UnityEngine.SceneManagement;
public class EventSystem : MonoBehaviour
{
    //Metodo para cargar la misma escena
    public void ResetScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    //Metodo para cargar la siguiente escena
    public void NextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: +1);
    }
    //Metodo para cargar la anterior escena
    public void ReturnScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: -1);
    }
    //Metodo para cerrar el juego
    public void ExitGame()
    {
        Application.Quit();
    }
}