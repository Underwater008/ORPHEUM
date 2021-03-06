using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
  public int distance;
  [SerializeField] private Transform emptySpace = null;
  private Camera _camera;

  void Start() {
    _camera = Camera.main;
  }

  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
      if (hit) {
        if (Vector2.Distance(emptySpace.position, hit.transform.position) < distance) {
          Vector2 lastEmptySpacePosition = emptySpace.position;
          emptySpace.position = hit.transform.position;
          hit.transform.position = lastEmptySpacePosition;
        }
      }
    }
  }
}
  

