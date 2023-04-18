using UnityEngine;

public class ActiveAnswer : MonoBehaviour
{
    public Player.Player player;
    public Questions questions;
    public GameObject answerActive;
    public GameObject[] listAnswer;
    private bool isAnswerActive = false;

    private void OnTriggerEnter(Collider other)
    {
        answerActive = listAnswer[questions.random];
        if (other.tag == "Player" && isAnswerActive == false)
        {
            answerActive.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.enabled = false;
            isAnswerActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        answerActive.SetActive(false);
    }
}
