using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDetect : MonoBehaviour
{
  public GameObject openTube;
  public GameObject activeSwitch;

  public bool detected;

  private void OnTriggerStay(Collider other) {
        if (other.gameObject == openTube) {
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
        detected = false;
    }
}
