using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SinglePlayer : MonoBehaviour
{
    public GameObject tapToContinueButton;
    public Animation[] animationsToPlay;

    public List<QuestionList> questions;
    public Text[] answersText;
    public Text questionText;

    public Text scoreText;
    public Text timeText;

    private int score = 0;
    private int time = 30;
    private int streak = 0;

    private bool isPlaying = true;

    List<object> questionList;
    int randQuestion;

    QuestionList currentQuestion;

    public void Update()
    {
        scoreText.text = score.ToString();
        timeText.text = time.ToString();
    }

    private void MinusSecond()
    {
        if (isPlaying)
        {
            time -= 1;
            if (time <= 0)
            {
                StopGame();
            }
            Invoke("MinusSecond", 1);
        }
    }

    public void StopGame()
    {
        isPlaying = false;
        tapToContinueButton.SetActive(true);
        questionText.text = "Time is over.. \n Your score: " + score + "\n tap to continue";
        questionText.verticalOverflow = VerticalWrapMode.Overflow;
        for (int i = 0; i < animationsToPlay.Length; i++)
        {
            animationsToPlay[i].Play(animationsToPlay[i].clip.name + "Out");
        }
    }

    public void GenerateList()
    {
        int allQuestionsCount = GameManagement.Instance.allWords.questions.Count;
        for (int i = 0; i < allQuestionsCount; i++)
        {
            QuestionList newList = new QuestionList();
            newList.question = GameManagement.Instance.allWords.questions[i];
            GameManagement.Instance.allWords.wordsWithTranslationsDictionary.TryGetValue(newList.question, out string value);
            List<string> answers = new List<string>(GameManagement.Instance.allWords.answers);

            newList.answers[0] = value;
            answers.Remove(newList.answers[0]);
            newList.answers[1] = answers[Random.Range(0, answers.Count)];
            answers.Remove(newList.answers[1]);
            newList.answers[2] = answers[Random.Range(0, answers.Count)];
            answers.Remove(newList.answers[2]);
            newList.answers[3] = answers[Random.Range(0, answers.Count)];
            answers.Remove(newList.answers[3]);

            questions.Add(newList);
        }
    }

    public void OnClickPlay()
    {
        for (int i = 0; i < animationsToPlay.Length; i++)
        {
            animationsToPlay[i].Play();
        }

        Invoke("MinusSecond", 1);
        GenerateList();
        questionList = new List<object>(questions);
        questionGenerate();
    }

    public void questionGenerate()
    {
        if (questionList.Count == 0)
        {
            return;
        }

        randQuestion = Random.Range(0, questionList.Count);
        currentQuestion = questionList[randQuestion] as QuestionList;
        questionText.text = currentQuestion.question;
        List<string> answers = new List<string>(currentQuestion.answers);
        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
            answersText[i].text = answers[Random.Range(0, answers.Count)];
            answers.Remove(answersText[i].text);
        }
    }

    public void OnAnswerButtonClick(int index)
    {
        if (answersText[index].text.ToString() == currentQuestion.answers[0])
        {
            time += 1;
            streak += 1;
            if (streak > 4)
            {
                score += streak;
            }
            score += 10;
        }
        else
        {
            time -= 1;
            streak = 0;
        }
        questionList.RemoveAt(randQuestion);
        questionGenerate();
    }

    public void OnHomeButtonClick()
    {
        GameManagement.Instance.uiManager.OpenMenu();
        Destroy(gameObject);
    }
}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}