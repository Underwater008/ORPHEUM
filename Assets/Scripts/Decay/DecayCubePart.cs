using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayCubePart : MonoBehaviour
{
  public GameObject puzzle1Control;
  public GameObject puzzle2Control;
  public GameObject puzzle3Control;
  public int startIndex;
  public Vector3 originpos;
  public float distance;
  public DecayCube manager;
  public bool hasbeenLocked = false;
  private void Start() {
    originpos = transform.position;
  }
  private void OnMouseDrag() {
    puzzle1Control.SetActive(false);
    puzzle2Control.SetActive(false);
    puzzle3Control.SetActive(false);
    if (hasbeenLocked) { return; }
    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    transform.position = objectPosition;
  }

  private void OnMouseUp() {
    puzzle1Control.SetActive(true);
    puzzle2Control.SetActive(true);
    puzzle3Control.SetActive(true);
    if (hasbeenLocked) { return; }
    manager.ExchangeChild(startIndex, transform);
  }
}