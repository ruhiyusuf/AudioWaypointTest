using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    AudioSource audiosource;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " has entered the cube");
        audiosource.Play();

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + " is still in the cube");
    }

    private void OnTriggerExit(Collider other)
    {
        audiosource.Stop();
        
        Debug.Log(other.gameObject.name + " has exit the cube");
    }
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
