using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Direction1 {
  Horizontal,
  Vertical
}
public class DragRotation : MonoBehaviour {

  public float speed = 10;
  public Transform target;

  private bool isRotate = false;
  private bool afterRotate = false;
  private float angle = 0;
  private Quaternion targetAngle;
  private Direction1 direction = Direction1.Horizontal;

  private Touch theTouch;
  private Vector2 touchStartPosition, touchEndPosition;
  private string direction2;

  // Update is called once per frame
  void Update() {

    if (Input.touchCount > 0)
    {
      theTouch = Input.GetTouch(0);

      if (theTouch.phase == TouchPhase.Began)
      {
        touchStartPosition = theTouch.position;
      }

      else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
      {
        touchEndPosition = theTouch.position;
      }
    }
        if (CanRotate()) {
      direction = DetermineDirectionOfRotation();
    }
    if (isRotate) {
      angle += FollowMouse();
    }
    if (isRotate && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) { 

      isRotate = false;
      afterRotate = true;

      if(direction == Direction1.Horizontal) {
        angle = Complete90Degrees(angle);
        Vector3 forward = Quaternion.AngleAxis(angle, new Vector3(0,1,0)) * target.forward;
        Vector3 up = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0)) * target.up;
        targetAngle = Quaternion.LookRotation(forward, up);
      }
      else {
        angle = Complete180Degrees(angle);
        Vector3 forward = Quaternion.AngleAxis(angle, new Vector3(1, 0, 0)) * target.forward;
        Vector3 up = Quaternion.AngleAxis(angle, new Vector3(1, 0, 0)) * target.up;
        targetAngle = Quaternion.LookRotation(forward, up);
      }
    }
    if (afterRotate) {

      target.rotation = Quaternion.Lerp(target.rotation, targetAngle, 0.1f);
      if (Vector3.Distance(targetAngle.eulerAngles, target.eulerAngles) <= 1) {
        target.rotation = targetAngle;
        afterRotate = false;
        angle = 0;
      }
    }
  }

  private bool CanRotate() {
    return afterRotate == false && isRotate == false && Input.touchCount > 0;
  }

  private Direction1 DetermineDirectionOfRotation() {


        float x = touchEndPosition.x - touchStartPosition.x;
        float y = touchEndPosition.y - touchStartPosition.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
          isRotate = true;
          return Direction1.Horizontal;
        }

        /*if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
        {

          //direction2 = “Tapped”;
        }*/

        else if (Mathf.Abs(x) < Mathf.Abs(y))
        {
          isRotate = true;
          return Direction1.Vertical;
        }
          return Direction1.Horizontal;

    /*float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");
    if(Mathf.Abs(x) > Mathf.Abs(y)) {
      isRotate = true;
      return Direction1.Horizontal;
    }
    else if(Mathf.Abs(x) < Mathf.Abs(y)) {
      isRotate = true;
      return Direction1.Vertical;
    }
    return Direction1.Horizontal;*/
  }

  private float FollowMouse() {
    Touch touch = Input.touches[0];
    if(direction == Direction1.Horizontal) {
      float x = touch.deltaPosition.x;    //Input.GetAxis("Horizontal");
      Vector3 rotate = new Vector3(0, -x, 0);
      target.Rotate(rotate * speed, Space.World);
      return -x * speed;
    }
    else {
      float y = touch.deltaPosition.y;//Input.GetAxis("Vertical");
      Vector3 rotate = new Vector3(y, 0, 0);
      target.Rotate(rotate * speed, Space.World);
      return y * speed;
    }
  }
  private float Complete90Degrees(float angle) {
    angle = angle % 90;
    if(angle <= 45 && angle >= -45) {
      angle = -angle;
    }
    else if(angle > 45) {
      angle = 90 - angle;
    }
    else if(angle < -45) {
      angle = -90 - angle;
    }
    return angle;
  }
  private float Complete180Degrees(float angle) {
    angle = angle % 180;
    if (angle <= 90 && angle >= -90) {
      angle = -angle;
    }
    else if (angle > 90) {
      angle = 180 - angle;
    }
    else if (angle < -90) {
      angle = -180 - angle;
    }
    return angle;
  }
}
