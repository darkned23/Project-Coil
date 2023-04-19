using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Jsonmanagment : MonoBehaviour
{
    public TextAsset json;
    public int numberQuestionSelected;
    public Questionsmanager ask;
    
    [System.Serializable]
    public class Question
    {
        public string audio;
        public string text;
        public string[] invalidOptions;
        public string answer;

    }

    [System.Serializable]
    public class QuestionsList
    {
        public Question[] Questions;
    }

    public QuestionsList myQuestionList = new QuestionsList();
    
    void Start()
    {
        ask = GetComponent<Questionsmanager>();
        myQuestionList = JsonUtility.FromJson<QuestionsList>(json.text);
        numberQuestionSelected = Random.Range(0, myQuestionList.Questions.Length -1 );
        sendQuestion();
    }


    private void sendQuestion()
    {
        ask.GetQuestion(myQuestionList.Questions[numberQuestionSelected]);
    }
    
}
