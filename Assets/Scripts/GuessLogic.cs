using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GuessLogic : MonoBehaviour
{

    public InputField guessInput;
    public Text life;
    public Text fastestScore;
    [SerializeField] public int lifeCounter;
    public int randomNumber = 0;
    public float score;

    void Start()
    {
        randomNumber = Random.Range(1, 11);
        fastestScore.text = "FASTEST SCORE: " + PlayerPrefs.GetInt("FASTEST_SCORE").ToString() + " seconds";
    }

    void Update()
    {
        score += 1f * Time.deltaTime;
        PlayerPrefs.SetInt("SCORE", (int)score);
    }

    public void GenerateNumber() 
    {
        if (int.Parse(guessInput.text) == randomNumber) {
            PlayerPrefs.SetString("RESULT", "You Win!");
            SceneManager.LoadScene("Scene2");
            return;
        }

        lifeCounter--;
        life.text = "LIFE: " + lifeCounter;
        guessInput.text = "";
        
        if (lifeCounter == 0) {
            PlayerPrefs.SetString("RESULT", "You Lose!");
            SceneManager.LoadScene("Scene2");
        }
    }
}
