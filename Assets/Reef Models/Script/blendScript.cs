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
    //float duration = 2f;
    public Renderer rend;

    void Start() {
    rend.material = tree.GetComponent<MeshRenderer>().materials[0];
  }

    void Update() {
    //material1.DOFade(0, 2);
    if (Input.GetKeyDown(KeyCode.C)) {
      material1 = tree.GetComponent<MeshRenderer>().materials[0];
      print(material1);
      material2 = tree.GetComponent<MeshRenderer>().materials[1];
      rend.material.Lerp(material1, material2, 1);
      material1.DOColor(new Color32(143, 0, 254, 1), 1).OnComplete(() => {
        rend.material = tree.GetComponent<MeshRenderer>().materials[1];
      });
      //StartCoroutine(ChangeMaterial());
    }

  }

    public IEnumerator ChangeMaterial() {
      float a = 0;
      Debug.Log(a);
      while (a <= 1) {
      Debug.Log("material2 showing");
      yield return new WaitForEndOfFrame();
      Material material2 = tree.GetComponent<Renderer>().materials[0];
      Color c = material2.color;
      c.a = a;
      material2.color = c;
      a += Time.deltaTime / 3;
    }
    }
}

