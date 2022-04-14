using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragthisCube : MonoBehaviour {
  public float distance;

  public float stepLength;


  private Vector3 lastCubePostion;
  private void Start() {
    lastCubePostion = transform.position;
  }
  private void OnMouseDrag() {

    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    if (Vector3.Distance(objectPosition, lastCubePostion) >= stepLength) {
      Vector3 direction = (objectPosition - lastCubePostion).normalized;

      if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y)) {

        transform.position += Vector3.right * stepLength * Mathf.Sign(direction.x);
      }
      else {
        transform.position += Vector3.up * stepLength * Mathf.Sign(direction.y);
      }

      lastCubePostion = transform.position;
    }
  }


}
