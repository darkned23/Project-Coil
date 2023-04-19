using UnityEngine;

public class Questions : MonoBehaviour
{
    public GameObject[] questionsCollection;
    public GameObject quienstionActive;
    public int random;
    private bool isCorrect = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (isCorrect == false) )
        {
            RandomQuiestion();
            isCorrect = true;
        }
    }
    void RandomQuiestion()
    {
        random = Random.Range(0, questionsCollection.Length);
        quienstionActive = questionsCollection[random];
        quienstionActive.SetActive(true);
    }
}
