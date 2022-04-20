using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DecayPuzzleControl : MonoBehaviour {
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
  //public GameObject waterPipe1;
  //public GameObject waterPipe2;


  public GameObject tree;                 //the tree
  public GameObject iOCCube;
  public Transform outsidePos;
  public Transform DecayCube;


  public GameObject iOCFirstButton;
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
    isRotate = false;
    //apple.SetActive(false);
    //puzzle1Control.SetActive(true);
    Camera.main.transform.DOMove(cameraPuzzleView.position, 1).OnComplete(() => {
      //Animator anitor = cubeBase.GetComponent<Animator>();
      //Destroy(anitor)
      firstDoor.DOLocalMoveZ(-7f, 2).OnComplete(() => {
        puzzle1.SetActive(true);
        firstDoor.DOLocalMoveX(-10f, 2).OnComplete(() => {
          //UIs.SetActive(true);
        });
      });
    });
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
    transform.DORotate(new Vector3(0, 0, 0), 1);
  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() {
    firstDoor.DOLocalMoveZ(.46f, 2).OnComplete(() => {
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle2");
      puzzle1.SetActive(false);
      puzzle1Control.SetActive(false);
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
        tree.SetActive(true);
        tree.transform.DOLocalMove(smallTreePos.localPosition, 1).OnComplete(() => { });
        tree.transform.DOScale(0.5f, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            puzzle2.SetActive(true);
            puzzle2Control.SetActive(true);
            Camera.main.transform.DOMove(cameraPlayPos.position, 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
              secondDoor.transform.DOLocalMove(new Vector3(0.5f, 0, -0.5f), 2f);
            });
          });
        });
      });
    });

  }

  public void StartTheThirdStage() {
    Debug.Log("puzzle3");
    puzzle3.SetActive(true);
    puzzle2.SetActive(false);
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
    isDecay = true;
    if (isDecay) {
      startUI.SetActive(false);
      EndingUI.SetActive(false);
      titleUI.SetActive(false);
      DecayUI.SetActive(false);
      iOCCube.transform.DOMove(outsidePos.position, 2).OnComplete(() => {
        iOCFirstButton.SetActive(false);
      });
      DecayCube.DOMove(new Vector3(-90f, 0f, -90f), 4f).OnComplete(() => {
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