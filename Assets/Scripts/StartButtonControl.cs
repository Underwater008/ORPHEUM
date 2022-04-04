using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartButtonControl : MonoBehaviour {
  public AppleRotate appRotate;
  public Transform posAfterClick;

  public SoundManager soundManager;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void OnClick() {
    Debug.Log("pressed first button");
    soundManager.PlayAudioClick();
    soundManager.PlayAudioRotate();
    transform.DOMove(posAfterClick.position, 1).OnComplete(()=> {
      appRotate.StartTheFirstStage();
    });
  }
}
