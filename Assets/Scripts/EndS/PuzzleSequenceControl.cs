using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuzzleSequenceControl : MonoBehaviour {
  public float speed = 30;
  //public Animator warpAnimator;
  public GameObject theGarden;
 
  //public GameObject apple;
  //public GameObject cubeBase;
  //public GameObject cubeParent;
  public GameObject startUI;
  public GameObject EndingUI;
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
    Camera.main.transform.DOMove(cameraPuzzleView.position, 1).OnComplete(()=> {
      //Animator anitor = cubeBase.GetComponent<Animator>();
      //Destroy(anitor)
      firstDoor.DOLocalMoveZ(-7f, 2).OnComplete(()=> {
        puzzle1.SetActive(true);
        firstDoor.DOLocalMoveX(-10f, 2).OnComplete(() => {
          //UIs.SetActive(true);
        });
      });
    });
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
    transform.DORotate(new Vector3(-90, 0, 90), 1);
  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() 
  {
    firstDoor.DOLocalMoveZ(.46f, 2).OnComplete(() => {
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle2");
      puzzle1.SetActive(false);
      puzzle1Control.SetActive(false);
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(()=> {
        tree.SetActive(true);
        tree.transform.DOLocalMove(smallTreePos.localPosition, 1).OnComplete(() => {});
        tree.transform.DOScale(0.5f, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            puzzle2.SetActive(true);
            puzzle2Control.SetActive(true);
            Camera.main.transform.DOMove(cameraPlayPos.position, 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(()=> {
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

  public void StartGame() 
  {
    isStart = true;
    if (isStart) {
      startUI.SetActive(false);
      EndingUI.SetActive(false);
      Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(()=>{
        //CameraShake.ins.Shake();
        ShowStartButton();
      });
      //cubeBase.GetComponent<showStartButton>().appRotate = this;
    }
  }

  public void StartEndingSequence() {
    isEndingSeuence = true;
    if (isEndingSeuence) {
      startUI.SetActive(false);
      EndingUI.SetActive(false);
      iOCCube.transform.DOMove(outsidePos.position, 2).OnComplete(() => {
        iOCFirstButton.SetActive(false);
      });
      endCube.DOMove(new Vector3(0f, 0f, 0f), 4f).OnComplete(() => {
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
