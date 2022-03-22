using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puzzle2Control : MonoBehaviour
{
  public GameObject switch1;
  public GameObject switch2;
  public GameObject switch3;
  public GameObject switch4;

  public GameObject staticPipe1;
  public GameObject staticPipe2;
  public GameObject staticPipe3;
  public GameObject staticPipe4;

  public GameObject openTube1;
  public GameObject openTube2;
  public GameObject bottomExit;

  public SwitchDetect switch0Detect;
  public SwitchDetect switch1Detect;
  public SwitchDetect switch2Detect;
  public SwitchDetect switch3Detect;

  public WaterPipeControl stageControl;
  private bool isChangeThirdStage = false;
  public SoundManager soundManager;
  // Start is called before the first frame update
  void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (switch0Detect.GetComponent<SwitchDetect>().detected == true) {
        switch1.SetActive(false);
        switch2.SetActive(true);
        PassStep1();
        
        }

        if (switch1Detect.GetComponent<SwitchDetect>().detected == true) {
        switch2.SetActive(false);
        switch3.SetActive(true);
        PassStep2();
        }

        if (switch2Detect.GetComponent<SwitchDetect>().detected == true) {
        switch3.SetActive(false);
        switch4.SetActive(true);
        PassStep3();
        }

    if (switch3Detect.GetComponent<SwitchDetect>().detected == true) {
      switch4.SetActive(false);
      if (!isChangeThirdStage) 
      {
        isChangeThirdStage = true;
        PassStep4();
      }
    }
    }

    public void PassStep1() {
    openTube1.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
      staticPipe1.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
      });
    });
    }

    public void PassStep2() {
    openTube2.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {
      staticPipe2.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {

      });
    });
    }

    public void PassStep3() {
    staticPipe3.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => {

    });
    }

    public void PassStep4() {
    staticPipe4.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => 
    {
      soundManager.PlayAudioWaterOk();
      bottomExit.GetComponent<Renderer>().material.DOColor(new Color(0.86f, 0.2f, 0.73f), 1).OnComplete(() => 
      {
        stageControl.StartThirdStage();


      });
    });
    }
}
