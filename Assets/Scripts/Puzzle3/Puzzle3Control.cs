using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puzzle3Control : MonoBehaviour {
  public GameObject switch1;
  public GameObject switch2;
  public GameObject switch3;
  public GameObject switch4;

  public GameObject staticPipe1;
  public GameObject staticPipe2;
  public GameObject staticPipe3;
  public GameObject staticPipe4;
  public GameObject staticPipe5;

  public GameObject openTube1;
  public GameObject openTube2;
  public GameObject midCube;
  public GameObject bottomExit;

  public SwitchDetect switch0Detect;
  public SwitchDetect switch1Detect;
  public SwitchDetect switch2Detect;
  public SwitchDetect switch3Detect;

  private bool isChangeThirdStage = false;
  public bool isMidTime = false;
  public SoundManager soundManager;
  public WaterPipeControl stageControl;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (isMidTime) {
      if (midCube.transform.parent.transform.eulerAngles.z == 90) {
        isMidTime = false;
        
        PassStep3();
        switch3.SetActive(true);
      }
      return;
    }
    if (switch0Detect.GetComponent<SwitchDetect>().detected == true) {
      switch0Detect.GetComponent<SwitchDetect>().detected = false;
      switch1.SetActive(false);
      switch2.SetActive(true);
      PassStep1();

    }

    if (switch1Detect.GetComponent<SwitchDetect>().detected == true) {
      switch1Detect.GetComponent<SwitchDetect>().detected = false;
      switch2.SetActive(false);
      PassStep2();
    }



   if (switch2Detect.GetComponent<SwitchDetect>().detected == true) {
      switch2Detect.GetComponent<SwitchDetect>().detected = false;
      switch3.SetActive(false);
      switch4.SetActive(true);
      PassStep4();
    }

    if (switch3Detect.GetComponent<SwitchDetect>().detected == true) {
      switch4.SetActive(false);
      if (!isChangeThirdStage) {
        isChangeThirdStage = true;
        PassStep5();
      }
    }
  }

  public void PassStep1() {
    openTube1.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
    staticPipe1.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1);
    });
  }

  public void PassStep2() {
    openTube2.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
      staticPipe2.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
        isMidTime = true;
      });
    });
  }
  public void PassStep3() {
    midCube.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
      staticPipe3.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1);
    });
  }

  



  public void PassStep4() {
    staticPipe4.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1);
  }

  public void PassStep5() {
    staticPipe5.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
      soundManager.PlayAudioWaterOk();
      bottomExit.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
        stageControl.CloseDoor();

      });
    });
  }
}
