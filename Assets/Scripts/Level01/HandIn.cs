using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Object = System.Object;
using TMPro;
using Unity.VisualScripting;


public class HandIn : MonoBehaviour
{
    private List<Dictionary<String, Object>> cubes = new List<Dictionary<String, Object>>();
    static Random rnd = new Random();
    private string cubeToHand;
    private bool handed;
    private int index;
    private int objectsHanded = 0;
    
    //Dialogue variables
    public TextMeshProUGUI textComponent;
    private string[] lines;
    public float textSpeed;
    private int dialogueIndex;
    private bool isTyping = false;

    [SerializeField] private GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        //textComponent.text = String.Empty;
        //StartDialogue();

        Dictionary<String, Object> cube0 = new Dictionary<string, object>();
        cube0.Add("name", "Violet Cube");
        cube0.Add("handed", false);

        Dictionary<String, Object> cube1 = new Dictionary<string, object>();
        cube1.Add("name", "Blue Cube");
        cube1.Add("handed", false);
        
        Dictionary<String, Object> cube2 = new Dictionary<string, object>();
        cube2.Add("name", "Red Cube");
        cube2.Add("handed", false);
        
        Dictionary<String, Object> cube3 = new Dictionary<string, object>();
        cube3.Add("name", "Green Cube");
        cube3.Add("handed", false);
        
        Dictionary<String, Object> cube4 = new Dictionary<string, object>();
        cube4.Add("name", "Yellow Cube");
        cube4.Add("handed", false);
        
        cubes.Add(cube0);
        cubes.Add(cube1);
        cubes.Add(cube2);
        cubes.Add(cube3);
        cubes.Add(cube4);

        ObjectChanger();

    }
    void StartDialogue()
    {
        textComponent.text = String.Empty;
        dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in lines[dialogueIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (dialogueIndex < lines.Length - 1)
        {
            dialogueIndex++;
            textComponent.text = String.Empty;
            StartCoroutine(TypeLine());
        }
        // else
        // {
        //     gameObject.SetActive(false);
        // }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (textComponent.text == lines[dialogueIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[dialogueIndex];
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == cubeToHand) && (!handed))
        {
            handed = true;
            collision.gameObject.SetActive(false);
            ObjectChanger();
        }
        else
        {
            if (collision.gameObject.tag == "Player" && isTyping) return;
            lines = new[] { "Teacher: That is not the item I asked for, try again. Bring me a " + cubeToHand + "." };
            StartDialogue();
        }

    }

    private void ObjectChanger()
    {
        if (objectsHanded == 3)
        {
            lines = new[]
                { "Teacher: Great! You have handed in all the correct items. You may now leave the classroom." };
            StartDialogue();
            foreach (Dictionary<string,object> cube in cubes)
            {
                cube["handed"] = true;
            }
            Destroy(door);
            return;
        }

        string lastObjectHanded = cubeToHand;
        index = rnd.Next(0, cubes.Count);
        cubeToHand = (String) cubes[index]["name"];
        switch (objectsHanded)
        {
            case 0: //Debug.Log("Teacher: Please bring me a " + cubeToHand);
                lines = new[] {"Teacher: Please bring me a " + cubeToHand };
                StartDialogue();
                break;
            case 1: //Debug.Log("Teacher: Now please bring me a " + cubeToHand);
                lines = new[] {"Teacher: " + lastObjectHanded + " received, thank you", "Teacher: Now please bring me a " + cubeToHand};
                StartDialogue();
                break;
            case 2: //Debug.Log("Teacher: Lastly, bring me a " + cubeToHand);
                lines = new[] {"Teacher: " + lastObjectHanded + " received, thank you", "Teacher: Lastly, bring me a " + cubeToHand};
                StartDialogue();
                break;
        }
        handed = (bool) cubes[index]["handed"];
        cubes.RemoveAt(index);
        objectsHanded++;
    }
}
