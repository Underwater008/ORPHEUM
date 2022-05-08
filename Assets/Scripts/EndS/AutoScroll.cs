using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class AutoScroll : MonoBehaviour
{

    public ScrollRect Scroll;

    public float speed=15f;
  private Tweener mytween;

  void OnEnable() {
      startplay();
    }

    void OnDisable() {
        stopPlay();
    }

    void Awake() {
        // Scroll =this.GetComponentInChildren<ScrollRect>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }


    void startplay(){
           Scroll.normalizedPosition = new Vector2(0,1f);
         mytween=Scroll.DONormalizedPos(Vector2.zero,speed).SetEase(Ease.Linear);
        mytween.Play();
    }
    // public float pos;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){

            startplay();
    
        
    
        }

        if(Input.GetKeyDown(KeyCode.F)){
            stopPlay();
        }
    }

  private void stopPlay() {
    Debug.Log("stop");
    mytween.Kill();
    Scroll.normalizedPosition = new Vector2(0f,1f);
  }
}
