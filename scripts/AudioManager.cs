using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public sounds[] sounds;
    public static AudioManager instance;
    // Use this for initialization
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        sounds s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning(" Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
        //call by this statement FindObjectOfType<AudioManager>().Play("NameOfAudioClip");
    }

    public void Stop(string name)
    {
        sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Stop();
    }
}
