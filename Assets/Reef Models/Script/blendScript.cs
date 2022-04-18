using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blendScript : MonoBehaviour
{
    // Blends between two materials

    private Material material1;
    public Material material2;
    float duration = 1.0f;
    public Renderer rend;

    void Start()
    {
        material1 = GetComponent<Renderer>().material;
        // At start, use the first material
            Debug.Log(material1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
      //ChangeMaterial();
        GetComponent<Renderer>().material = material2;

    }

        if(rend.material == material1){
            Debug.Log("im in material1");
        } else if(rend.material == material2){
            Debug.Log("im in material2");
        }
        // ping-pong between the materials over the duration

    }

    public IEnumerator ChangeMaterial() {
    float a = 0;
  while (a <= 1) {
    Debug.Log("material changing");
    yield return new WaitForEndOfFrame();
        Material matA = material1;
        Material matB = material2;
        //matA = a;
        matA = matB;
        a += Time.deltaTime / 3;
  }
  }
}