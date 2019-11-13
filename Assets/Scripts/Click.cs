using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public static int clickValue;
    public static int amountPerSecond;

    private void Start()
    {
        clickValue = 1;
    }
    public void ClickerButton()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ScoreManager.score -= clickValue;
        }
      
    }
    
}
