 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class SoundManager : MonoBehaviour {
  public AudioSource audioSourceClick;
  public AudioSource audioSourceRotate;
  public AudioSource audioSourceWaterOk;
  public AudioSource puzzleHeavyDrop;
  public AudioSource tileDrop;
  public AudioSource longtileDrag;
  public AudioSource medtileDrag;
  public AudioSource shorttileDrag;
  public AudioSource puzzleCompleteChime;

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
  public void PlayPuzzleHeavyDrop() {
    if (puzzleHeavyDrop.isPlaying)
      puzzleHeavyDrop.Stop();
    puzzleHeavyDrop.Play();
  }
  public void PlayPuzzleCompleteChime() {
    if (puzzleCompleteChime.isPlaying)
      puzzleCompleteChime.Stop();
    puzzleCompleteChime.Play();
  }

  public void playTileDrop() {
    if (tileDrop.isPlaying)
      tileDrop.Stop();
    tileDrop.Play();
  }
  public void playLongTileDrag() {
    if (longtileDrag.isPlaying)
      longtileDrag.Stop();
    longtileDrag.Play();
  }
  public void playMedTileDrag() {
    if (medtileDrag.isPlaying)
      medtileDrag.Stop();
    medtileDrag.Play();
  }
  public void playShortTileDrag() {
    if (shorttileDrag.isPlaying)
      shorttileDrag.Stop();
    shorttileDrag.Play();
  }


}