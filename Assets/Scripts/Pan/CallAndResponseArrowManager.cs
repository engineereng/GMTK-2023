using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CallAndResponseArrowManager : MonoBehaviour
{
    public Arrow[] ArrowSlots;
    
    public SpriteRenderer temp;
    [Header("Gameplay timing")]
    [SerializeField] private float TimeBetweenArrows;
    [SerializeField] private float ShowingStartingDelay;
    [SerializeField] private float PlayingStartingDelay;
    [SerializeField] private bool areArrowsFlipped;

    [Header("Arrow patterns")]
    public Pattern[] ArrowSequences;
    [SerializeField] private int PatternIndex;
    [SerializeField] private int ArrowInPatternIndex;
    [SerializeField] private ArrowType currentArrow;
    [SerializeField] private float BeatsPerMinute;
    [Header("State machine")]
    private State state;    
    public enum State
    {
        SHOWING_PATTERN,
        PLAYING_PATTERN
    }
    public enum ArrowType 
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    [System.Serializable]
    public class Pattern
    {
        public ArrowType[] arrows;
    };

    void Start()
    {
        state = State.SHOWING_PATTERN;
        
        // InvokeRepeating(nameof(ShowPattern), ShowUpDelay, ShowUpDelay);
        // Invoke(nameof(ShowPattern), ShowingStartingDelay);
        Invoke(nameof(ShowPattern), 4 * TimeBetweenArrows);
        TimeBetweenArrows = 60.0f / BeatsPerMinute; // assuming 4/4 time
    }
    

   
    bool isCorrect = false;

    #region Name
        // void ChooseSequenceArrow()
        // {
        //     Pattern currentPattern = ArrowSequences[PatternIndex];
        //     ArrowType currentArrow = currentPattern.arrows[ArrowInPatternIndex];
        //     arrowType = currentArrow;
        //     HideAllArrows();
        //     switch(currentArrow) 
        //     {
        //         case ArrowType.UP:
        //             if (areArrowsFlipped)
        //                 downArrowShowUp.enabled = true;
        //             else
        //                 upArrowShowUp.enabled = true;
        //             break;
        //         case ArrowType.DOWN:
        //             if (areArrowsFlipped)
        //                 upArrowShowUp.enabled = true;
        //             else
        //                 downArrowShowUp.enabled = true;
        //             break;
        //         case ArrowType.LEFT:
        //             if (areArrowsFlipped)
        //                 rightArrowShowUp.enabled = true;
        //             else
        //                 leftArrowShowUp.enabled = true;
        //             break;
        //         case ArrowType.RIGHT:
        //             if (areArrowsFlipped)
        //                 leftArrowShowUp.enabled = true;
        //             else
        //                 rightArrowShowUp.enabled = true;
        //             break;
        //         default:
        //             arrowType = ArrowType.UP;
        //             upArrowShowUp.enabled = true;
        //             break;
        //     }
        //     ArrowInPatternIndex += 1;
        //     if (ArrowInPatternIndex >= currentPattern.arrows.Length)
        //     {
        //         ArrowInPatternIndex = 0;
        //         PatternIndex += 1;
        //     }
        //     Invoke(nameof(HideAllArrows), 0.600f);
        // }
    #endregion

    void ShowPattern()
    {
        Debug.Log("Showing pattern!");
        Pattern currentPattern = ArrowSequences[PatternIndex];
        currentArrow = currentPattern.arrows[ArrowInPatternIndex];
        Debug.Assert(ArrowInPatternIndex < ArrowSlots.Length);
        // switch (ArrowInPatternIndex) {
        //     case 0:
        //         topArrow.isArrowFlipped = areArrowsFlipped;
        //         topArrow.ChangeArrow(currentArrow);
        //         break;
        //     case 1:
        //         middleArrow.isArrowFlipped = areArrowsFlipped;
        //         middleArrow.ChangeArrow(currentArrow);
        //         break;
        //     case 2:
        //         bottomArrow.isArrowFlipped = areArrowsFlipped;
        //         bottomArrow.ChangeArrow(currentArrow);
        //         break;
        //     default:
        //         break;
        // }
        Arrow arrowDisplayTarget = ArrowSlots[ArrowInPatternIndex];
        arrowDisplayTarget.isArrowFlipped = areArrowsFlipped;
        arrowDisplayTarget.ChangeArrow(currentArrow);
        ArrowInPatternIndex += 1;
        if (IsCurrentPatternFinished())
        {
            state = State.PLAYING_PATTERN;
            ArrowInPatternIndex = 0;
            Invoke(nameof(PlayPattern), PlayingStartingDelay);
        } else {
            Invoke(nameof(ShowPattern), TimeBetweenArrows);
        }
    }

    bool IsCurrentPatternFinished()
    {
        Pattern currentPattern = ArrowSequences[PatternIndex];
        return ArrowInPatternIndex >= currentPattern.arrows.Length;
    }

    bool IsOutOfPatterns()
    {
        return PatternIndex >= ArrowSequences.GetLength(0);
    }

    void PlayPattern()
    {
        Debug.Log("Playing pattern!");
        // Play pattern
        // TODO
        ArrowInPatternIndex += 1;
        if (IsCurrentPatternFinished())
        {
            if (IsOutOfPatterns())
            {
                Debug.Log("Game won!");
                // TODO call win function
            } else {
                HideAllArrows();
                PatternIndex += 1;
                ArrowInPatternIndex = 0;
                Invoke(nameof(ShowPattern), ShowingStartingDelay);
            }
        }
    }

    // 150 bpm - 4/4
    // time between beats - seconds
    // 150 beats / minute * 1 minute / 60 seconds = 2.5 beats / second
    
    // 0.4 seconds between each beat

    void HideAllArrows()
    {
        foreach (Arrow arrowSlot in ArrowSlots)
        {
            arrowSlot.ClearSlot();
        }
    }

    #region Name
        // void ChooseRandomArrow()
        // {
        //     int randomNum = Random.Range(1, 5);
        //     HideAllArrows();
        //     // Vector2 moveAmount = PlayerMgr.Instance.MoveAmount;
    
        //     // Debug.Log("moveamount:" + moveAmount);
        //     switch (randomNum)
        //     {
        //         case 1:
        //             upArrowShowUp.enabled = true;
        //             arrowType = ArrowType.UP;
        //             break;
        //         case 2:
        //             downArrowShowUp.enabled = true;
        //             arrowType = ArrowType.DOWN;
        //             break;
        //         case 3:
        //             leftArrowShowUp.enabled = true;
        //             arrowType = ArrowType.LEFT;
        //             break;
        //         case 4:
        //             rightArrowShowUp.enabled = true;
        //             arrowType = ArrowType.RIGHT;
        //             break;
        //         default:
        //             arrowType = ArrowType.UP;
        //             upArrowShowUp.enabled = true;
        //             break;
        //     }
        //     // transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        //     // Debug.Log(randomNum);
        // }
    
        // void HideAllArrows()
        // {
        //     upArrowShowUp.enabled = false;
        //     downArrowShowUp.enabled = false;
        //     leftArrowShowUp.enabled = false;
        //     rightArrowShowUp.enabled = false;
        // }
    #endregion
    void Update()
    { 
        // if (PlayerMgr.Instance.FireIsBeingPressed)
        //     {
        //         Invoke(nameof(ShowPattern), 4 * TimeBetweenArrows);
        //     }
        if (state.Equals(State.SHOWING_PATTERN))
        {
            
            return;
        } else if (state.Equals(State.PLAYING_PATTERN))
        {
            Vector2 moveAmount = PlayerMgr.Instance.MoveAmount;

            // switch(currentArrow) 
            // {
            //     case ArrowType.UP:
            //         isCorrect = moveAmount == Vector2.up;
            //         break;
            //     case ArrowType.DOWN:
            //         isCorrect = moveAmount == Vector2.down;
            //         break;
            //     case ArrowType.LEFT:
            //         isCorrect = moveAmount == Vector2.left;
            //         break;
            //     case ArrowType.RIGHT:
            //         isCorrect = moveAmount == Vector2.right;
            //         break;
            //     default:
            //         break;
            // }

            if (isCorrect)
            temp.color = Color.green;
            else
            temp.color = Color.red;
        }
    }
}

