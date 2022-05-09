using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class PuzzleSequenceControl : MonoBehaviour {

  public DragManager puzzle1DragManager;
  public Puzzle2DragManager puzzle2DragManager;
  public Puzzle3DragManager puzzle3DragManager;

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
  //public GameObject waterPipe1;
  //public GameObject waterPipe2;
  

  public GameObject tree;                 //the tree
  public GameObject DecayCube;
  public GameObject IOCCube;
  public Transform IOCOutsidePos;
  public Transform outsidePos;
  public Transform endCube;


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

  public VisualEffect puzzle1VFX;
  public VisualEffect puzzle2VFX;
  public VisualEffect puzzle3VFX;

  public ParticleSystem rockDebris;
  public ParticleSystem rockDebris2;
  public ParticleSystem rockDebris3;


  //public GameObject[] UIs;

  //private bool CanShake = true;
  private bool isRotate = true;
  public bool isStart = false;
  public bool isEndingSeuence = false;
  // Start is called before the first frame update
  void Start() {

  }


  // Update is called once per frame
  void Update() {
    if (isRotate) {
      transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }
  }

  private void ShowStartButton() {
    Cursor.visible = false;
    firstButton.gameObject.SetActive(true);
    firstButton.DOMove(startButtonEndMovePos.position, 1).OnComplete(() => {
      Cursor.visible = true;
    });
    //ShowTree();
  }

  //public void ShowTree() {
    
  //}

  //When we show the first puzzle in IoC
  public void StartTheFirstStage() {
    GameManager.Instance.isGameStart = false;
    //Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    Debug.Log("3");
    isRotate = false;
    isStart = false;
    //apple.SetActive(false);
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
    Camera.main.transform.DOMove(new Vector3(0, 0, -18.5f), 1).OnComplete(() => {    //move to look at puzzle
      rockDebris.Play();
      soundM.PlayDoorOpenAudio();
      //rockDebris.Play();
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z - 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z - 2f, 1).OnComplete(() => {
        puzzle1Control.SetActive(true);
        puzzle1.SetActive(true);
        puzzle1DragManager.enabled = true;
        firstDoor.DOMove(firstDoorOpenPos.position, 2).OnComplete(() => {
          GameManager.Instance.isGameStart = true;//open door
          Cursor.visible = true;
          rockDebris.Stop();
          Debug.Log("look at puzzle");
        });
      });
    });

    transform.DORotate(new Vector3(0, 0, 0), 1); //put cube at 0
  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() {
    GameManager.Instance.isGameStart = false;
    puzzle1VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    soundM.PlayDoorOpenAudio();
    //soundM.PlayDoorOpenAudio();
    Cursor.visible = false;
    puzzle1Control.SetActive(false);
    puzzle1DragManager.enabled = false;
    firstDoor.DOMove(firstDoorOGPos.position, 2).OnComplete(() => {
    firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z + 2f, 0);
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle2");
      firstDoor.DOMoveZ(firstDoor.position.z + 2f, 1).OnComplete(() => {
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(()=> {
        //tree.SetActive(true);
        //tree.transform.DOScale(0.5f, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z - 2f, 0);
            Camera.main.transform.DOMove(cameraPuzzleView.position, 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(()=> {
              rockDebris2.Play();
              soundM.PlayDoorOpenAudio();
              secondDoor.DOMoveZ(secondDoor.position.z - 2f, 1).OnComplete(() => {
                puzzle2.SetActive(true);
                puzzle2DragManager.enabled = true;
                puzzle2Control.SetActive(true);
                secondDoor.DOMove(secondDoorOpenPos.position, 2).OnComplete(() => {             //open door
                  GameManager.Instance.isGameStart = true;
                  Cursor.visible = true;
                  rockDebris2.Stop();
                  Debug.Log("puzzle 2 start");
                //});
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
    puzzle2VFX.Play();
    soundM.PlayPuzzleCompleteChime();
    //rockDebris3.Play();
    soundM.PlayDoorOpenAudio();
    Cursor.visible = false;
    puzzle2Control.SetActive(false);
    puzzle2DragManager.enabled = false;
    secondDoor.DOMove(secondDoorOGPos.position, 2).OnComplete(() => {
      secondDoorOGPos.DOMoveZ(secondDoorOGPos.position.z + 2f, 0);
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle3");
      secondDoor.DOMoveZ(secondDoor.position.z + 2f, 1).OnComplete(() => {
        Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
        Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
          //tree.SetActive(true);
          //tree.transform.DOScale(0.5f, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 180f, 0), 2f).OnComplete(() => {
            thirdDoorOGPos.DOMoveZ(thirdDoorOGPos.position.z - 2f, 0);
            Camera.main.transform.DOMove(cameraPuzzleView.position, 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => {
              rockDebris3.Play();
              soundM.PlayDoorOpenAudio();
              thirdDoor.DOMoveZ(thirdDoor.position.z - 2f, 1).OnComplete(() => {
                puzzle3.SetActive(true);
                puzzle3DragManager.enabled = true;
                puzzle3Control.SetActive(true);
                thirdDoor.DOMove(thirdDoorOpenPos.position, 2).OnComplete(() => {             //open door
                  GameManager.Instance.isGameStart = true;
                  Cursor.visible = true;
                  rockDebris3.Stop();
                  Debug.Log("puzzle 3 start");
                  //});
                });
              });
            });
          });
        });
      });
    });
  }

  public void StartTheForthStage() {
    soundM.PlayPuzzleCompleteChime();
    soundM.PlayDoorOpenAudio();
    puzzle3VFX.Play();
    EndingGameEvt.Instance.EndGameAction();
  }

  public void StartGame() 
  {
    isStart = true;
    if (isStart) {

      startUI.SetActive(false);
      EndingUI.SetActive(false);
      titleUI.SetActive(false);
      Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(()=>{
        //CameraShake.ins.Shake();
        ShowStartButton();
      });
      //cubeBase.GetComponent<showStartButton>().appRotate = this;
    }
  }

  public void StartEndingSequence() {
    
    isEndingSeuence = true;
    //music
    audioM.currentAudioSource.Stop();
    audioM.index = 3;
    audioM.updateIndex();

    if (isEndingSeuence) {

      startUI.SetActive(false);
      EndingUI.SetActive(false);
      DecayUI.SetActive(false);
      titleUI.SetActive(false);
      DecayCube.SetActive(false);
      endCube.DOMove(new Vector3(0f, 0f, 0f), 0f).OnComplete(() => {
        Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(() => {
         
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
