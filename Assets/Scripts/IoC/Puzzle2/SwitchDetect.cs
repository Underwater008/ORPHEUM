using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDetect : MonoBehaviour
{
  public GameObject openTube;
  public GameObject activeSwitch;
  public SoundManager soundManager;

  public bool detected;

  private void OnTriggerStay(Collider other) {
    if (other.gameObject == openTube) {
      Debug.Log(detected);
      detected = true;
    }
  }

  private void OnTriggerEnter(Collider other) {
    
    if (other.gameObject == openTube) {
      soundManager.PlayAudioWaterOk();
      //detected = true;
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


    //detected = false;

    }
}
