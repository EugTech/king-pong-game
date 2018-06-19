using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScoreController : MonoBehaviour {


    public GifPlayerMesh[] boards;
    // public GifData[] gifs;

    public GifData[] easyGifs;

    public GifData[] mediumGifs;

    public GifData[] hardGifs;

    public int numOfGifs = 3;


    int[] playerScores;
    public TextMesh[] scoreText;

    public int targetScore = 10;
    public RoundManager rm;

    private void Start()

    {

        Timer.TimesUp += TimerDone;

    }


    // Use this for initialization
    void Awake() {

      playerScores = new int[2];

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateScore(float xpos){
        if (xpos < 0)
        {
            playerScores[1]++;
            scoreText[1].text = playerScores[1].ToString();
            UpdateMesh(1);
            if (playerScores[1] > targetScore)
            {

                rm.gameOver(playerScores[1], "Player Two", playerScores[0], "Player One");

            }

        }
        else
        {
            
            playerScores[0]++;
            scoreText[0].text = playerScores[0].ToString();
            UpdateMesh(0);
            if (playerScores[0] > targetScore)

            {

                rm.gameOver(playerScores[0], "Player One", playerScores[1], "Player Two");

            }

    }
}
    void UpdateMesh(int i)
    {

       // boards[i].ChangeGif(gifs[playerScores[i] % 3]);

        if (playerScores[i] < 4)

        {

            boards[i].ChangeGif(easyGifs[playerScores[i] % 3]);



        }

        else if (playerScores[i] > 6)

        {

            boards[i].ChangeGif(hardGifs[playerScores[i] % 3]);



        }

        else
        {

            boards[i].ChangeGif(mediumGifs[playerScores[i] % 3]);



        }

        // boards[i].ChangeGif(gifs[playerScores[i]%3]);


    }
    public void ResetScore()

{

    playerScores[0] = 0;

    playerScores[1] = 0;

    scoreText[0].text = "0";

    scoreText[1].text = "0";

    UpdateMesh(0);

    UpdateMesh(0);

}

public void TimerDone()
{



    int winnerScore = playerScores[0];

    if (winnerScore < playerScores[1])

    {

        winnerScore = playerScores[1];

        rm.gameOver(winnerScore, "Player Two", playerScores[0], "Player One");

    }

    else
    {

        rm.gameOver(winnerScore, "Player One", playerScores[1], "Player Two");

    }



}
 
}
