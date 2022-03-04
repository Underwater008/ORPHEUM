using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OuterWaterPipeControl : MonoBehaviour {
  public Transform cubesParent;



  private int clickCount = 0;
  private bool isRotate = false;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  // Button click on the water pipes.
  public void OnClick() {
    if (isRotate) return;
    clickCount++;
    Debug.Log(clickCount);
    isRotate = true;
    // Rotate water pipe 90 degrees when clicked the button
    cubesParent.DORotate(new Vector3(0, 0, clickCount * 90), 1).OnComplete(() => {
      isRotate = false;
      });
  }
 
}
