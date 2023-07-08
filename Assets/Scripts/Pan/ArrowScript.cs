using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowScript : MonoBehaviour
{
    // public GameObject upArrow;
    // public GameObject downArrow;
    // public GameObject leftArrow;
    // public GameObject rightArrow;
    public Arrow topArrow;
    public Arrow middleArrow;
    public Arrow bottomArrow;
    public SpriteRenderer temp;
    [SerializeField] private bool areArrowsFlipped;
    
    public Pattern[] ArrowSequences;
    [SerializeField] private int PatternIndex;
    [SerializeField] private int ArrowInPatternIndex;
    [SerializeField] private float ShowUpDelay;
    private State state;
    // SpriteRenderer upArrowShowUp;
    // SpriteRenderer downArrowShowUp;
    // SpriteRenderer leftArrowShowUp;
    // SpriteRenderer rightArrowShowUp;
    [SerializeField] private ArrowType currentArrow;
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
        InvokeRepeating(nameof(ShowPattern), ShowUpDelay, ShowUpDelay);
    }

    // void Start()
    // {
    //     // InvokeRepeating ("ChooseSequenceArrow", 2.0f, 1.0f); // increase in difficulties about speeding up
    //     upArrowShowUp = upArrow.GetComponent<SpriteRenderer>();
    //     downArrowShowUp = downArrow.GetComponent<SpriteRenderer>();
    //     leftArrowShowUp = leftArrow.GetComponent<SpriteRenderer>();
    //     rightArrowShowUp = rightArrow.GetComponent<SpriteRenderer>();

    // }
   
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
        Pattern currentPattern = ArrowSequences[PatternIndex];
        currentArrow = currentPattern.arrows[ArrowInPatternIndex];
        switch (ArrowInPatternIndex) {
            case 0:
                topArrow.isArrowFlipped = areArrowsFlipped;
                topArrow.ChangeArrow(currentArrow);
                break;
            case 1:
                middleArrow.isArrowFlipped = areArrowsFlipped;
                middleArrow.ChangeArrow(currentArrow);
                break;
            case 2:
                bottomArrow.isArrowFlipped = areArrowsFlipped;
                bottomArrow.ChangeArrow(currentArrow);
                break;
            default:
                break;
        }
        ArrowInPatternIndex += 1;
        // if (ArrowInPatternIndex >= currentPattern.arrows.Length)
        // {
        //     CancelInvoke();
        //     ArrowInPatternIndex = 0;
        //     InvokeRepeating(nameof(PlayPattern), ShowUpDelay, ShowUpDelay);
        //     state = State.PLAYING_PATTERN;
        // }
    }

    void PlayPattern()
    {
        
        // ArrowInPatternIndex = 0;
        // PatternIndex += 1;
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
        if (state.Equals(State.SHOWING_PATTERN))
        {
            
            return;
        } else if (state.Equals(State.PLAYING_PATTERN))
        {
            Vector2 moveAmount = PlayerMgr.Instance.MoveAmount;

            switch(currentArrow) 
            {
                case ArrowType.UP:
                    isCorrect = moveAmount == Vector2.up;
                    break;
                case ArrowType.DOWN:
                    isCorrect = moveAmount == Vector2.down;
                    break;
                case ArrowType.LEFT:
                    isCorrect = moveAmount == Vector2.left;
                    break;
                case ArrowType.RIGHT:
                    isCorrect = moveAmount == Vector2.right;
                    break;
                default:
                    break;
            }

            if (isCorrect)
            temp.color = Color.green;
            else
            temp.color = Color.red;
        }
    }
}

