using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class AppleRotate : MonoBehaviour {
  public float speed = 30;
  //public Animator warpAnimator;
  public GameObject theGarden;
 
  //public GameObject apple;
  public GameObject cubeBase;
  //public GameObject cubeParent;
  public GameObject startUI;
  public GameObject EndUI;
  public GameObject titleUI;
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

  public GameObject VFXObj;
  public VisualEffect puzzle1VFX;
  public VisualEffect puzzle2VFX;
  public VisualEffect puzzle3VFX;

  public ParticleSystem rockDebris;

  public float treeScale;

  public GameObject[] UIs;

  //private bool CanShake = true;
  private bool isRotate = true;
  public bool isStart = false;
  // Start is called before the first frame update
  void TestStart() {
    if (isStart) {
      startUI.SetActive(false);
      EndUI.SetActive(false);
      titleUI.SetActive(false);

      Camera.main.transform.DORotate(new Vector3 (35, 0,0), 1);
      Camera.main.transform.DOMove(cameraPlayPos.position, 2).OnComplete(() => {   //go closer to cube
                                                                                   //CameraShake.ins.Shake();
        //isStart = false;
        ShowStartButton();
      });
      //CanShake = false;
      //cubeBase.GetComponent<showStartButton>().appRotate = this;
    }
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

  public void StartTheFirstStage() {
    Debug.Log("3");
    isRotate = false;
    isStart = false;
    //apple.SetActive(false);
    puzzle1Control.SetActive(true);
    puzzle1.SetActive(true);

    Camera.main.transform.DORotate(new Vector3 (0,0,0), 1);

    Camera.main.transform.DOMove(new Vector3 (0,0, -18.5f), 1).OnComplete(()=> {    //move to look at puzzle
      rockDebris.Play();
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z - 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z - 2f, 1).OnComplete(() => {
        puzzle1Control.SetActive(true);
        puzzle1.SetActive(true);
        firstDoor.DOMove(firstDoorOpenPos.position, 2).OnComplete(()=> {             //open door
          rockDebris.Stop();
          Debug.Log("look at puzzle");
      });
      });
    });

    transform.DORotate(new Vector3(0,0,0), 1); //put cube at 0
  }

  //When we shou the second puzzle in IoC
  public void StartTheSecondStage() {
    puzzle1VFX.Play();
    firstDoor.DOMove(firstDoorOGPos.position, 2).OnComplete(() => {
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle2");
      puzzle1.SetActive(false);
      puzzle1Control.SetActive(false);
      firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z + 2f, 0);
      firstDoor.DOMoveZ(firstDoor.position.z + 2f, 1).OnComplete(() => {
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(()=> {
        grass.SetActive(true);
        grass.transform.DOMove(grassSpawnPos.position, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 90f, 0), 2f).OnComplete(() => {
            Camera.main.transform.DOMove(new Vector3 (0,0,-18.5f), 1);
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(()=> {
              secondDoor.DOMoveZ(secondDoor.position.z - 2f, 1).OnComplete(() => {
                Debug.Log("puzzle 2 start");
                puzzle2.SetActive(true);
                puzzle2Control.SetActive(true);
                secondDoor.DOMove(secondDoorOpenPos.position, 2f); //open second door
            });
          });
        });  
      });
    });
    });
    });
  }

  public void StartTheThirdStage() {
    puzzle2VFX.Play();
    firstDoorOGPos.DOMoveZ(firstDoorOGPos.position.z - 2f, 0);
      secondDoor.DOMove(secondDoorOGPos.position, 2).OnComplete(() => {
        secondDoor.DOMoveZ(secondDoor.position.z + 2f, 1).OnComplete(() => {
          Debug.Log("puzzle3");
      puzzle2.SetActive(false);
      puzzle2Control.SetActive(false);
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(()=> { //look at cube
        flower.SetActive(true);
        flower.transform.DOMove(grassSpawnPos.position, 1).OnComplete(() => {
          theGarden.transform.DORotate(new Vector3(0, 180f, 0), 2f).OnComplete(() => {
            Debug.Log("look at puzzle 3");
            puzzle3.SetActive(true);
            puzzle3Control.SetActive(true);
            Camera.main.transform.DOMove(new Vector3(0, 0, -18.5f), 1); //look at puzzle
            Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(()=> {
              thirdDoor.DOMove(thirdDoorOpenPos.position, 2f);
            });
          });
        });
      });
    });
    });
  }

  public void StartTheFourthStage(){
    puzzle3VFX.Play();
    thirdDoor.DOMove(thirdDoorOGPos.position, 2).OnComplete(() => {
      // Hide the first puzzle and show the second puzzle
      Debug.Log("puzzle3");
      puzzle3.SetActive(false);
      puzzle3Control.SetActive(false);
      Camera.main.transform.DORotate(new Vector3(20, 0, 0), 1);});
      Camera.main.transform.DOMove(cameraOriginalPos.position, 1).OnComplete(() => {
        tree.transform.DOLocalMove(grassSpawnPos.localPosition, 1).OnComplete(() => { });
        tree.transform.DOScale(1f, 1).OnComplete(() => {
          ShowStartButton();
        });
        
      });
  }

  public void StartGame() 
  {
    Debug.Log("1");
    isStart = true;
    TestStart();
  }

  public void RestartGame() {
    SceneManager.LoadScene(0);
    startUI.SetActive(true);
    EndUI.SetActive(true);
  }

  private void Start() {
    puzzle1Control.SetActive(false);
    puzzle1.SetActive(false);
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
