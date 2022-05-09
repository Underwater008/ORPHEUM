using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class WrapAnim : MonoBehaviour
{

    public GameObject WrapBox;

    // public GameObject Apple;

    public GameObject LocPuzzle;
  private AppleRotate _appleRotate;

  // Start is called before the first frame update
  void Start()
    {
        // Apple.transform.DORotate(new Vector3(0,360,0),10f,RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart).SetRelative();
        if(LocPuzzle!=null){
            _appleRotate=LocPuzzle.GetComponent<AppleRotate>();
        }
        // LocPuzzle = GameObject.Find("IOC Puzzle");
    }

    public void BeginTestStart(){
    //this.gameObject.SetActive(false);
    LocPuzzle.SetActive(true);
        _appleRotate.TestStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginWrap(){

    }

  internal void BeginGame() {
      WrapBox.gameObject.SetActive(true);
        _appleRotate.TestStart1();
      Invoke("BeginTestStart",5f);
  }

  internal void DeleteCube() {
    this.gameObject.SetActive(false);
  }

  internal void DetachFromParent() {
    transform.parent = null;
  }
}
