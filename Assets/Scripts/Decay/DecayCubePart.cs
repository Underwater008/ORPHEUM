using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayCubePart : MonoBehaviour
{
  public int startIndex;
  public Vector3 originpos;
  public float distance;
  public DecayCube manager;
  public bool hasbeenLocked = false;
  private void Start() {
    originpos = transform.position;
  }
  private void OnMouseDrag() {
    if (hasbeenLocked) { return; }
    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    transform.position = objectPosition;
  }

  private void OnMouseUp() {
    if (hasbeenLocked) { return; }
    manager.ExchangeChild(startIndex, transform);
  }
}
