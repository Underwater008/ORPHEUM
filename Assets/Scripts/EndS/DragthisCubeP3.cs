using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragthisCubeP3 : MonoBehaviour {


  public float distance;
  public Transform _camera;
  public float movespeed = 4f;
  public float stepLength;
  [SerializeField]
  bool canMove = false;
  [SerializeField]
  Vector3 direction;

  [SerializeField]
  private Vector3 lastCubePostion;

  public int curx = 1;
  public int curY = 1;


  private void Start() {
    // lastCubePostion = transform.position;
  }

  private void Update() {
    // float cubePos = GetComponent<Transform>().position.z;
    float cubePos = this.transform.position.z;
    distance = Mathf.Abs(cubePos - _camera.position.z);
  }

  private void OnMouseDown() {
    if (Puzzle3DragManager._drag.CurrentDragCube == null) {
      Puzzle3DragManager._drag.CurrentDragCube = this;
      lastCubePostion = this.transform.position;
    }
  }

  private void OnMouseDrag() {

    //if (Puzzle3DragManager._drag.CurrentDragCube != this) {
    //return;
    //}
    // Debug.Log("drag" + this.transform.gameObject.name);
    //if (canMove != false) { return; }

    if (Puzzle3DragManager._drag.isDraging == true) {
      return;
    }

    // Debug.Log("开始判断这个方块");

    //获取到鼠标的位置;
    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

    //获取世界坐标的位置;
    Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //stepLength = Mathf.Abs(stepLength);

    Debug.Log(objectPosition);
    Debug.Log(lastCubePostion);

    // Debug.Log(Vector3.Distance(objectPosition, lastCubePostion));

    if (Mathf.Abs(Vector3.Distance(objectPosition, lastCubePostion)) >= stepLength) {
      direction = (objectPosition - lastCubePostion).normalized;

      // Debug.Log(direction);






      // return;

      // Debug.Log(Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Up"));

      // return;

      if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y)) {


        Debug.Log(direction);
        if (direction.x > 0) {

          if (Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Right")) {
            Debug.Log("向右滑");

            // Puzzle3DragManager._drag.cellArray[curx, curY] = 0;
            StartCoroutine(MoveStone(Vector3.right, Mathf.Sign(direction.x), true));
          }
        }
        else {



          if (Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Left")) {
            // Puzzle3DragManager._drag.cellArray[curx, curY] = 0;
            Debug.Log("向左滑");
            StartCoroutine(MoveStone(Vector3.left, Mathf.Sign(direction.x), true));
          }
        }
      }
      else {
        Debug.Log(direction);
        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x)) {
          if (direction.y > 0) {
            if (Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Up")) {
              // Puzzle3DragManager._drag.cellArray[curx, curY] = 0;
              Debug.Log("向上滑");
              StartCoroutine(MoveStone(Vector3.up, Mathf.Sign(direction.y), false));
            }

          }
          else {
            if (Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Down")) {
              Debug.Log("向下滑");
              StartCoroutine(MoveStone(Vector3.down, Mathf.Sign(direction.y), false));
            }
          }

        }

        // if (direction.y > 0 && Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Up")) {
        //   // Puzzle3DragManager._drag.cellArray[curx, curY] = 0;
        // Debug.Log("向上滑");

        //   // StartCoroutine(MoveStone(Vector3.up, Mathf.Sign(direction.y), false));
        // }
        // else if (direction.y < 0 && Puzzle3DragManager._drag.CanthisGridMove(curx, curY, "Down")) {
        //   Debug.Log("向下滑");

        // Puzzle3DragManager._drag.cellArray[curx, curY] = 0;
        // StartCoroutine(MoveStone(Vector3.up, Mathf.Sign(direction.y), false));

      }
      // canMove = true;
    }
  }
  private void OnMouseUp() {
    canMove = false;
    lastCubePostion = transform.position;
    direction = Vector3.zero;
    Puzzle3DragManager._drag.CurrentDragCube = null;
  }

  IEnumerator MoveStone(Vector3 direction, float dir, bool xory) {
    Puzzle3DragManager._drag.isDraging = true;
    yield return new WaitForSeconds(0.1f);

    Debug.Log("执行一次");
    Vector3 targetPos = Vector3.zero;
    if (xory) {

      targetPos = transform.position + direction * 2.7f;
    }
    else {
      targetPos = transform.position + direction * 2.6f;
    }

    while (Vector3.Distance(transform.position, targetPos) > 0.001f) {
      transform.position = Vector3.Lerp(transform.position, targetPos, 5 * Time.deltaTime);
      yield return null;
    }
    Debug.Log("Jumpout the loop");

    Puzzle3DragManager._drag.isDraging = false;

    // Debug.Log(direction);

    // while (Vector3.Distance(transform.position, lastCubePostion + direction * stepLength * dir) > 0.05f) {
    //   transform.position += direction * Time.deltaTime * 4 * dir;
    //   yield return new WaitForEndOfFrame();
    // }

    canMove = true;
    if (xory) {
      curY += (int)(dir * 1);
    }
    else {
      curx -= (int)(dir * 1);
    }
    // Puzzle3DragManager._drag.cellArray[curx, curY] = 1;
  }
}
