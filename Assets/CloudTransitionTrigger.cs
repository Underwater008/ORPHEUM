using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTransitionTrigger : MonoBehaviour
{

  public GameObject IOCCube;
  public DecayPuzzleControl decayPuzzleControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter(Collider other) {

      if (other.gameObject == IOCCube) {
        decayPuzzleControl.StartDecay();
      }

  }
}
