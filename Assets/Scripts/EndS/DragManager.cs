using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour {
  public Vector3 CubeOrigin;

  public int cubeNum = 9;

  public int eachCellSize = 1;

  public int[,] cellArray;

  public static DragManager _drag;

  public bool isDraging = false;



  public DragthisCube CurrentDragCube = null;

  // public static DragManager Instance { private set; get; }
  // Start is called before the first frame update

  private void Awake() {
    _drag = this;
  }
  void Start() {
    cellArray = new int[,]
    {
       {1,0,1},
       {1,0,1},
       {1,1,1}
    };



    // var tmp = cellArray[0, 0];
    // print(tmp);
    // print(cellArray[0, 1]);
    // print(cellArray[1, 0]);


    // print(cellArray.GetLength(0));
    printTheCellArr();
  }


  public void printTheCellArr() {
    string str = "";
    for (int i = 0; i < cellArray.GetLength(0); i++) {

      str += "\n";
      for (int j = 0; j < cellArray.GetLength(1); j++) {
        // print(cellArray[i, j]);

        str += i + "" + j + ":" + cellArray[i, j].ToString() + ",";

      }
    }

    print(str);
  }

  public bool CanthisGridMove(int x, int y, string direction) {
    bool defaultBool = false;




    Debug.Log("x" + x + "y:" + y);
    switch (direction) {
      case "Right":
        if (y + 1 < cellArray.GetLength(1)) {
          if (cellArray[x, y + 1] == 0) {
            isDraging = true;
            cellArray[x, y + 1] = 1;
            cellArray[x, y] = 0;

            defaultBool = true;
          }
        }
        // if(x+1<)
        // if (x + 1 < cellArray.GetLength(0) && cellArray[x + 1, y] == 0) {
        //   defaultBool = true;
        // }
        break;

      case "Left":
        Debug.Log("进入left");
        if (y - 1 >= 0) {
          if (cellArray[x, y - 1] == 0) {
            isDraging = true;
            cellArray[x, y - 1] = 1;
            cellArray[x, y] = 0;
            defaultBool = true;
          }
        }
        // if (x - 1 >= 0 && cellArray[x - 1, y] == 0) {
        //   defaultBool = true;
        // }
        break;
      case "Up":


        if (x - 1 >= 0) {
          if (cellArray[x - 1, y] == 0) {
            isDraging = true;

            cellArray[x - 1, y] = 1;
            cellArray[x, y] = 0;
            defaultBool = true;
          }
        }


        break;

      case "Down":

        if (x + 1 < cellArray.GetLength(0)) {
          if (cellArray[x + 1, y] == 0) {
            isDraging = true;
            cellArray[x + 1, y] = 1;
            cellArray[x, y] = 0;
            defaultBool = true;
          }
        }

        // if (y + 1 < cellArray.GetLength(1) && cellArray[x, y + 1] == 0) {
        //   defaultBool = true;
        // }
        break;

    }



    // cellArray[x, y] = 0;

    printTheCellArr();
    return defaultBool;
  }
}
