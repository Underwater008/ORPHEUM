using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour {
  public Vector3 CubeOrigin;

  public int cubeNum = 9;

  public int eachCellSize = 1;

  public int[,] cellArray;

  public static DragManager _drag;
  // Start is called before the first frame update

  private void Awake() {
    _drag = this;
  }
  void Start() {
    cellArray = new int[,]
    {
       {1,0,1},
       {1,0,1},
       {0,1,1}
    };
  }

  public bool CanthisGridMove(int x,int y,string direction) {
    bool defaultBool = false;
    switch (direction)
    {
      case "Right":
        if (x+1< cellArray.GetLength(0)&&cellArray[x+1,y]==0) {
          defaultBool = true;
        }
        break;

      case "Left":
        if (x - 1 >= 0 && cellArray[x - 1, y] == 0) {
          defaultBool = true;
        }
        break;
      case "Up":
        if (y - 1 >= 0 && cellArray[x, y-1] == 0) {
          defaultBool = true;
        }
        break;

      case "Down":
        if (y + 1 < cellArray.GetLength(1) && cellArray[x, y+1] == 0) {
          defaultBool = true;
        }
        break;

    }
    cellArray[x, y] = 0;
    return defaultBool;
  }
}
