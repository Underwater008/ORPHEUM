using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeSky : MonoBehaviour {

  public static ChangeSky Instance;

  public Material skybox1, skybox2, skybox3;

  public Material orignal;

  public Color color1;
  public Color color2;

  void Awake() {
    Instance = this;
  }

  // Start is called before the first frame update
  void Start() {
    // RenderSettings.skybox =skybox2;

    RenderSettings.skybox = orignal;
    color1 = skybox1.GetColor("_Bottom");
    color2 = skybox1.GetColor("_Top");

    orignal.SetColor("_Bottom", color1);
    orignal.SetColor("_Top", color2);




    // material.SetColor("_Bottom",)

    // material.DOColor()

  }


  public void ChangeColor(int i) {
    switch (i) {
      case 1:
        SetColor(skybox1);

        break;
      case 2:
        SetColor(skybox2);

        break;
      case 3:
        SetColor(skybox3);

        break;
    }
  }


  public void SetColor(Material material){
        color1 = material.GetColor("_Bottom");
        color2 = material.GetColor("_Top");
        
      RenderSettings.skybox.DOColor(color1, "_Bottom", 1f);
      RenderSettings.skybox.DOColor(color2, "_Top", 1f);
  }



  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha4)) {
      // RenderSettings.skybox =
        ChangeColor(1);
    //   RenderSettings.skybox.DOColor(color1, "_Bottom", 2f);
    //   RenderSettings.skybox.DOColor(color2, "_Top", 2f);


    //   // material.DOColor(skybox1.GetColor("Top"));
    //   RenderSettings.skybox = skybox1;
      // RenderSettings.skybox

    }
    else if (Input.GetKeyDown(KeyCode.Alpha5)) {
    //   RenderSettings.skybox = skybox2;
        ChangeColor(2);


    }
    else if (Input.GetKeyDown(KeyCode.Alpha6)) {
    //   RenderSettings.skybox = skybox3;
        ChangeColor(3);


    }
  }
}
