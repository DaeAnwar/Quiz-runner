using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "QuestionData", menuName = "Data/QuestionData")]
public class QuestionData : ScriptableObject
{

    public List<Questions> QuizQuestions;


}

[System.Serializable]

public class Questions 
{
    public string Question;
    public string CorrectAnswer;
    public string WrongAnswer;
}