using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{

    public Text result;
    public Text score;
    public int fastestScore;

    void Start()
    {
        result.text = PlayerPrefs.GetString("RESULT");
        score.text = "Score: " + PlayerPrefs.GetInt("SCORE").ToString() + " seconds";
    }

    public void PlayAgain()
    {
        if (result.text.Equals("You Win!") && PlayerPrefs.GetInt("FASTEST_SCORE") == 0) {
            PlayerPrefs.SetInt("FASTEST_SCORE", PlayerPrefs.GetInt("SCORE"));
        } else if (result.text.Equals("You Win!") && PlayerPrefs.GetInt("FASTEST_SCORE") > PlayerPrefs.GetInt("SCORE")){
            PlayerPrefs.DeleteKey("FASTEST_SCORE");
            PlayerPrefs.SetInt("FASTEST_SCORE", PlayerPrefs.GetInt("SCORE"));
        }
        SceneManager.LoadScene("Scene1");
    }
}
