using UnityEngine.Audio; 
using UnityEngine;


//Create external class Sound to handle values for AudioManager
[System.Serializable]
public class Sound {

    public AudioClip clip;
    public string name;

    [Range(0f,1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
