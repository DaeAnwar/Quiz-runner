using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class QuestionScript : MonoBehaviour
{

    public QuestionData data;
    public static UnityAction<QuestionData> OnPlayerCollision;
    
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        OnPlayerCollision?.Invoke(data);

    }

}
