using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Trigger : MonoBehaviour
{
    //public AudioSource audiosource;
    public AudioSource transitionSoundtrack, musicSoundtrack;
    public AudioClip transitionClip, musicClip;

    public bool startMusic;
    private bool MusicToTransition;
    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(AudioDJ.collidingObject))
        {
            Debug.Log(other.gameObject.name + " has entered " + this.gameObject.name);
            // audiosource.PlayOneShot(transitionClip, 0.7F);
            
            if (!triggered)
            {
                Debug.Log("not triggered");
                AudioDJ.isMusicPlaying = true;
                AudioDJ.currentBiome = this.gameObject.name;
                MusicToTransition = true;
                StopAllCoroutines();
                StartCoroutine(FadeTrack());
                triggered = true;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(AudioDJ.collidingObject))
        {
            Debug.Log(other.gameObject.name + " is still in " + this.gameObject.name);
            triggered = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals(AudioDJ.collidingObject))
        {
            triggered = false;
            MusicToTransition = false;
            // audiosource.Stop();
            // audiosource.PlayOneShot(musicSountrack, 0.7F);
            StopAllCoroutines();
            StartCoroutine(FadeTrack());
            Debug.Log(other.gameObject.name + " has exit " + this.gameObject.name);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

        // audiosource = GetComponent<AudioSource>();
        triggered = false;
        MusicToTransition = false;
        transitionSoundtrack = gameObject.GetComponent<AudioSource>();
        musicSoundtrack = gameObject.GetComponent<AudioSource>();

        startMusic = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (AudioDJ.currentBiome.Equals(this.gameObject.name))
        {
            startMusic = true;
        }
        else
        {
            // audiosource.Stop();
            triggered = false;
        }
    }

    private IEnumerator FadeTrack()
    {
        float timeToFade = 1.25f;
        float timeElapsed = 0;
        Debug.Log("in fade track");

        if (MusicToTransition)
        {
            Debug.Log("music to transition");
            // audiosource.PlayOneShot(transitionClip, 1f);
            transitionSoundtrack.clip = transitionClip;
            transitionSoundtrack.Play();
            while (timeElapsed < timeToFade)
            {
                // audiosource.PlayOneShot(transitionClip, Mathf.Lerp(0, 1, timeElapsed / timeToFade));
                // audiosource.PlayOneShot(musicSountrack, Mathf.Lerp(1, 0, timeElapsed / timeToFade));
                transitionSoundtrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                musicSoundtrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // audiosource.PlayOneShot(musicSountrack, 0f);
            musicSoundtrack.Stop();
            yield break;

        }
        else
        {
            Debug.Log("transition to music");
            // audiosource.PlayOneShot(musicSountrack, 1f);
            musicSoundtrack.clip = musicClip;
            musicSoundtrack.Play();

            while (timeElapsed < timeToFade)
            {
                // audiosource.PlayOneShot(musicSountrack, Mathf.Lerp(0, 1, timeElapsed / timeToFade));
                // audiosource.PlayOneShot(transitionClip, Mathf.Lerp(1, 0, timeElapsed / timeToFade));
                musicSoundtrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                transitionSoundtrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // audiosource.PlayOneShot(transitionClip, 0f);
            transitionSoundtrack.Stop();
            yield break;

        }
    }
}
