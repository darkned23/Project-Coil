using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSelection : MonoBehaviour
{
    public GameObject[] puertas;
    public int DoorRigth;
    void Start()
    {
        DoorRigth = Random.Range(1, puertas.Length);
        puertas[DoorRigth].SetActive(false);
    }
}
