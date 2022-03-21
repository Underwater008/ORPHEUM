using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AppleRotate : MonoBehaviour {
  public float speed = 30;
  //public Animator warpAnimator;
 
  //public GameObject apple;
  public GameObject cubeBase;
  //public GameObject cubeParent;
  public GameObject startUI;    
  //FirstStage
  public GameObject puzzle1;
  //SecondStage
  public GameObject puzzle2;
  public GameObject puzzle3;
  //public GameObject waterPipe1;
  //public GameObject waterPipe2;
  

  public GameObject tree;                 //the tree
  public Transform firstButton;           //the first button we press on the cube
  public Transform startButtonEndMovePos; //the position first button move to when activated
  public Transform cameraPlayPos;         //the position camera move to look at the puzzle
  public Transform cameraOriginalPos;     //the position camera move to look at the cube
  public Transform firstDoor;
  public Transform firstDoorOpenPos;
  public Transform smallTreePos;

  public GameObject[] UIs;


  private bool CanShake = true;
  private bool isRotate = true;
  public bool isStart = false;
  // Start is called before the first frame update
  void Start() {

  }


  // Update is called once per frame
  void Update() {
    if (isRotate) {
      transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }


    if (isStart && CanShake) {
      startUI.SetActive(false);
      CameraShake.ins.Shake();
      ShowStartButton();
      //cubeBase.GetComponent<showStartButton>().appRotate = this;
      CanShake = false;

    }
  }

  public void ShowStartButton() {
    firstButton.gameObject.SetActive(true);
    firstButton.DOMove(startButtonEndMovePos.position, 1);
    //ShowTree();
  }

  public void ShowTree() {
    tree.SetActive(true);
    //tree.transform.DOLocalMove(smallTreePos.localPosition, 1).OnComplete(() => {});
    tree.transform.DOScale(0.5f, 1);
  }

  //When we show the first puzzle in IoC
  public void StartTheFirstStage() {   
    isRotate = false;
    //apple.SetActive(false);
    
    Camera.main.transform.DOMove(cameraPlayPos.position, 1).OnComplete(()=> {
      //Animator anitor = cubeBase.GetComponent<Animator>();
      //Destroy(anitor)
      firstDoor.DOMove(firstDoorOpenPos.position, 2).OnComplete(()=> {
        //UIs.SetActive(true);
      });
    });
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
    transform.DORotate(new Vector3(0, 0, 0), 1);
  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() 
  {
    Debug.Log("puzzle2");
    puzzle2.SetActive(true);
    puzzle1.SetActive(false);
    }

  public void StartTheThirdStage() {
    Debug.Log("puzzle3");
    puzzle3.SetActive(true);
    puzzle2.SetActive(false);
  }

  public void StartGame() 
  {
    isStart = true;
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
