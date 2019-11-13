using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static Text scoreDisplay;

    private void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        InvokeRepeating("Timer", 1, 0.25f);
    }
    private void Timer()
    {
        score += Click.amountPerSecond;
    }
}
