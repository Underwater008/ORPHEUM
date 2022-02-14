using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRotate : MonoBehaviour {
  public float speed = 30;
  public Animator appleAnimator;
  public GameObject[] clouds;

  private float timer = 0;
  private int clickNum = 0;
  private bool isClick = false;
  private bool CanShake = true;
  // Start is called before the first frame update
  void Start() {
    foreach (var cloud in clouds) {
      cloud.SetActive(false);
      Material m = cloud.GetComponent<Renderer>().material;
      Color c = m.color;
      c.a = 0;
      m.color = c;
    }
  }

  // Update is called once per frame
  void Update() {
    transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);

    if (Input.GetMouseButtonDown(0) && CanShake) {
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
        CanShake = false;
      }
      if (timer >= 1) {
        timer = 0;
        clickNum = 0;
        isClick = false;
      }
    }
  }

  public IEnumerator ShowCloud() {
    foreach(var cloud in clouds) {
      cloud.SetActive(true);
    }
    float a = 0;
    while (a <= 1) {
      Debug.Log(22);
      yield return new WaitForEndOfFrame();
      foreach (var cloud in clouds) {
        Material m = cloud.GetComponent<Renderer>().material;
        Color c = m.color;
        c.a = a;
        m.color = c;
        a += Time.deltaTime / 3;
      }
    }
  }
}
