using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AudioManager : MonoBehaviour {

    public delegate Event play(int i);
    public AudioClip[] files;
    public AudioSource player;

	// Use this for initialization
	void Start () {
        player = Camera.main.GetComponent<AudioSource>();
        BallMovement.ballHit += PlayOnce();
            }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayOnce(int i) {
        if (i < files.Length) {
            player.PlayOneShot(files[i]);

        }

    }
}
