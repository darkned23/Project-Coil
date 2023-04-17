using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int dialogueIndex;
    
    void Start()
    {
        textComponent.text = String.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    void StartDialogue()
    {
        dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[dialogueIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (dialogueIndex < lines.Length - 1)
        {
            dialogueIndex++;
            textComponent.text = String.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
