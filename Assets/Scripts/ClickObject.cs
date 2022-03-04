using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickObject : MonoBehaviour
{
  public UnityEvent onClick;
  public bool triggerOnlyOnce = false;

  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hitInfo;
      if (Physics.Raycast(ray, out hitInfo)) {
        if (hitInfo.collider.gameObject.name == gameObject.name) {
          onClick.Invoke();
          if (triggerOnlyOnce) {
            Destroy(this);
          }
        }
      }
    }  }
}
