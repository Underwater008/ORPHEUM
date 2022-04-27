using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateButton : MonoBehaviour
{
  public Transform puzzleAll;

  public SoundManager soundManager;
  public GameObject puzzle1Control;
  public GameObject puzzle2Control;
  public GameObject puzzle3Control;

  [SerializeField]
  private int centerButtonclickCount = 1;

  private bool isRotate = false;

  public void OnClick() {
    if (Cursor.visible) {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      if (isRotate) return;
      puzzle1Control.SetActive(false);
      puzzle2Control.SetActive(false);
      puzzle3Control.SetActive(false);
      soundManager.PlayAudioClick();
      soundManager.PlayAudioRotate();
      Debug.Log(centerButtonclickCount);
      isRotate = true;
      // Rotate puzzle1 90 degrees when clicked the button
      puzzleAll.DOMoveZ(puzzleAll.position.z - 1.5f, 0.8f).OnComplete(() => {
        puzzleAll.DORotate(new Vector3(0, 0, centerButtonclickCount * 90), 1).OnComplete(() => {
        centerButtonclickCount++;
        isRotate = false;
          soundManager.PlayPuzzleHeavyDrop();
          puzzleAll.DOMoveZ(puzzleAll.position.z + 1.5f, 0.3f).OnComplete(() => {
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          puzzle1Control.SetActive(true);
          puzzle2Control.SetActive(true);
          puzzle3Control.SetActive(true);
        });
        });
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
/*Vector3 puzzleAllScale = puzzleAll.localScale;
  puzzleAll.DOScale(new Vector3(puzzleAllScale.x * 0.6f, puzzleAllScale.y * 0.6f, puzzleAllScale.z), 0.5f).OnComplete(() => {
  Vector3 puzzleAllScale = puzzleAll.localScale;
  puzzleAll.DOScale(new Vector3(puzzleAllScale.x / 0.6f, puzzleAllScale.y / 0.6f, puzzleAllScale.z), 0.5f);
});*/