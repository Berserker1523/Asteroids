using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HUD of the game
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    float elapsedSeconds = 0f;
    bool isTimerRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0"; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedSeconds += Time.deltaTime;
            scoreText.text = "Score: " + ((int)elapsedSeconds).ToString();
        }
    }

    public void StopGamerTimer()
    {
        isTimerRunning = false;
    }
}
