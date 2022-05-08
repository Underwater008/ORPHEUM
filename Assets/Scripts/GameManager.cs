using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{private set;get;}

    public bool isGameStart=false;

    public Transform Parent;

    public GameObject Effect;
    void Awake() {
        Instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0){
            Debug.Log(Input.GetTouch(0).position);
        }  

        if(Input.GetMouseButtonDown(0)){
            CreateEffect();
            var v3 = Input.mousePosition;
            Debug.Log(v3);
        } 



    }

    public void CreateEffect(){
       var obj= Instantiate(Effect,Parent.transform);
       obj.transform.position = Input.mousePosition;
       Destroy(obj,2f);
    }
}
