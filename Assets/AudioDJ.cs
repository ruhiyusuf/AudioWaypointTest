using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDJ : MonoBehaviour
{
    public static bool isMusicPlaying;
    public static System.String currentBiome;
    public static System.String collidingObject = "Sphere";
    public static List<System.String> biomePosition = new List<System.String>{ "BiomeA1", "BiomeB1", "BiomeA2", "BiomeB2" }; // , "BiomeA3"
    public static int prevBiomeIndex;
    public static int currBiomeIndex;
    public static bool forward;
    public static bool startMusic;
    public static bool stopMusic;

    
    // Start is called before the first frame update
    void Start()
    {
        prevBiomeIndex = 0;
        currBiomeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevBiomeIndex <= currBiomeIndex)
        {
            forward = true;
            Debug.Log("We're going forward!");
        } else
        {
            forward = false;
            Debug.Log("Oops, we're going backward");
        }

        Debug.Log("prev Index: " + prevBiomeIndex + ", curr Index: " + currBiomeIndex);
    }
}
