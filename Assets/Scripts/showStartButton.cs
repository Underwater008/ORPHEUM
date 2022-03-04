using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class showStartButton : MonoBehaviour
{
  public AppleRotate appRotate;
  public void ShowStartButton() {
    appRotate.startButton.gameObject.SetActive(true);
    appRotate.startButton.DOMove(appRotate.startButtonEndMovePos.position, 1);
    appRotate.ShowTree();
  }
}
