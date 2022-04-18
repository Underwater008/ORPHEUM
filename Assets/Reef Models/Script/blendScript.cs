using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blendScript : MonoBehaviour
{
    // Blends between two materials

    public Material material1;
    public Material material2;
    float duration = 1.0f;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
        // At start, use the first material
        rend.material = material1;
        if(rend.material == material1){
            Debug.Log("BrO please");
        }
    }

    void Update()
    {
        if(rend.material == material1){
            Debug.Log("im in material1");
        } else if(rend.material == material2){
            Debug.Log("im in material2");
        }
        // ping-pong between the materials over the duration
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(material1, material2, lerp);
    }
}