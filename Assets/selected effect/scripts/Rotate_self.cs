using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_self : MonoBehaviour
{

  private bool isRotate = true;
  public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    if (isRotate) {
      transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }
  }
}
