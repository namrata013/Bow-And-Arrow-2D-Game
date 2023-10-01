using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip shootingsound;
    public AudioSource Audio;

    void Start(){
        Audio = GetComponent<AudioSource>();

    }
}
