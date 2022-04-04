 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class SoundManager : MonoBehaviour {
  public AudioSource audioSourceClick;
  public AudioSource audioSourceRotate;
  public AudioSource audioSourceWaterOk;

  public void PlayAudioClick()
    {
      if (audioSourceClick.isPlaying)
        audioSourceClick.Stop();
      audioSourceClick.Play();
    }
  public void PlayAudioRotate() {
    if (audioSourceClick.isPlaying)
      audioSourceRotate.Stop();
    audioSourceRotate.Play();
  }
  public void PlayAudioWaterOk() {
    if (audioSourceWaterOk.isPlaying)
      audioSourceWaterOk.Stop();
    audioSourceWaterOk.Play();
  }


}