using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class blendScript : MonoBehaviour
{
  // Blends between two materials
    public GameObject tree;
    public Material material1;
    public Material material2;
    public float duration = 0f;
    public Renderer rend;

    void Start() {
    if (tree == null) {
      rend = this.gameObject.GetComponent<Renderer>();
    }
  }

    void Update() {
    rend.material.Lerp(material1, material2, duration);
  }


}

