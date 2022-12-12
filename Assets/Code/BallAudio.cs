using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    private AudioSource Hit;
    private BallBreakout balling;
    public AudioClip[] audioClips;

    private void Awake()
    {
        balling = GetComponentInParent<BallBreakout>();
        Hit = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        balling.Ballreacting += Balled;
    }

    private void OnDisable()
    {
        balling.Ballreacting -= Balled;
    }

    private void Balled(Vector2 collisionpoint)
    {
        Hit.PlayOneShot(GetRandomClip());
    }

    private AudioClip GetRandomClip()
    {
        if (audioClips == null) return null;
        if (audioClips.Length < 1) return null;

        int index = Random.Range(0, audioClips.Length);
        return audioClips[index];
    }
}
