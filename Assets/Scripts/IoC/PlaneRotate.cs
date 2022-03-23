using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//click and rotate puzzle piece in IoC with colider
//need using DG.Tweening;
//need ClickObject.cs
public class PlaneRotate : MonoBehaviour
{

  public Transform rotateTarget;
  public GameObject target;

  public SoundManager soundManager;

  private int clickCount = 0;
  private bool isRotate = false;
  public bool puzzle1;
  public bool puzzle2;
  public bool puzzle3;

  public void OnClick() {
    if (isRotate) return;
    clickCount++;
    Debug.Log(clickCount);
    soundManager.PlayAudioClick();
    soundManager.PlayAudioRotate();
    isRotate = true;

    if (puzzle1 == true) {
      // Rotate puzzle1 90 degrees when clicked the button
      rotateTarget.DOLocalRotate(new Vector3(0, 0, clickCount * 90), 1).OnComplete(() => {
        isRotate = false;
      });
    }

    if (puzzle2 == true) {
      // Rotate puzzle1 90 degrees when clicked the button
      target.transform.DOLocalRotate(new Vector3(clickCount * 90, 0, 0), 1).OnComplete(() => {

        isRotate = false;
      });
    }
  }
  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    
    }
}
