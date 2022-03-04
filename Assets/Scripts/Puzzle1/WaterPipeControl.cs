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
  public GameObject firstDoor;
  public GameObject secondDoor;
  public GameObject parentApple;
  public AppleRotate appleRotate;


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
      // Change color to indicate first step done
      if (clickCount == 3) {
        leftCube.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
          pipe.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
            isRotate = false;
          });
        });
      }

      // Solved the 1st puzzle in IoC
      else if (clickCount == 5)
      {
        Debug.Log(clickCount);
        bottomSphere.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
          tree.DOScale(1.5f, 1);
          tree.transform.DOLocalMove(biggerTreePos.localPosition, 1).OnComplete(() => {
            firstDoor.transform.DOLocalMove(new Vector3(0, 0, -0.5f), 2f).OnComplete(() => {
            // Hide the first puzzle and show the second puzzle
            
            parentApple.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            
            secondDoor.transform.DOLocalMove(new Vector3(0.5f, 0, -0.5f), 2f);
            appleRotate.StartTheThirdStage();
          });
          });
          });

        });
      }

      else if(clickCount==8) 
      { 
      }
      else if(clickCount==11)
      {

      }
      else if(clickCount==13)
      {

      }
      else if(clickCount==15) 
      {

      }
      else {
        isRotate = false;
      }
    });
    //leftCube.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1);
  }
 
}
