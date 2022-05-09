using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlendManager : MonoBehaviour {

    public static BlendManager Instance{private set;get;}

  public List<blendScript> FlowerBlends;
  public List<blendScript> GrassBlends;

  public List<blendScript> TreeBlends;


  public Transform Flowers;
  public Transform Trees;
  public Transform Grass;

  public float blendValue = 0;

  void Awake() {
      Instance=this;
  }

  // Start is called before the first frame update
  void Start() {
    FlowerBlends = new List<blendScript>(Flowers.GetComponentsInChildren<blendScript>());
    GrassBlends = new List<blendScript>(Grass.GetComponentsInChildren<blendScript>());
    TreeBlends = new List<blendScript>(Trees.GetComponentsInChildren<blendScript>());

  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha7)) {
        ChangeTheGrassToDecay();
    }
     if (Input.GetKeyDown(KeyCode.Alpha8)) {
        ChangeTheFlowerToDecay();
    }
     if (Input.GetKeyDown(KeyCode.Alpha9)) {
        ChangeTheTreeToDecay();
    }
  }


  public void ChangeTheFlowerToDecay() {
    var myval = 0f;
    DOTween.To(() => myval, x => myval = x, 1, 1).OnUpdate(() => {

      ChangeTheFlowers(myval);

    });
  }

  public void ChangeTheGrassToDecay() {
    var myval = 0f;
    DOTween.To(() => myval, x => myval = x, 1, 1).OnUpdate(() => {

      ChangeTheGrass(myval);

    });
  }

  public void ChangeTheTreeToDecay() {
    var myval = 0f;
    DOTween.To(() => myval, x => myval = x, 1, 1).OnUpdate(() => {

      ChangeTheTrees(myval);

    });
  }



  private void ChangeTheFlowers(float value) {
    // Debug.Log(value);
    foreach (var item in FlowerBlends) {
      item.duration = value;
    }
  }


    private void ChangeTheGrass(float value) {
    // Debug.Log(value);
    foreach (var item in GrassBlends) {
      item.duration = value;
    }
  }

    private void ChangeTheTrees(float value) {
    // Debug.Log(value);
    foreach (var item in TreeBlends) {
      item.duration = value;
    }
  }
}
