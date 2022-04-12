using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateButton : MonoBehaviour
{
  public Transform puzzleAll;

  public SoundManager soundManager;

  [SerializeField]
  private int centerButtonclickCount = 0;

  private bool isRotate = false;

  public void OnClick() {
    if (isRotate) return;
    soundManager.PlayAudioClick();
    soundManager.PlayAudioRotate();
    centerButtonclickCount++;
    Debug.Log(centerButtonclickCount);
    isRotate = true;
    // Rotate puzzle1 90 degrees when clicked the button
    puzzleAll.DORotate(new Vector3(0, 0, centerButtonclickCount * 90), 1).OnComplete(() => {
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
