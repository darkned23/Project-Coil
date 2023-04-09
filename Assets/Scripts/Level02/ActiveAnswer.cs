using UnityEngine;

public class ActiveAnswer : MonoBehaviour
{
    public Player.Player player;
    public Questions questions;
    public GameObject answerActive;
    public GameObject[] listAnswer;

    private void OnTriggerEnter(Collider other)
    {
        answerActive = listAnswer[questions.random];
        if (other.tag == "Player")
        {
            answerActive.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        answerActive.SetActive(false);
    }
}
