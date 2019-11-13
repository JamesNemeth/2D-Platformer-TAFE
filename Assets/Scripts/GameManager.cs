using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void NextScene()
    {
        // Get current scene
        Scene activeScene = SceneManager.GetActiveScene();
        // Load next scene
        SceneManager.LoadScene(activeScene.buildIndex);
    }
 
}