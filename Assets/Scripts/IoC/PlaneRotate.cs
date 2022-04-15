using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//click and rotate puzzle piece in IoC with colider
//need using DG.Tweening;
//need ClickObject.cs
public class PlaneRotate : MonoBehaviour
{

  public Transform rotateTarget;
  public GameObject target;

  private float lerpDuration = 0.7f;
  public bool rotating;

  public SoundManager soundManager;

  private int clickCount = 1;
  private int puzzle2ClickCount = 1;
  private int puzzle3ClickCount = 1;
  private bool isRotate = false;
  public bool puzzle1;
  public bool puzzle2;
  public bool puzzle3;

  public void FixedUpdate() {
    if (puzzle2ClickCount > 4) {
      puzzle2ClickCount = 1;
    }
  }

  public void OnClick() {
    if (Cursor.visible) {
      //Do stuffCursor.lockState = CursorLockMode.Confined;
      Cursor.visible = false;
      Quaternion targetRotation = target.transform.rotation;

      if (isRotate) return;
      //clickCount++;
      Debug.Log(clickCount);
      Debug.Log(puzzle2ClickCount);
      Debug.Log(puzzle3ClickCount);
      soundManager.PlayAudioClick();
      soundManager.PlayAudioRotate();
      isRotate = true;

      if (puzzle1 == true) {

        // Rotate puzzle1 90 degrees when clicked the button
        rotateTarget.DOLocalRotate(new Vector3(0, 0, clickCount * 90), 1, RotateMode.Fast).OnComplete(() => {
          clickCount++;
          isRotate = false;
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
        });


      }

      if (puzzle2 == true) {
        StartCoroutine(Rotate90());
        //target.transform.Rotate(new Vector3(target.transform.rotation.x, target.transform.rotation.y, target.transform.rotation.z+90));
        // Rotate puzzle1 90 degrees when clicked the button
        //target.transform.DORotate(new Vector3(target.transform.rotation.x, target.transform.rotation.y, puzzle2ClickCount * 90), 1, RotateMode.Fast).OnComplete(() => {
        puzzle2ClickCount++;
        isRotate = false;
        //});
      }

      IEnumerator Rotate90() {
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = target.transform.rotation;
        Quaternion targetRotation = target.transform.rotation * Quaternion.Euler(1, 1, 90);
        while (timeElapsed < lerpDuration) {
          target.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
          timeElapsed += Time.deltaTime;
          yield return null;
        }
        target.transform.rotation = targetRotation;
        rotating = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      }

      if (puzzle3 == true) {
        StartCoroutine(Rotate90());
        //transform.Rotate(new Vector3(0, objectRotation.y+90, 0) * Time.deltaTime);
        // Rotate puzzle1 90 degrees when clicked the button
        //target.transform.DORotate(new Vector3(targetRotation.x, targetRotation.y + 90, targetRotation.z), 1, RotateMode.Fast).OnComplete(() => {
        puzzle3ClickCount++;
        isRotate = false;
        //});

      }
    }
  }

    


  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //if (clickCount == 4) {
      //clickCount = 0;
    //}

    
    }
}
