using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menu : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;
    private string scoreString = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreString = "Score: " + score;
        text.text = scoreString;
    }
    public void scorePlusOne()
    {
        score++;
        scoreString = "Score: " + score;
        text.text = scoreString;
    }
    public void resetScore() { 
        score = 0;
        scoreString = "Score: " + score;
        text.text = scoreString;
    }
}
