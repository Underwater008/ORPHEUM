using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDetect : MonoBehaviour
{
  public GameObject openTube;
  public GameObject activeSwitch;

  public bool detected;

  private void OnTriggerEnter(Collider other) {
    if (other.tag == "OpenTubes") {
      detected = true;
      Debug.Log(detected);
    }
  }
  // Start is called before the first frame update
  void Start()
    {
        detected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
