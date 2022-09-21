using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake() 
    {
        int numMusicPlay = FindObjectsOfType<BackgroundMusic>().Length;
        if(numMusicPlay > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }    
    }
}
