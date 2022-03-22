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

  public SoundManager soundManager;

  private int clickCount = 0;
  private bool isRotate = false;

  public void OnClick() {
    if (isRotate) return;
    soundManager.PlayAudioClick();
    soundManager.PlayAudioRotate();
    clickCount++;
    Debug.Log(clickCount);
    isRotate = true;
    // Rotate puzzle1 90 degrees when clicked the button
    rotateTarget.DORotate(new Vector3(0, 0, clickCount * 90), 1).OnComplete(() => {
      isRotate = false;
    });
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
