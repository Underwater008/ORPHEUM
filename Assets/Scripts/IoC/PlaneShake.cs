using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EasyGameStudio.Jeremy;

//click and rotate puzzle piece in IoC with colider
//need using DG.Tweening;
//need ClickObject.cs
public class PlaneShake : MonoBehaviour
{

  public Transform rotateTarget;
  public GameObject target;
  public bool rotating;

  public SoundManager soundManager;
  private bool isRotate = false;
  public Transform centerButton;
  public Selected_effect_mouse_click selected;

  public void OnClick() {
    if (Cursor.visible) {
      //Do stuff
      Quaternion targetRotation = target.transform.rotation;

      if (isRotate) return;
      soundManager.PlayAudioClick();
      soundManager.PlayAudioRotate();
      isRotate = true;
      centerButton.DOMoveZ(rotateTarget.position.z - 2f, 0.5f);
          rotateTarget.DOMoveZ(rotateTarget.position.z - 2f, 0.5f).OnComplete(() => {
            selected.change_to_selected();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            soundManager.playShortTileDrag();
        rotateTarget.DOLocalRotate(new Vector3(10, 0, 0), 0.3f, RotateMode.Fast).OnComplete(() => {
          rotateTarget.DOLocalRotate(new Vector3(-10, 0, 0), 0.3f, RotateMode.Fast).OnComplete(() => {
            rotateTarget.DOLocalRotate(new Vector3(0, 0, 0), 0.3f, RotateMode.Fast).OnComplete(() => {
              soundManager.playTileDrop();
              centerButton.DOMoveZ(centerButton.position.z + 2f, 0.5f);
              rotateTarget.DOMoveZ(rotateTarget.position.z + 2f, 0.5f).OnComplete(() => {
                selected.change_to_not_selected();
                isRotate = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
              });
            });
          });
        });
      });
    }
    }
}
