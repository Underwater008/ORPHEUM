using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterPipeControl : MonoBehaviour {
  public Transform cubesParent;
  public Transform tree;
  public Transform biggerTreePos;
  public GameObject leftCube;
  public GameObject pipe;
  public GameObject bottomSphere;

  private int clickCount = 0;
  private bool isRotate = false;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void OnClick() {
    if (isRotate) return;
    clickCount++;
    isRotate = true;
    cubesParent.DORotate(new Vector3(0, 0, clickCount * 90), 1).OnComplete(()=> {
      if(clickCount == 3) {
        leftCube.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(()=> {
          pipe.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
            isRotate = false;
          });
        });
      }
      else if(clickCount == 5) {
        bottomSphere.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
          tree.DOScale(1.5f, 1);
          tree.transform.DOLocalMove(biggerTreePos.localPosition, 1).OnComplete(() => {

          });
        });
      }
      else {
        isRotate = false;
      }
    });
    //leftCube.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1);
  }
}
