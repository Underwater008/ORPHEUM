using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class AppleRotate : MonoBehaviour {

  //Transition
  public Transform transitionClouds;
  public Transform trnasitionCloudsStart;
  public Transform trnasitionCloudsEnd;
  public GameObject CloudTrigger;

  //music
  public AudioManager audioM;
  public SoundManager soundM;

  //Rotation Speed
  public float speed = 30;

  public GameObject theGarden;
  public GameObject cubeBase;
  public GameObject startUI;
  public GameObject EndUI;
  public GameObject titleUI;
  public GameObject DecayUI;

  public GameObject IOCPuzzle3UI;  //delete before build

  public GameObject puzzle1;
  public GameObject puzzle1Control;
  public GameObject puzzle2;
  public GameObject puzzle2Control;
  public GameObject puzzle3;
  public GameObject puzzle3Control;

  public GameObject tree;                 //the tree
  public GameObject grass;
  public GameObject flower;
  public Transform firstButton;           //the first button we press on the cube
  public Transform startButtonEndMovePos; //the position first button move to when activated
  public Transform cameraPlayPos;         //the position camera move to look at the puzzle top
  public Transform cameraOriginalPos;     //the position camera move to look at the cube
  public Transform cameraPuzzleView;
  public Transform firstDoor;
  public Transform firstDoorOpenPos;
  public Transform firstDoorOGPos;
  public Transform secondDoor;
  public Transform secondDoorOpenPos;
  public Transform secondDoorOGPos;
  public Transform thirdDoor;
  public Transform thirdDoorOpenPos;
  public Transform thirdDoorOGPos;
  public Transform grassSpawnPos;
  public Transform treeSpawnPos;

  public VisualEffect puzzle1VFX;
  public VisualEffect puzzle2VFX;
  public VisualEffect puzzle3VFX;

  public ParticleSystem rockDebris;
  public ParticleSystem rockDebris2;
  public ParticleSystem rockDebris3;

  public float treeScale;

  public DecayPuzzleControl DecayPuzzleControl;

  private bool isRotate = true;
  public bool isStart = false;
  //public bool mouseConfined = false;

  void TestStart() {
    if (isStart) {
      Cursor.lockState = CursorLockMode.Confined;
      Cursor.visible = false;
      startUI.SetActive(false);
      EndUI.SetActive(false);
      titleUI.SetActive(false);
      DecayUI.SetActive(false);
      IOCPuzzle3UI.SetActive(true);
      Camera.main.transform.DORotate(new Vector3 (35, 0,0), 1);
      Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(() => {
        firstButton.gameObject.GetComponent<BoxCollider>().enabled = true;
        ShowStartButton();
      });
    }
  }

  // Update is called once per frame
  void Update() {
    if (isRotate) {
      transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }

      /*if (mouseConfined == true) {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    if (mouseConfined == false) {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }*/
  }

  private void ShowStartButton() {
    firstButton.gameObject.SetActive(true);
    firstButton.DOMove(startButtonEndMovePos.position, 1).OnComplete(() => {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    });
    //ShowTree();
  }

  public void StartTheFirstStage() {
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    Debug.Log("IOC start 1st stage");
    isRotate = false;
    isStart = false;
    //apple.SetActive(false);
    Camera.main.transform.DORotate(new Vector3 (0,0,0), 1);
    Camera.main.transform.DOMove(new Vector3 (0,0, -18.5f), 1).OnComplete(()=> {    //move to look at puzzle
      rockDebris.Play();
      soundM.PlayDoorOpenAudio();
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z - 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z - 2f, 1).OnComplete(() => {
        puzzle1Control.SetActive(true);
        puzzle1.SetActive(true);
        firstDoor.DOMove(firstDoorOpenPos.position, 2).OnComplete(()=> {             //open door
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          rockDebris.Stop();
          Debug.Log("look at puzzle");
      });
      });
    });

    transform.DORotate(new Vector3(0,0,0), 1); //put cube at 0
  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() {
    puzzle1Control.SetActive(false);
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    puzzle1VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    soundM.PlayDoorOpenAudio();
    Vector3 puzzle1Pos = puzzle1.transform.position;
    puzzle1.transform.DOMoveZ(puzzle1Pos.z - 2f, 2).OnComplete(() => {
      firstDoor.DOMove(firstDoorOGPos.position, 2).OnComplete(() => {
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z + 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z + 2f, 1).OnComplete(() => {
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(()=> {
        grass.SetActive(true);
        soundM.PlayAudioWaterOk();
        grass.transform.DOMove(grassSpawnPos.position, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z - 2f, 0);
            Camera.main.transform.DOMove(new Vector3 (0,0,-18.5f), 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(()=> {
              rockDebris2.Play();
              soundM.PlayDoorOpenAudio();
              secondDoor.DOMoveZ(secondDoor.position.z - 2f, 1).OnComplete(() => {
                puzzle2.SetActive(true);
                puzzle2Control.SetActive(true);
                secondDoor.DOMove(secondDoorOpenPos.position, 2).OnComplete(() => {             //open door
                  Cursor.lockState = CursorLockMode.None;
                  Cursor.visible = true;
                  rockDebris2.Stop();
                  Debug.Log("puzzle 2 start");
                });
              });
          });
        });  
      });
    });
    });
    });
    });
  }

  public void StartTheThirdStage() {
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    puzzle2VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    soundM.PlayDoorOpenAudio();
    puzzle2.SetActive(false);
    puzzle2Control.SetActive(false);
    secondDoor.DOMove(secondDoorOGPos.position, 2).OnComplete(() => {
      secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z + 2f, 0);
      secondDoor.DOMoveZ(secondDoor.position.z + 2f, 1).OnComplete(() => {
         Debug.Log("puzzle3");
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
        Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(()=> { //look at cube
        flower.SetActive(true);
        Debug.Log("hi");
        soundM.PlayAudioWaterOk();
        flower.transform.DOMove(grassSpawnPos.position, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 180f, 0), 2f).OnComplete(() => {
            Debug.Log("look at puzzle 3");
            Camera.main.transform.DOMove(new Vector3(0, 0, -18.5f), 1); //look at puzzle
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(()=> {
              rockDebris3.Play();
              soundM.PlayDoorOpenAudio();
              thirdDoorOGPos.DOMoveZ(thirdDoor.position.z - 2f, 2);
              thirdDoor.DOMoveZ(thirdDoor.position.z - 2f, 2).OnComplete(() => {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                rockDebris3.Stop();
                puzzle3.SetActive(true);
                puzzle3Control.SetActive(true);
                thirdDoor.DOMove(thirdDoorOpenPos.position, 2f);
              });
            });
          });
        });
      });
    });
    });
  }

  public void StartTheFourthStage(){
    puzzle3Control.SetActive(false);
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    puzzle3VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    soundM.PlayDoorOpenAudio();
    Vector3 puzzle3Pos = puzzle3.transform.position;
    puzzle3.transform.DOMoveZ(puzzle3Pos.z - 2f, 1).OnComplete(() => {
      //need audio
    thirdDoor.DOMove(thirdDoorOGPos.position, 2).OnComplete(() => {
      puzzle3.SetActive(false);
      thirdDoorOGPos.DOMoveZ(thirdDoorOGPos.position.z + 2f, 0).OnComplete(() => {
        thirdDoor.DOMoveZ(thirdDoor.position.z + 2f, 1).OnComplete(() => {
          Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
          Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
            soundM.PlayDoorOpenAudio();
            tree.SetActive(true);
            tree.transform.DOScale(treeScale, 1.5f);
            soundM.PlayAudioWaterOk();
            tree.transform.DOMove(treeSpawnPos.position, 1).OnComplete(() => {
             isRotate = true;
              transitionClouds.DOMove(trnasitionCloudsStart.position, 0);
              transitionClouds.DOMove(trnasitionCloudsEnd.position, 15f);
            });
         });
        });
     });
    });
   });
  }


  public void StartGame() 
  {
    //music
    audioM.currentAudioSource.Stop();
    audioM.index = 1;
    audioM.updateIndex();
    Debug.Log("1");
    isStart = true;
    TestStart();
  }

  public void RestartGame() {
    //music
    audioM.currentAudioSource.Stop();
    audioM.index = 0;
    audioM.updateIndex();

    SceneManager.LoadScene(0);
    startUI.SetActive(true);
    EndUI.SetActive(true);
  }

  private void Start() {
    puzzle1Control.SetActive(false);
    puzzle2Control.SetActive(false);
    puzzle3Control.SetActive(false);
    puzzle1.SetActive(false);
    puzzle2.SetActive(false);
    puzzle3.SetActive(false);
    puzzle1VFX.Stop();
    puzzle2VFX.Stop();
    puzzle3VFX.Stop();
  }
}


//trash
//public GameObject[] clouds;

/*public void start() { 
 * foreach (var cloud in clouds) {
  cloud.SetActive(false);
  Material m = cloud.GetComponent<Renderer>().material;
  Color c = m.color;
  c.a = 0;
  m.color = c;
}*/
/*public IEnumerator ShowCloud() {
  foreach(var cloud in clouds) {
    cloud.SetActive(true);
  }
  float a = 0;
  while (a <= 1) {
    Debug.Log(22);
    yield return new WaitForEndOfFrame();
    foreach (var cloud in clouds) {
      Material m = cloud.GetComponent<Renderer>().material;
      Color c = m.color;
      c.a = a;
      m.color = c;
      a += Time.deltaTime / 3;
    }
  }
}*/

//private float timer = 0;
//private int clickNum = 0;
//private bool isClick = false;

/*if (isClick == false) {
  isClick = true;
  timer = 0;
  clickNum = 0;
}
clickNum++;
}
if (isClick) {
timer += Time.deltaTime;
if (clickNum >= 3) {
  //var myNewCube = Instantiate(cubeToGenerate, new Vector3(-.3f, -.786f, .4f), Quaternion.identity);
  //myNewCube.transform.parent = gameObject.transform;
  //cube.SetActive(true);
  //warpAnimator.Play("cubeAnim");

  isClick = false;
  CanShake = false;
}
if (timer >= 1) {
  timer = 0;
  clickNum = 0;
  isClick = false;
}*/
