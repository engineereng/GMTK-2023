using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMinigameMgr : MonoBehaviour
{
    public GameObject TutorialOverlay;
    public GameObject WinOverlay;
    public GameObject[] DeathOverlays;
    [SerializeField] private PanSpriteController PanSpriteController;

    private ArrowManager ArrowManager;
    [Header("Gameplay")]
    [SerializeField] private float tutorialDuration;
    [SerializeField] private float promptedArrowsLeft;
    [SerializeField] private float delayBeforeTilt;
    [SerializeField] private float delayBeforeListeningForInput;
    [SerializeField] private float listenDuration;

    [SerializeField] private float minDelayBetweenPanMoves;
    [SerializeField] private float maxDelayBetweenPanMoves;

    public enum PanStates
    {
        Sizzling,
        Tilting,
        Listening,
        Neutral
    }
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        ArrowManager = GetComponent<ArrowManager>();
        timer.enabled = false;
        ShowTutorial();
        Invoke(nameof(HideTutorial), tutorialDuration);
    }

    void HideTutorial()
    {
        TutorialOverlay.SetActive(false);
        Invoke(nameof(StartTimer), 0.8f);
        StartGame();
    }

    void StartTimer()
    {
        timer.enabled = true;
    }

    void ShowTutorial()
    {
        WinOverlay.SetActive(false);
        foreach(GameObject overlay in DeathOverlays)
            overlay.SetActive(false);
        TutorialOverlay.SetActive(true);
    }

    void StartGame()
    {
        ArrowManager.areArrowsVisible = true;
        StartCoroutine(MovePan());
    }
    
    

    IEnumerator MovePan()
    {
        StartCoroutine(PanSpriteController.Wobble());
        // pause
        yield return new WaitForSeconds(delayBeforeTilt);
        // ArrowManager.ArrowType currentArrow = ArrowManager.GetCurrentArrow();
        // PanSpriteController.TiltTowards(currentArrow);
        // ArrowManager.areArrowsVisible = promptedArrowsLeft > 0;
        // if (promptedArrowsLeft > 0) 
        //     promptedArrowsLeft--;
        // yield return new WaitForSeconds(delayBeforeListeningForInput);
        // ListenForInput(listenDuration);
        // yield return new WaitForSeconds(Random.Range(minDelayBetweenPanMoves, maxDelayBetweenPanMoves));
        // StartCoroutine(MovePan());
    }
    void ListenForInput(float listenDuration)
    {
        // TODO
    }
    public void Win()
    {
        StopAllCoroutines();
        DogMoodManager.Instance.SetMood(DogMoodManager.DogMoods.Angry);
        WinOverlay.SetActive(true);
        GameMgr.Instance.waitAndLoadNextScene(5.0f);
    }

    public void Lose()
    {
        foreach(GameObject overlay in DeathOverlays)
            overlay.SetActive(true);
        DogMoodManager.Instance.SetMood(DogMoodManager.DogMoods.Happy);
        GameMgr.Instance.lossAndWaitLoadScene(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
