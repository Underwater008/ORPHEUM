using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartButtonControl : MonoBehaviour {
  public AppleRotate appRotate;
  public PuzzleSequenceControl puzzleSeqControl;
  public Transform posAfterClick;

  public SoundManager soundManager;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void OnClick() {
    if (appRotate.GetComponent<AppleRotate>().isStart == true) { 
      Debug.Log("pressed first button");
    soundManager.PlayAudioClick();
    soundManager.PlayAudioRotate();
    transform.DOMove(posAfterClick.position, 1).OnComplete(() => {
      appRotate.StartTheFirstStage();
    });
  }
    else if (puzzleSeqControl.GetComponent<PuzzleSequenceControl>().isEndingSeuence == true) {
      Debug.Log("pressed Ending first button");
      soundManager.PlayAudioClick();
      soundManager.PlayAudioRotate();
      transform.DOMove(posAfterClick.position, 1).OnComplete(() => {
      puzzleSeqControl.StartTheFirstStage();
      });
      }
  }
}
