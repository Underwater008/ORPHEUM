using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class DecayPuzzleControl : MonoBehaviour {

  //music
  public AudioManager audioM;

  public float speed = 30;
  //public Animator warpAnimator;
  public GameObject theGarden;

  //public GameObject apple;
  //public GameObject cubeBase;
  //public GameObject cubeParent;
  public GameObject startUI;
  public GameObject EndingUI;
  public GameObject titleUI;
  public GameObject DecayUI;
  //FirstStage
  public GameObject puzzle1;
  public GameObject puzzle1Control;
  //SecondStage
  public GameObject puzzle2;
  public GameObject puzzle2Control;
  public GameObject puzzle3;
  public GameObject puzzle3Control;

  public VisualEffect puzzle1VFX;
  public VisualEffect puzzle2VFX;
  public VisualEffect puzzle3VFX;

  //public GameObject waterPipe1;
  //public GameObject waterPipe2;


  public GameObject tree;                 //the tree
  public GameObject iOCCube;
  public GameObject endFirstBUtton;
  public Transform outsidePos;
  public Transform DecayCube;

  public GameObject iOCFirstButton;
  public GameObject firstBUtton;
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
  public Transform smallTreePos;

  //public GameObject[] UIs;


  //private bool CanShake = true;
  private bool isRotate = true;
  public bool isStart = false;
  public bool isDecay = false;
  // Start is called before the first frame update
  void Start() {

  }


  // Update is called once per frame
  void Update() {
    if (isRotate) {
      transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }
  }

  public void ShowStartButton() {
    firstButton.gameObject.SetActive(true);
    firstButton.DOMove(startButtonEndMovePos.position, 1);
    //ShowTree();
  }

  //public void ShowTree() {

  //}

  //When we show the first puzzle in IoC
  public void StartTheFirstStage() {
    //Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    isRotate = false;
    //apple.SetActive(false);
    //puzzle1Control.SetActive(true)
    Camera.main.transform.DOMove(cameraPuzzleView.position, 1).OnComplete(() => {
      //Animator anitor = cubeBase.GetComponent<Animator>();
      //Destroy(anitor)
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z - 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z - 2f, 1).OnComplete(() => {
        firstDoor.DOMove(firstDoorOpenPos.position, 2).OnComplete(() => {
          //Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          firstBUtton.SetActive(true);
        puzzle1.SetActive(true);
        puzzle1.GetComponent<DecayCube>().SaveChildrenPositions();
        puzzle1.GetComponent<DecayCube>().EnableAllChildren();
        Debug.Log("finish 1");
      });
      });
    });
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
    transform.DORotate(new Vector3(-90, 0, 90), 1);

  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() {
    puzzle1Control.SetActive(false);
    //Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    firstDoor.DOMove(firstDoorOGPos.position, 2f).OnComplete(() => {
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle2");
      puzzle1.SetActive(false);
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z + 2f, 0f);
      firstDoor.DOMoveZ(firstDoor.position.z + 2f, 1f).OnComplete(() => {
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
        Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
          tree.SetActive(true);
          tree.transform.DOLocalMove(smallTreePos.localPosition, 1);
          tree.transform.DOScale(0.5f, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(-90, 0, 180f), 2f).OnComplete(() => {
            secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z - 2f, 0);
            Camera.main.transform.DOMove(new Vector3(0, 0, -18.5f), 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
              secondDoor.DOMoveZ(secondDoor.position.z - 2f, 1).OnComplete(() => {
                puzzle2.SetActive(true);
                puzzle2Control.SetActive(true);
                puzzle2.GetComponent<DecayCube>().SaveChildrenPositions();
                puzzle2.GetComponent<DecayCube>().EnableAllChildren();
                secondDoor.DOMove(secondDoorOpenPos.position, 2).OnComplete(() => {             //open door
                  Debug.Log("puzzle 2 start");
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
    puzzle2Control.SetActive(false);
    //Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    //puzzle2VFX.Play();
    secondDoor.DOMove(secondDoorOGPos.position, 2).OnComplete(() => {
      //puzzle2.SetActive(false);
      secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z + 2f, 0);
      secondDoor.DOMoveZ(secondDoor.position.z + 2f, 1).OnComplete(() => {
        Debug.Log("puzzle3");
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
        Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => { //look at cube
          //flower.SetActive(true);
          //flower.transform.DOMove(grassSpawnPos.position, 1).OnComplete(() => {
            theGarden.transform.DORotate(new Vector3(-90, 0, 270), 2f).OnComplete(() => {
              Debug.Log("look at puzzle 3");
              Camera.main.transform.DOMove(cameraPuzzleView.position, 1); //look at puzzle
              Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
                thirdDoor.DOMoveZ(thirdDoor.position.z - 2f, 1).OnComplete(() => {
                  Cursor.lockState = CursorLockMode.None;
                  Cursor.visible = true;
                  puzzle3.SetActive(true);
                  puzzle3Control.SetActive(true);
                  puzzle3.GetComponent<DecayCube>().SaveChildrenPositions();
                  puzzle3.GetComponent<DecayCube>().EnableAllChildren();
                  thirdDoorOGPos.DOMoveZ(thirdDoorOGPos.position.z - 2f, 0);
                  thirdDoor.DOMove(thirdDoorOpenPos.position, 2f);
                });
              });
            });
          });
        });
      });
  }

  public void StartTheForthStage() {
    puzzle3VFX.Play();
    puzzle3.SetActive(false);
    puzzle3Control.SetActive(false);
    thirdDoor.DOMove(thirdDoorOGPos.position, 2).OnComplete(() => {
      thirdDoorOGPos.DOMoveZ(thirdDoorOGPos.position.z + 2f, 2).OnComplete(() => {
        thirdDoor.DOMoveZ(thirdDoor.position.z + 2f, 3).OnComplete(() => {
          Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
          Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {

          });
        });
      });
    });
  }

  public void StartGame() {
    isStart = true;
    if (isStart) {
      startUI.SetActive(false);
      EndingUI.SetActive(false);
      titleUI.SetActive(false);
      Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(() => {
        //CameraShake.ins.Shake();
        ShowStartButton();
      });
      //cubeBase.GetComponent<showStartButton>().appRotate = this;
    }
  }

  public void StartDecay() {
    //music
    audioM.index = 2;

    isDecay = true;
    if (isDecay) {
      startUI.SetActive(false);
      EndingUI.SetActive(false);
      titleUI.SetActive(false);
      DecayUI.SetActive(false);
      iOCCube.transform.DOMove(outsidePos.position, 2).OnComplete(() => {
        iOCFirstButton.SetActive(false);
        endFirstBUtton.SetActive(false);

      });
      DecayCube.DOMove(new Vector3(0f, 0f, 0f), 4f).OnComplete(() => {
        Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(() => {

          //CameraShake.ins.Shake();
          ShowStartButton();
        });
      });
    }
  }

  public void RestartGame() {
    SceneManager.LoadScene(0);
  }
}