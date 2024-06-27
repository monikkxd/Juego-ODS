using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFeedback : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip correctPlacementClip, wrongPlacementClip, demolishSound;

    public void CanPlaceSound()
    {
        source.PlayOneShot(correctPlacementClip);
    }
    public void CantPlaceSound()
    {
        source.PlayOneShot(wrongPlacementClip);
    }
    public void DemolishSound()
    {
        source.PlayOneShot(demolishSound);
    }
}
