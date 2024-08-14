using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PianoAudio : MonoBehaviour
{
    PianoDetect pianoDetect;
   
    public AudioSource audioSource;

    float volume;

    void Start()
    {
        Debug.Log("Audio script activated");
        audioSource = GetComponent<AudioSource>();
        pianoDetect = GetComponent<PianoDetect>();
        StartCoroutine(audioCue());
    }

    IEnumerator audioCue()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            isPlaying();
        }
    }



    public void isPlaying()
    {
        bool play = pianoDetect.InAudioRange();
        bool guardCall = pianoDetect.InAggroRange();

        if (guardCall)
        {
            Debug.Log("Guard called");
            audioSource.volume = 1.0f;
            audioSource.Play();
            return;
        }
        else if (play)
        {
            Debug.Log("Playing audio...");
            audioSource.volume = 0.2f;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Stopping audio...");
            audioSource.Stop();
        }
    }
}
