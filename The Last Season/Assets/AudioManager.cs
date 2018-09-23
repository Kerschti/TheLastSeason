using UnityEngine.Audio;
using System;
using UnityEngine;

/*
 *inspired: https://youtu.be/6OT43pvUyfY 
 */

public class AudioManager : MonoBehaviour {

    //Array of availible sounds
    public Sound[] sounds;

	//initialization of AudioManager to hold diffrent clips with their values volume and loop
	void Awake () {

		foreach(Sound s in sounds){

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
	}

    //Start Game, Sound "Theme" will start
    private void Start()
    {
        Play("Theme");
    }

    //Looking for the matching sound name in the array and plays that
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    //Looking for the matching sound name in the array and pauses that
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
}
