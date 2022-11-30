using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Trigger : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip transitionClip;
    public AudioClip musicSountrack;

    public int myIndex;

    private bool entered;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(AudioDJ.collidingObject))
        {
            Debug.Log(other.gameObject.name + " has entered " + this.gameObject.name);
            audiosource.PlayOneShot(transitionClip, 0.7F);
            AudioDJ.isMusicPlaying = true;
            AudioDJ.currentBiome = this.gameObject.name;
            if (!entered)
            {
                AudioDJ.prevBiomeIndex = AudioDJ.currBiomeIndex;
                AudioDJ.currBiomeIndex = myIndex;
                // Debug.Log("setting index");
                entered = true;
            }
            
            AudioDJ.stopMusic = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(AudioDJ.collidingObject)) {
            Debug.Log(other.gameObject.name + " is still in " + this.gameObject.name);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals(AudioDJ.collidingObject))
        {
            audiosource.Stop();
            if (AudioDJ.forward)
            {
                audiosource.PlayOneShot(musicSountrack, 0.7F);
            } else {
                AudioDJ.prevBiomeIndex = myIndex;
                AudioDJ.currBiomeIndex = myIndex - 1;
                AudioDJ.startMusic = true;
            }
            
            Debug.Log(other.gameObject.name + " has exit " + this.gameObject.name);
        }
        entered = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
        audiosource = GetComponent<AudioSource>();
        entered = false;
        myIndex = AudioDJ.biomePosition.IndexOf(this.gameObject.name);

    }

    // Update is called once per frame
    void Update()
    {
        //// startMusic = AudioDJ.currentBiome.Equals(this.gameObject.name);
        //if (AudioDJ.currentBiome.Equals(this.gameObject.name))
        //{
        //    startMusic = true;
        //} else if (startMusic == true)
        //{
        //    audiosource.Stop();
        //    startMusic = false;
        //}

        if (AudioDJ.stopMusic && (myIndex == AudioDJ.prevBiomeIndex)) {
            audiosource.Stop();
            AudioDJ.stopMusic = false;
        }
        if (AudioDJ.startMusic && (myIndex == AudioDJ.currBiomeIndex))
        {
            audiosource.PlayOneShot(musicSountrack, 0.7F);
            AudioDJ.startMusic = false;
        }
    }
}
