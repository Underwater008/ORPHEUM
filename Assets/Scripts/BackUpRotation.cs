using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
  Horizontal,
  Vertical
}
public class TouchRotation : MonoBehaviour
{

  public float speed = 10;
  public Transform target;

  private bool isRotate = false;
  private bool afterRotate = false;
  private float angle = 0;
  private Quaternion targetAngle;
  private Direction direction = Direction.Horizontal;
  // Update is called once per frame
  void Update()
  {
    if (CanRotate())
    {
      direction = DetermineDirectionOfRotation();
    }
    if (isRotate)
    {
      angle += FollowMouse();
    }
    if (isRotate && Input.GetMouseButtonUp(0))
    {
      isRotate = false;
      afterRotate = true;

      if (direction == Direction.Horizontal)
      {
        angle = Complete90Degrees(angle);
        Vector3 forward = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0)) * target.forward;
        Vector3 up = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0)) * target.up;
        targetAngle = Quaternion.LookRotation(forward, up);
      }
      else
      {
        angle = Complete180Degrees(angle);
        Vector3 forward = Quaternion.AngleAxis(angle, new Vector3(1, 0, 0)) * target.forward;
        Vector3 up = Quaternion.AngleAxis(angle, new Vector3(1, 0, 0)) * target.up;
        targetAngle = Quaternion.LookRotation(forward, up);
      }
    }
    if (afterRotate)
    {

      target.rotation = Quaternion.Lerp(target.rotation, targetAngle, 0.1f);
      if (Vector3.Distance(targetAngle.eulerAngles, target.eulerAngles) <= 1)
      {
        target.rotation = targetAngle;
        afterRotate = false;
        angle = 0;
      }
    }
  }

  private bool CanRotate()
  {
    return afterRotate == false && isRotate == false && Input.GetMouseButton(0);
  }
  private Direction DetermineDirectionOfRotation()
  {
    float x = Input.GetAxis("Mouse X");
    float y = Input.GetAxis("Mouse Y");
    if (Mathf.Abs(x) > Mathf.Abs(y))
    {
      isRotate = true;
      return Direction.Horizontal;
    }
    else if (Mathf.Abs(x) < Mathf.Abs(y))
    {
      isRotate = true;
      return Direction.Vertical;
    }
    return Direction.Horizontal;
  }
  private float FollowMouse()
  {
    if (direction == Direction.Horizontal)
    {
      float x = Input.GetAxis("Mouse X");
      Vector3 rotate = new Vector3(0, -x, 0);
      target.Rotate(rotate * speed, Space.World);
      return -x * speed;
    }
    else
    {
      float y = Input.GetAxis("Mouse Y");
      Vector3 rotate = new Vector3(y, 0, 0);
      target.Rotate(rotate * speed, Space.World);
      return y * speed;
    }
  }
  private float Complete90Degrees(float angle)
  {
    angle = angle % 90;
    if (angle <= 45 && angle >= -45)
    {
      angle = -angle;
    }
    else if (angle > 45)
    {
      angle = 90 - angle;
    }
    else if (angle < -45)
    {
      angle = -90 - angle;
    }
    return angle;
  }
  private float Complete180Degrees(float angle)
  {
    angle = angle % 180;
    if (angle <= 90 && angle >= -90)
    {
      angle = -angle;
    }
    else if (angle > 90)
    {
      angle = 180 - angle;
    }
    else if (angle < -90)
    {
      angle = -180 - angle;
    }
    return angle;
  }
}

