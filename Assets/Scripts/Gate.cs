using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{

    public TextMeshPro AnswerTMP;
    public static UnityAction<string> OnchooseAnswer;

    public void SetAnswerValue(string Answer)
    {
        AnswerTMP.text = Answer;

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            OnchooseAnswer?.Invoke(AnswerTMP.text);

        }
    }





}



