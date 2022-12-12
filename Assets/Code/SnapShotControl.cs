using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Verwendungszweck um verschiedene Mixereinstellungen im Spiel zu inplementieren
public class SnapShotControl : MonoBehaviour
{
    public AudioMixerSnapshot standart;
    public AudioMixerSnapshot combat;
    public AudioMixerSnapshot story;

    public float snapshotTransition = 1f;

   /* private void Update()
    {
        if (Input.GetKeyDown())
        {
            
        }

        if (Input.GetKeyDown())
        {
            
        }

        if (Input.GetKeyDown())
        {
            
        }
    }*/
}
