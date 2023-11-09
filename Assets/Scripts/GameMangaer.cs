using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class GameMangaer : MonoBehaviour
{
    [SerializeField] Envi EnviPrefab;
    [SerializeField] TextMeshProUGUI QuestionTmp;

    public QuestionData Data;
    private Questions CurrentQuestion;


    private int currentQuetsionIndex = 0;

    private void Awake()
    {
        Vector3 newPosition = new Vector3(0, 0, 0);


        for (int i = 0; i < Data.QuizQuestions.Count; i++)
        {

            
            var floorClone = Instantiate(EnviPrefab, newPosition, Quaternion.identity);
            floorClone.Answer1.SetAnswerValue(Data.QuizQuestions[i].WrongAnswer);
            floorClone.Answer2.SetAnswerValue(Data.QuizQuestions[i].CorrectAnswer);

            newPosition = newPosition + new Vector3(0, 0, 10);


        }

        CurrentQuestion = Data.QuizQuestions[0];
        ShowQuestion();

        
    }

    

    private void OnEnable()
    {
        Gate.OnchooseAnswer += HandleOnChooseAnswer; 
    }
    private void ShowQuestion()
    {
        QuestionTmp.text = CurrentQuestion.Question;

    }
    private void HandleOnChooseAnswer(String answer)
    {
        if (CurrentQuestion.CorrectAnswer == answer) { Debug.Log("True"); }
        else { Debug.Log("False"); }

        currentQuetsionIndex++;

        if (currentQuetsionIndex > Data.QuizQuestions.Count-1) { Debug.Log("Finished"); }
        else
        {
            CurrentQuestion = Data.QuizQuestions[currentQuetsionIndex];
            ShowQuestion();
        }

    }
}
