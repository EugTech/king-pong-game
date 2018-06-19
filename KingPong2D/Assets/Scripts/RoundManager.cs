using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEditor.Events;



public class RoundManager : MonoBehaviour
{



    int rounds = 0;

    public int MaxNumOfRounds = 3;

    public ScoreController sc;

    public AudioManager am;

    public Timer tm;

    public BallMovement bm;

    public TextMesh winScreen;



    // Use this for initialization

    void Start()
    {
        winScreen.text = "";


    }



    // Update is called once per frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Backspace)) {
            StartCoroutine(pauseForNewPlayers());
        }

    }



    public void gameOver(int winningPlayer, string winningPlayerName, int losingPlayer, string losingPlayerName)
    {

            winScreen.text = "Congrats " + winningPlayerName + "! You won with " + winningPlayer + " points! /n Don't Worry " + losingPlayer + " you'll get them next time!";

            StartCoroutine(pauseForNewPlayers());
            sc.ResetScore();

            tm.StartTimer();

            bm.Spawn();
        winScreen.text = "";

    }

    public IEnumerator pauseForNewPlayers() {
        Time.timeScale = 0.0001f;
        yield return StartCoroutine(waitForInput(KeyCode.Space));
        Time.timeScale = 1;


    }
    IEnumerator waitForInput(KeyCode key) {
        while (!Input.GetKeyDown(key)) {
            yield return null;
        }
    }

}
