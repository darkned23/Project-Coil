using UnityEngine;

public class Questions : MonoBehaviour
{
    public GameObject[] questionsCollection;
    public GameObject quienstionActive;
    public int random;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RandomQuiestion();
        }
    }
    void RandomQuiestion()
    {
        random = Random.Range(0, questionsCollection.Length);
        quienstionActive = questionsCollection[random];
        quienstionActive.SetActive(true);
        Debug.Log(random);
    }
}
