using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//PURPOSE: Manage all UI buttons/ elements in all scenes, includes MAINMENU, DEV PANEL, PAUSE SCREEN
//USAGE: Place this on an empty game object names UI  manaher as well as any buttons that are being controlled 
public class UIManager : MonoBehaviour
{
  
  
  //AUDIO MANAGEMENT
  public AudioManager AudioMan;
  public AudioSource BgMusic;
  public float BGTrackVol;


  //UI PANELS
  public GameObject devPanel;
  public AppleRotate MainGameScript; //script on IOC
  public GameObject creditsPanel; // team names and credits provided on here
  public GameObject creditsButton;
  public GameObject pauseButton;
  public GameObject soundPanel;

  //UI FANCY SHAMNCIES 
  [SerializeField] private CanvasGroup PauseGroup;
  [SerializeField] private bool fadeIn = false;
  [SerializeField] private bool fadeOut = false;

  //PAUSING
  public static bool isGamePaused = false; // is the screen paused already? Made static so it can be accessed within multiple scripts
  [SerializeField] GameObject pausePanel;



  void Start()
    {
        // Make sure we cant see the panels without activating it first
        devPanel.SetActive(false); 
        creditsPanel.SetActive(false);
        pausePanel.SetActive(false);
        soundPanel.SetActive(false);
        //BgMusic = AudioMan.GetComponent<AudioManager>().currentAudioSource;
  }

    // Update is called once per frame
    void Update()
    {
        BgMusic.volume = BGTrackVol;  

        if (Input.GetKey(KeyCode.C)) //activate dev panel 
          {
            devPanel.SetActive(true);
          }

    if (Input.GetKey(KeyCode.Escape)) // close the panel 
        {
          devPanel.SetActive(false);
          PauseGame();
        }
      else 
        {
          //ResumeGame();
        }

        if (Input.GetKey(KeyCode.R)) // restart game referencing actions in main game script
          {
            MainGameScript.RestartGame();
          }
    }
  
  private void FixedUpdate() {
    if (fadeIn) {
      if (PauseGroup.alpha < 1) {
        PauseGroup.alpha += Time.deltaTime;
        if (PauseGroup.alpha >= 1) {
          fadeIn = false;
        }
      }
    }
    if (fadeOut) {
      if (PauseGroup.alpha < 0) {
        PauseGroup.alpha -= Time.deltaTime;
        if (PauseGroup.alpha == 1) {
          fadeOut = false;
        }
      }
    }

  }
  //initializing this code here so we can keep everything UI related referenced on one script 

  //PANEL FUNCTIONS
  public void StartTheGame() {
     //start the game suing the conditions from the AppleRotate script
     MainGameScript.StartGame();
     creditsButton.SetActive(false);
  }  

    public void CreditsPanel()  {
      creditsPanel.SetActive(true);
    }
    public void BackToMain()  {
      //from the Pause screen
      MainGameScript.RestartGame();
      Time.timeScale = 1f;
  }
    public void ReturnButton(){
    // turn off anything that is on and has a return button
    fadeOut = true;
    creditsPanel.SetActive(false);
     
      pausePanel.SetActive(false);
      if (soundPanel.activeSelf) // checking if sound panel is on already
        {
          pausePanel.SetActive(true);
          soundPanel.SetActive(false);
         }
       Time.timeScale = 1f;
   

  }
  
//PLAY AND PAUSE
  public void PauseGame() {
       fadeIn = true; // Fade in panel
   pausePanel.SetActive(true);
      pauseButton.SetActive(false);
      Time.timeScale = 0f; // STOP THE CLOCK TIME HAS DIED!!!!
      isGamePaused = true;
     
  }
   public void ResumeGame() {
    pausePanel.SetActive(false);
    Time.timeScale = 1f; // HARK! TIME HAS RESUMED. WE HAVE RETURNED TO SUFFERING ;-;
    isGamePaused = false;
    fadeOut = true;
  }

//AUDIO 
  public void SoundOptions() {
      soundPanel.SetActive(true);
      pausePanel.SetActive(false);
  }
  public void SetVolume(float vol) {
    // function activated by slider
    BGTrackVol = vol;
  }



}
