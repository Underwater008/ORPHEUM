using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
  public bool vertical = false;
  public float speed = 0.01f;
  public float limitY = 10;
  private Camera cam;
  public bool isDrag = false;
  private float deltaY = 0;
  // Start is called before the first frame update
  void Start() {
    cam = Camera.main;
  }

  // Update is called once per frame
  void Update() {
    if (isDrag == false) {
      Ray ray = cam.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Input.GetMouseButtonDown(0) ||(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == gameObject.name) {
          isDrag = true;
        }
      }
    }
    else {
      float x = Input.GetAxis("Mouse X");
      float y = Input.GetAxis("Mouse Y");
      if (Input.touchCount > 0) {
        x = x == 0 ? Input.GetTouch(0).deltaPosition.x * speed : x;
        y = y == 0 ? Input.GetTouch(0).deltaPosition.y * speed : y;
      }
      if (vertical == false) {
        deltaY += y;
        if(Mathf.Abs(deltaY) > limitY) {
          y = 0;
        }
      }
      transform.Translate(x, y, 0, Space.World);
      

      if (Input.GetMouseButtonUp(0)) {
        deltaY = 0;
        isDrag = false;
      }
    }


  }
}
