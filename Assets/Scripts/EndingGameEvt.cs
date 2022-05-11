using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndingGameEvt : MonoBehaviour
{
    public static EndingGameEvt Instance{private set;get;}
    public PuzzleSequenceControl puzzleSequenceControl;

    public UIManager UIManager;

    public GameObject AppleLowPoly;

    public GameObject endingDissovle;

    void Awake() {
        Instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzleSequenceControl = GameObject.FindObjectOfType<PuzzleSequenceControl>();
        UIManager=GameObject.FindObjectOfType<UIManager>();
    }

    public void EndGameAction(){
    Cursor.visible=false;
   puzzleSequenceControl.thirdDoor.DOMove(puzzleSequenceControl.thirdDoorOGPos.position,2).OnComplete(()=>{

      puzzleSequenceControl.thirdDoor.DOMoveZ(puzzleSequenceControl.thirdDoorOGPos.position.z+2f,1f).OnComplete(()=>{
    
          
          // this.transform.localScale =Vector3.zero;
         Camera.main.transform.DOMove(puzzleSequenceControl.cameraOriginalPos.position, 1).OnComplete(()=>{

          endingDissovle.gameObject.SetActive(true);
           AppleLowPoly.transform.DOMove(new Vector3(0, 0, 0), 0);
           //AppleLowPoly.transform.DOLocalMoveY(15f,1f).OnComplete(()=>{
           puzzleSequenceControl.gameObject.SetActive(false);
            AppleLowPoly.transform.DORotate(new Vector3(0,360,0),5f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);

            UIManager.creditsPanel.gameObject.SetActive(true);

          //});
          endingDissovle.transform.SetParent(AppleLowPoly.transform);
          // this.transform.DOScale(Vector3.zero,2f);
         });



      });



    });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
