using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSound : MonoBehaviour {

    public AudioSource sound;
    public double playtime;
	// Use this for initialization
	void Start () {
        
        
            playtime = Random.Range(0, 10);
            PlaySound();
        
    }

    void PlaySound() {

        sound.time = (float)playtime;
        sound.Play();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
