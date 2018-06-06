using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {


    public GifPlayerMesh[] boards;
    public GifData[] gifs;
    public int numOfGifs = 3;

    int[] playerScores;
    public TextMesh[] scoreText;



    // Use this for initialization
    void Awake() {

      playerScores = new int[2];

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateScore(float xpos){
        if (xpos > 0)
        {
            playerScores[1]++;
            scoreText[1].text = playerScores[1].ToString();
            UpdateMesh(1);
        }
        else
        {
            
            playerScores[0]++;
            scoreText[0].text = playerScores[0].ToString();
            UpdateMesh(0);
        }
    }
    void UpdateMesh(int i)
    {
        
        boards[i].ChangeGif(gifs[playerScores[i]%3]);
        
    }
}
