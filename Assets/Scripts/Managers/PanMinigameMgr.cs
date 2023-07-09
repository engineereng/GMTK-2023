using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMinigameMgr : MonoBehaviour
{
    public GameObject TutorialOverlay;
    public GameObject WinOverlay;
    [SerializeField] private float tutorialDuration;

    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.enabled = false;
        ShowTutorial();
        Invoke(nameof(HideTutorial), tutorialDuration);
    }

    void HideTutorial()
    {
        TutorialOverlay.SetActive(false);
        Invoke(nameof(StartTimer), 0.8f);
    }

    void StartTimer()
    {
        timer.enabled = true;
    }

    void ShowTutorial()
    {
        WinOverlay.SetActive(false);
        TutorialOverlay.SetActive(true);
    }

    void StartGame()
    {

    }

    public void Win()
    {
        WinOverlay.SetActive(true);
        GameMgr.Instance.waitAndLoadNextScene(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
