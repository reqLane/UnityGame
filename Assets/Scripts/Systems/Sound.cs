using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    [SerializeField]
    private string name;
    [SerializeField]
    private AudioClip clip;

    [HideInInspector]
    private AudioSource source;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume;
    [SerializeField]
    [Range(.1f, 3f)]
    private float pitch;

    [SerializeField]
    private bool loop;

    [SerializeField]
    private float freezeTime;
    private float lastTimePlayed;

    public string Name { get => name; set => name = value; }
    public AudioClip Clip { get => clip; set => clip = value; }
    public AudioSource Source { get => source; set => source = value; }
    public float Volume { get => volume; set => volume = value; }
    public float Pitch { get => pitch; set => pitch = value; }
    public bool Loop { get => loop; set => loop = value; }
    public float LastTimePlayed { get => lastTimePlayed; set => lastTimePlayed = value; }


    public bool canBePlayed()
    {
        return lastTimePlayed + freezeTime <= Time.time;
    }
}
