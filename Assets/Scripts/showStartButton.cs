using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class showStartButton : MonoBehaviour
{
  public AppleRotate appRotate;
  public void ShowStartButton() {
    appRotate.firstButton.gameObject.SetActive(true);
    appRotate.firstButton.DOMove(appRotate.startButtonEndMovePos.position, 1);
    appRotate.ShowTree();
  }
}
