using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IoCPuzzle2Control : MonoBehaviour {
  public SwitchDetect switch0Detect;
  public SwitchDetect switch1Detect;
  public SwitchDetect switch2Detect;
  public SwitchDetect switch3Detect;


  public AppleRotate stageControl;
  public SoundManager soundManager;

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

    if (switch1Detect.GetComponent<SwitchDetect>().detected == true && switch0Detect.GetComponent<SwitchDetect>().detected == true && switch2Detect.GetComponent<SwitchDetect>().detected == true && switch3Detect.GetComponent<SwitchDetect>().detected == true) {
      //if (!isChangeThirdStage) {
      //isChangeThirdStage = true;
      Debug.Log("passed");
      Pass();
    }
  }

  public void Pass() {
    stageControl.StartTheThirdStage();
  }
}
