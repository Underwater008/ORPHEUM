using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IoCPuzzleControl : MonoBehaviour
{
  public GameObject switch0;
  public GameObject switch1;

  public SwitchDetect switch0Detect;
  public SwitchDetect switch1Detect;

  public GameObject switch1Cube;

  public AppleRotate stageControl;
  //private bool isChangeThirdStage = false;
  public SoundManager soundManager;

  // Start is called before the first frame update
  void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (switch1Detect.GetComponent<SwitchDetect>().detected == true && switch0Detect.GetComponent<SwitchDetect>().detected == true) {
          //if (!isChangeThirdStage) {
            //isChangeThirdStage = true;
            Debug.Log("passed");
            Pass1();
          
        }
    }

    public void Pass1() {
    //staticPipe4.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => 
    {
      //soundManager.PlayAudioWaterOk();
      stageControl.StartTheSecondStage();

      //soundManager.PlayPuzzleCompleteChime();
    }
}
}
