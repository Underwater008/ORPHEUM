using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class AppleRotate : MonoBehaviour {
  public float speed = 30;
  public Animator warpAnimator;
  public GameObject[] clouds;
  public GameObject apple;
  public GameObject cube;
  public GameObject cubeParent;
  //FirstStage
  public GameObject waterPipe;
  //SecondStage
  public GameObject waterPipe1;
  public GameObject waterPipe2;

  public GameObject tree;
  public Transform startButton;
  public Transform startButtonEndMovePos;
  public Transform secondStageCameraPos;
  public Transform cube4PosAfterClick;
  public Transform smallTreePos;



  private float timer = 0;
  private int clickNum = 0;
  private bool isClick = false;
  private bool CanShake = true;
  private bool isRotate = true;
  // Start is called before the first frame update
  void Start() {
    foreach (var cloud in clouds) {
      cloud.SetActive(false);
      Material m = cloud.GetComponent<Renderer>().material;
      Color c = m.color;
      c.a = 0;
      m.color = c;
    }
  }

  // Update is called once per frame
  void Update() {
    if (isRotate) {
      transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
    }


    if (Input.GetMouseButtonDown(0) && CanShake) {
      CameraShake.ins.Shake();
      if (isClick == false) {
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
        cube.SetActive(true);
        //warpAnimator.Play("cubeAnim");
        cube.GetComponent<showStartButton>().appRotate = this;
        isClick = false;
        CanShake = false;
      }
      if (timer >= 1) {
        timer = 0;
        clickNum = 0;
        isClick = false;
      }
    }
  }

  public IEnumerator ShowCloud() {
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
  }
  public void ShowTree() {
    tree.SetActive(true);
    tree.transform.DOLocalMove(smallTreePos.localPosition, 1).OnComplete(() => {

    });
    tree.transform.DOScale(1, 1);
  }
  public void StartTheSecondStage() {
    isRotate = false;
    apple.SetActive(false);
    Camera.main.transform.DOMove(secondStageCameraPos.position, 1).OnComplete(()=> {
      Animator anitor = cube.GetComponent<Animator>();
      Destroy(anitor);
      Transform cube4 = cube.transform.Find("Cube 4");
      cube4.DOMove(cube4PosAfterClick.position, 2);
      waterPipe.SetActive(true);
    });
    Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
    transform.DORotate(new Vector3(0, 0, 0), 1);
  }
  public void StartTheThirdStage() 
  {
    isRotate = false;
    apple.SetActive(false);
    Camera.main.transform.DOMove(secondStageCameraPos.position, 1).OnComplete(() => {
      Animator anitor = cube.GetComponent<Animator>();
      Destroy(anitor);
      waterPipe.SetActive(false);
      waterPipe1.SetActive(true);
      waterPipe2.SetActive(true);
    });
      Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1);
      transform.DORotate(new Vector3(0, 0, 0), 1);
    }
}
