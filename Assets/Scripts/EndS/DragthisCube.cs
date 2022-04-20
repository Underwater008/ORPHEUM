using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragthisCube : MonoBehaviour {


  public float distance;
  public Transform _camera;
  public float movespeed = 4f;
  public float stepLength;

  bool canMove = false;
  [SerializeField]
  Vector3 direction;
  private Vector3 lastCubePostion;

  public int curx = 1;
  public int curY = 1;


  private void Start() {
    lastCubePostion = transform.position;
  }

  private void Update() {
    float cubePos = GetComponent<Transform>().position.z;
    distance = Mathf.Abs(_camera.position.z - cubePos);
  }

  private void OnMouseDrag() {
    if (canMove != false) { return; }
    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //stepLength = Mathf.Abs(stepLength);

    if (Mathf.Abs(Vector3.Distance(objectPosition, lastCubePostion)) >= stepLength) {
      direction = (objectPosition - lastCubePostion).normalized;
      if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y)) {
        if (direction.x>0) {
          if (DragManager._drag.CanthisGridMove(curx,curY,"Right")) {
            DragManager._drag.cellArray[curx, curY] = 0;
            StartCoroutine(MoveStone(Vector3.right, Mathf.Sign(direction.x), true));
          }

        }
        else {
          if (DragManager._drag.CanthisGridMove(curx, curY, "Left")) {
            DragManager._drag.cellArray[curx, curY] = 0;
            StartCoroutine(MoveStone(Vector3.right, Mathf.Sign(direction.x), true));
          }
        }
      }
      else {
        if (direction.y>0&& DragManager._drag.CanthisGridMove(curx, curY, "Up")) {
          DragManager._drag.cellArray[curx, curY] = 0;
          StartCoroutine(MoveStone(Vector3.up, Mathf.Sign(direction.y), false));
        }
        else if(direction.y < 0 && DragManager._drag.CanthisGridMove(curx, curY, "Down")) {
          DragManager._drag.cellArray[curx, curY] = 0;
          StartCoroutine(MoveStone(Vector3.up, Mathf.Sign(direction.y), false));
        }
      }
      canMove = true;
    }
  }
  private void OnMouseUp() {
    canMove = false;
    lastCubePostion = transform.position;
    direction = Vector3.zero;
  }

  IEnumerator MoveStone(Vector3 direction, float dir,bool xory) {
    yield return new WaitForSeconds(0.2f);
    while (Vector3.Distance(transform.position, lastCubePostion + direction * stepLength * dir) > 0.1f) {
      transform.position += direction * Time.deltaTime * movespeed * dir;
      yield return new WaitForEndOfFrame();
    }
    if (xory) {
      curx += (int)(dir * 1);
    }
    else {
      curY -= (int)(dir * 1);
    }
    DragManager._drag.cellArray[curx, curY] = 1;
  }
}
