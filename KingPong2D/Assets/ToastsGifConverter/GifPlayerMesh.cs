using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifPlayerMesh : GifPlayerInterface
{
    private MeshRenderer meshy;
    public GifData _g;

    // Use this for initialization
    void Awake()
    {
        meshy = GetComponent<MeshRenderer>();
    }

    public override void Initialize(GifData gif)
    {
        playing = true;
        StartCoroutine(play(gif));
    }
    private void Start()
    {
        Initialize(_g);
    }

    public void ChangeGif(GifData gd) {
        playing = false;
        StopCoroutine(play(gd));
        Initialize(gd);
    }

    IEnumerator play(GifData gif)
    {
        while (playing)
        {
            for (int j = 0; j < gif.frames.Length; j++)
            {
                meshy.material.mainTexture = gif.frames[j];
                yield return new WaitForSeconds(gif.delay);
            }
        }
        playing = false;
    }
}
