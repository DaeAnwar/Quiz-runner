using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    public TextMeshProUGUI Question;
    public TextMeshPro Answer1;
    public TextMeshPro Answer2;

    private QuestionData CurrentQuestionData;

    private void OnEnable()
    {
        QuestionScript.OnPlayerCollision += ShowData;
    }
    private void OnDisable()
    {
        QuestionScript.OnPlayerCollision -= ShowData;
   }

    public void ShowData(QuestionData data)
    {
        CurrentQuestionData = data;

        Question.text = data.QuizQuestions[0].Question;
        Answer1.text = data.QuizQuestions[0].WrongAnswer;
        Answer2.text = data.QuizQuestions[0].CorrectAnswer;




    }
    public bool hasEnteredLeftTrigger = false;
    public bool hasEnteredRightTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Answer2"))
        {
            hasEnteredLeftTrigger = true;
            Debug.Log("Ur anwser is  correct ! ");

        }
        else if (other.gameObject.CompareTag("Answer1"))
        {
            hasEnteredRightTrigger = true;
            Debug.Log("Ur anwser is  False ! ");

        }
    }


}
