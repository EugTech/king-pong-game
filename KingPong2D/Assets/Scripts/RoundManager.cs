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



    // Use this for initialization

    void Start()
    {



    }



    // Update is called once per frame

    void Update()
    {



    }



    public void gameOver(int winningPlayer, string winningPlayerName, int losingPlayer, string losingPlayerName)
    {

        print("Congrats " + winningPlayerName + "! You won with " + winningPlayer + " points! /n Don't Worry " + losingPlayer + " you'll get them next time!");

        if (++rounds > MaxNumOfRounds)

        {

            //do a thing



            rounds = 0;

        }

        else
        {

            sc.ResetScore();

            tm.StartTimer();

            bm.Spawn();



        }

    }

}
