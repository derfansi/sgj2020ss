using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManagement : MonoBehaviour
{
    public AudioSource airMusic, waterMusic, earthMusic, fireMusic;
    public float fadingTime;
    public AudioSource sfx;
    public AudioClip airActivate, waterActivate, earthActivate, fireActivate;

    AudioSource currentAudioSource;
    Coroutine currentCoroutine;

    public void AirActivated()
    {
        sfx.clip = airActivate;
        sfx.Play();
        BlendMusic(airMusic);
    }
    public void WaterActivated()
    {
        sfx.clip = waterActivate;
        sfx.Play();
        BlendMusic(waterMusic);
    }
    public void EarthActivated()
    {
        //TODO: Play sound for earth activation
        BlendMusic(earthMusic);
    }
    public void FireActivated()
    {
        //TODO: Play sound for fire activation
        BlendMusic(fireMusic);
    }

    private void Awake()
    {
        airMusic.Play();
        waterMusic.Play();
        earthMusic.Play();
        fireMusic.Play();
        airMusic.volume = 1;
        waterMusic.volume = 0;
        earthMusic.volume = 0;
        fireMusic.volume = 0;

        currentAudioSource = airMusic;
    }

    void BlendMusic(AudioSource newSource)
    {
        currentCoroutine = StartCoroutine(BlendMusicCoroutine(newSource));
    }

    IEnumerator BlendMusicCoroutine(AudioSource newSource)
    {
        while(currentAudioSource.volume > 0)
        {
            float changeValue = (1 / fadingTime) * Time.deltaTime;
            currentAudioSource.volume -= changeValue;
            newSource.volume += changeValue;
            yield return new WaitForEndOfFrame();
        }
        currentAudioSource.volume = 0;
        newSource.volume = 1;
        currentAudioSource = newSource;
    }
}
