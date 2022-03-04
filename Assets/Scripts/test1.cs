using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test1 : MonoBehaviour
{
  public GameObject obj1;
  public GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
    var sequ = DOTween.Sequence();
    sequ.Append(obj1.transform.DOLocalMoveZ(3f, 1));
    sequ.Append(obj2.transform.DOLocalMoveZ(2f, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
