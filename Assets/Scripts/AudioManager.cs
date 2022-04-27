using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public List<AudioSource> BGList = new List<AudioSource>();

    public AudioSource currentAudioSource;

    public int index = 0;

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    updateIndex();
    }

   void updateIndex() {
      currentAudioSource = BGList[index];
       if (!currentAudioSource.isPlaying) {
          currentAudioSource.Play();
    }
  }
}