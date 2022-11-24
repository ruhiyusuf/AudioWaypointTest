using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Trigger : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip beforeClip;
    public AudioClip afterClip;

    public bool startMusic;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " has entered " + this.gameObject.name);
        audiosource.PlayOneShot(beforeClip, 0.7F);
        AudioDJ.isMusicPlaying = true;
        AudioDJ.currentBiome = this.gameObject.name;

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + " is still in " + this.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        audiosource.Stop();
        audiosource.PlayOneShot(afterClip, 0.7F);
        Debug.Log(other.gameObject.name + " has exit " + this.gameObject.name);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        audiosource = GetComponent<AudioSource>();
        startMusic = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (AudioDJ.currentBiome.Equals(this.gameObject.name))
        {
            startMusic = true;
        } else if (startMusic == true)
        {
            audiosource.Stop();
            startMusic = false;
        }
    }
}
