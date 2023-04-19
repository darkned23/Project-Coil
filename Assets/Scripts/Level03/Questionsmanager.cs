using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Questionsmanager : MonoBehaviour
{
    private AudioSource _audioManagment;
    private AudioClip _audioInQueue;

    void Start()
    {
        _audioManagment = GetComponent<AudioSource>();

    }

    public void GetQuestion(Jsonmanagment.Question ask)
    {
        _audioInQueue = Resources.Load<AudioClip>(ask.audio);
        _audioManagment.clip = _audioInQueue;
        _audioManagment.Play();
    }
}
