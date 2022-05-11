using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class DecayPuzzleControl : MonoBehaviour {

  //Transition
  public Transform transitionClouds;
  public Transform trnasitionCloudsStart;
  public Transform trnasitionCloudsEnd;
  public GameObject CloudTrigger;

  //music
  public AudioManager audioM;
  public SoundManager soundM;

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

  public ParticleSystem rockDebris;
  public ParticleSystem rockDebris2;
  public ParticleSystem rockDebris3;


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

  public PuzzleSequenceControl puzzleSequenceControl;
  // Start is called before the first frame update
  void Start() {
  }


  // Update is called once per frame
  void Update() {
    if (isRotate) {
      theGarden.transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }
  }

  private void ShowStartButton() {
    Camera.main.transform.DOMove(cameraPlayPos.position, 1);
    firstButton.gameObject.SetActive(true);
    firstButton.DOMove(startButtonEndMovePos.position, 1).OnComplete(() => {
      Cursor.visible = true;
      GameManager.Instance.isGameStart = true;
      transitionClouds.DOMove(trnasitionCloudsStart.position, 0);
      CloudTrigger.GetComponent<BoxCollider>().enabled = true;
    });
  }

  //When we show the first puzzle in IoC
  public void StartTheFirstStage() {
    GameManager.Instance.isGameStart = false;
    Cursor.visible = false;
    isRotate = false;
    Camera.main.transform.DOMove(cameraPuzzleView.position, 1).OnComplete(() => {
      //GameManager.Instance.isGameStart = false;
      rockDebris.Play();
      soundM.PlayDoorOpenAudio();
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z - 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z - 2f, 1).OnComplete(() => {
        puzzle1.SetActive(true);
        soundM.PlayDoorOpenAudio();
        firstDoor.DOMove(firstDoorOpenPos.position, 2).OnComplete(() => {
          rockDebris.Stop();
          //Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
          //firstBUtton.GetComponent<BoxCollider>().enabled = false;
          GameManager.Instance.isGameStart = true;
          Debug.Log(GameManager.Instance.isGameStart);
        });
      });
    });
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
        puzzle1.GetComponent<DecayCube>().SaveChildrenPositions();
        puzzle1.GetComponent<DecayCube>().EnableAllChildren();
    });
    theGarden.transform.DORotate(new Vector3(0, 0, 0), 1);
    
    //Debug.Log(GameManager.Instance.isGameStart);

  }

  //When we show the second puzzle in IoC
  public void StartTheSecondStage() {
    GameManager.Instance.isGameStart = false;
    Cursor.visible = false;
    puzzle1VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    puzzle1Control.SetActive(false);
    Vector3 puzzle1Pos = puzzle1.transform.position;
    puzzle1.transform.DOMove(puzzle1Pos, 2).OnComplete(() => {
      soundM.PlayDoorOpenAudio();
      puzzle1.transform.DOMoveZ(puzzle1Pos.z - 1f, 1).OnComplete(() => {
      soundM.PlayDoorOpenAudio();
      firstDoor.DOMove(firstDoorOGPos.position, 2f).OnComplete(() => {
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle2");
      puzzle1.SetActive(false);
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z + 2f, 0f);
      firstDoor.DOMoveZ(firstDoor.position.z + 2f, 1f).OnComplete(() => {
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
        Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
          BlendManager.Instance.ChangeTheGrassToDecay();
          theGarden.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z - 2f, 0);
            Camera.main.transform.DOMove(new Vector3(0, 0, -18.5f), 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
              rockDebris2.Play();
              soundM.PlayDoorOpenAudio();
              secondDoor.DOMoveZ(secondDoor.position.z - 2f, 1).OnComplete(() => {
                Cursor.visible = true;
                puzzle2.SetActive(true);
                puzzle2Control.SetActive(true);
                puzzle2.GetComponent<DecayCube>().SaveChildrenPositions();
                puzzle2.GetComponent<DecayCube>().EnableAllChildren();
                soundM.PlayDoorOpenAudio();
                secondDoor.DOMove(secondDoorOpenPos.position, 2).OnComplete(() => {             //open door
                  rockDebris2.Stop();
                  GameManager.Instance.isGameStart = true;
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
    GameManager.Instance.isGameStart = false;
    Cursor.visible = false;
    puzzle2VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    puzzle2Control.SetActive(false);
    Vector3 puzzle2Pos = puzzle2.transform.position;
    puzzle2.transform.DOMove(puzzle2Pos, 2).OnComplete(() => {
      soundM.PlayDoorOpenAudio();
      puzzle2.transform.DOMoveZ(puzzle2Pos.z - 1f, 1).OnComplete(() => {
        soundM.PlayDoorOpenAudio();
        secondDoor.DOMove(secondDoorOGPos.position, 2).OnComplete(() => {
          puzzle2.SetActive(false);
      secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z + 2f, 0);
      secondDoor.DOMoveZ(secondDoor.position.z + 2f, 1).OnComplete(() => {
        Debug.Log("puzzle3");
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
        Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => { //look at cube
          BlendManager.Instance.ChangeTheFlowerToDecay();
          theGarden.transform.DORotate(new Vector3(0, 180f, 0), 2f, RotateMode.Fast).OnComplete(() => {
              Debug.Log("look at puzzle 3");
              Camera.main.transform.DOMove(cameraPuzzleView.position, 1); //look at puzzle
              Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
                thirdDoorOGPos.DOMoveZ(thirdDoorOGPos.position.z - 2f, 0);
                rockDebris3.Play();
                soundM.PlayDoorOpenAudio();
                thirdDoor.DOMoveZ(thirdDoor.position.z - 2f, 1).OnComplete(() => {
                  GameManager.Instance.isGameStart = true;
                  Cursor.visible = true;
                  puzzle3.SetActive(true);
                  puzzle3Control.SetActive(true);
                  puzzle3.GetComponent<DecayCube>().SaveChildrenPositions();
                  puzzle3.GetComponent<DecayCube>().EnableAllChildren();
                  thirdDoor.DOMove(thirdDoorOpenPos.position, 2f).OnComplete(() => {
                    rockDebris3.Stop();
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

  public void StartTheForthStage() {
    GameManager.Instance.isGameStart = false;
    puzzle3Control.SetActive(false);
    puzzle3VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    Vector3 puzzle3Pos = puzzle3.transform.position;
    puzzle3.transform.DOMove(puzzle3Pos, 2).OnComplete(() => {
      soundM.PlayDoorOpenAudio();
      puzzle3.transform.DOMoveZ(puzzle3Pos.z - 1f, 1).OnComplete(() => {
        soundM.PlayDoorOpenAudio();
        thirdDoor.DOMove(thirdDoorOGPos.position, 2).OnComplete(() => {
      puzzle3.SetActive(false);
      thirdDoorOGPos.DOMoveZ(thirdDoorOGPos.position.z + 2f, 0).OnComplete(() => {
        thirdDoor.DOMoveZ(thirdDoor.position.z + 2f, 1).OnComplete(() => {
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1).OnComplete(() => {
          //soundM.PlayDoorOpenAudio();

        });
          BlendManager.Instance.ChangeTheTreeToDecay();
          Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
            isRotate = true;
            transitionClouds.DOMove(trnasitionCloudsStart.position, 0);
            CloudTrigger.gameObject.GetComponent<BoxCollider>().enabled = true;
            transitionClouds.DOMove(trnasitionCloudsEnd.position, 15f);
          });
        });
        });
      });
      });
    });
  }


  public void StartDecay() {
    ChangeSky.Instance.ChangeColor(2);
    //music
    audioM.currentAudioSource.Stop();
    audioM.index = 2;
    audioM.updateIndex();
    isDecay = true;
    if (isDecay) {
      startUI.SetActive(false);
      EndingUI.SetActive(false);
      titleUI.SetActive(false);
      DecayUI.SetActive(false);
      iOCCube.SetActive(false);
        /*transform.DOMove(outsidePos.position, 2).OnComplete(() => {
        iOCFirstButton.SetActive(false);
        endFirstBUtton.SetActive(false);
      });*/
      DecayCube.DOMove(new Vector3(0f, 0f, 0f), 0f).OnComplete(() => {
        Camera.main.transform.DOMove(cameraOriginalPos.position, 2).OnComplete(() => {

          //CameraShake.ins.Shake();
          ShowStartButton();
        });
      });
    }
  }

  public void RestartGame() {
    audioM.currentAudioSource.Stop();
    audioM.index = 0;
    audioM.updateIndex();

    SceneManager.LoadScene(0);
  }
}