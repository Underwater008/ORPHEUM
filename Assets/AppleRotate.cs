using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRotate : MonoBehaviour {
  public float speed = 30;
  public Animator appleAnimator;

  private float timer = 0;
  private int clickNum = 0;
  private bool isClick = false;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);

    if (Input.GetMouseButtonDown(0)) {
      CameraShake.ins.Shake();
      if (isClick == false) {
        isClick = true;
        timer = 0;
        clickNum = 0;
      }
      clickNum++;
    }
    if (isClick) {
      timer += Time.deltaTime;
      if (clickNum >= 3) {
        appleAnimator.Play("WrapAnim");
        isClick = false;
      }
      if (timer >= 1) {
        timer = 0;
        clickNum = 0;
        isClick = false;
      }
    }
  }
}
