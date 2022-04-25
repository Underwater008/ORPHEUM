using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayCube : MonoBehaviour
{
    public Transform[] allchildren;

    private Vector3[] childrenPlaces;

    public bool locked = false;

    [SerializeField]
    float leftEdge, rightEdge, topEdge, downEdge;

    public float movespeed;
    private void Start() {
      childrenPlaces = new Vector3[allchildren.Length];
      //SaveChildrenPositions();
    }
    public void SaveChildrenPositions() {

    for (int i =0;i<childrenPlaces.Length;i++) {
      childrenPlaces[i] = allchildren[i].position;

      if (childrenPlaces[i].x<leftEdge) {
          leftEdge = childrenPlaces[i].x;
      }
      if (childrenPlaces[i].x > rightEdge) {
        rightEdge = childrenPlaces[i].x;
      }
      if (childrenPlaces[i].y < downEdge) {
        downEdge = childrenPlaces[i].y;
      }
      if (childrenPlaces[i].y > topEdge) {
        topEdge = childrenPlaces[i].y;
      }
    }     
    }

    public void ExchangeChild(int curIndex ,Transform curPos) 
    {
      int originIndex = curPos.GetComponent<DecayCubePart>().startIndex;
      Transform nearestOne = Camera.main.transform;
      float nearest = Mathf.Pow(curPos.position.x-nearestOne.position.x,2)+ Mathf.Pow(curPos.position.y - nearestOne.position.y, 2);
      int nearindex = 0; 
      for (int i =0; i < allchildren.Length;i++) {

      if (Mathf.Pow(curPos.position.x - childrenPlaces[i].x, 2) + Mathf.Pow(curPos.position.y - childrenPlaces[i].y, 2) < nearest) {
              nearestOne = allchildren[i];
              nearindex = i;
              nearest = Mathf.Pow(curPos.position.x - childrenPlaces[i].x, 2) + Mathf.Pow(curPos.position.y - childrenPlaces[i].y, 2);
          }
      allchildren[i].GetComponent<DecayCubePart>().hasbeenLocked = true;
      }
    if (locked) 
    {
        curPos.position= childrenPlaces[originIndex];
    }
    else {
      locked = true;
      //curPos.position = nearestOne.position;
      //nearestOne.position = childrenPlaces[originIndex];
      StartCoroutine(SmoothChangePos(curPos, nearestOne.position, nearestOne, childrenPlaces[originIndex]));
      curPos.GetComponent<DecayCubePart>().startIndex = nearestOne.GetComponent<DecayCubePart>().startIndex;
      nearestOne.GetComponent<DecayCubePart>().startIndex = originIndex;

      allchildren[nearindex] = curPos;
      allchildren[originIndex] = nearestOne;
    }

  }

    IEnumerator SmoothChangePos(Transform trans1,Vector3 targetPos1, Transform trans2, Vector3 targetPos2) {
      Cursor.visible = false;
      while (Vector3.Distance(trans1.position,targetPos1)>0.01f) {
      trans1.position = Vector3.Lerp(trans1.position, targetPos1, Time.fixedDeltaTime * movespeed);
      trans2.position = Vector3.Lerp(trans2.position, targetPos2, Time.fixedDeltaTime * movespeed);
      yield return new WaitForFixedUpdate();
      }
      trans1.position = targetPos1;
      trans2.position = targetPos2;
      SaveChildrenPositions();
      locked = false;
      Cursor.visible = true;
      EnableAllChildren();
  }

  public void EnableAllChildren() {
    for (int i = 0; i < allchildren.Length; i++) {
      allchildren[i].GetComponent<DecayCubePart>().hasbeenLocked = false;
    }
  }
}
