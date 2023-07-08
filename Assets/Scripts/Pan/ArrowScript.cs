using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowScript : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public SpriteRenderer temp;
    public Pattern[] ArrowSequences;
    [SerializeField] private int PatternIndex;
    [SerializeField] private int ArrowInPatternIndex;
    SpriteRenderer upArrowShowUp;
    SpriteRenderer downArrowShowUp;
    SpriteRenderer leftArrowShowUp;
    SpriteRenderer rightArrowShowUp;
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
    private ArrowType arrowType;
    void Start()
    {
        InvokeRepeating ("ChooseSequenceArrow", 2.0f, 1.0f); // increase in difficulties about speeding up
        upArrowShowUp = upArrow.GetComponent<SpriteRenderer>();
        downArrowShowUp = downArrow.GetComponent<SpriteRenderer>();
        leftArrowShowUp = leftArrow.GetComponent<SpriteRenderer>();
        rightArrowShowUp = rightArrow.GetComponent<SpriteRenderer>();

    }
   
    bool isCorrect = false;

    void ChooseSequenceArrow()
    {
        Pattern currentPattern = ArrowSequences[PatternIndex];
        ArrowType currentArrow = currentPattern.arrows[ArrowInPatternIndex];
        HideAllArrows();
        // Vector2 moveAmount = PlayerMgr.Instance.MoveAmount;

        // Debug.Log("moveamount:" + moveAmount);
        switch(currentArrow) 
        {
            case ArrowType.UP:
                downArrowShowUp.enabled = true;
                arrowType = ArrowType.UP;
                // Thread.Sleep(milliseconds);
                // await Task.Delay(milliseconds);
                break;
            case ArrowType.DOWN:
                upArrowShowUp.enabled = true;
                arrowType = ArrowType.DOWN;
                break;
            case ArrowType.LEFT:
                rightArrowShowUp.enabled = true;
                arrowType = ArrowType.LEFT;
                break;
            case ArrowType.RIGHT:
                leftArrowShowUp.enabled = true;
                arrowType = ArrowType.RIGHT;
                break;
            default:
                arrowType = ArrowType.UP;
                upArrowShowUp.enabled = true;
                break;
        }
        ArrowInPatternIndex += 1;
        if (ArrowInPatternIndex >= currentPattern.arrows.Length)
        {
            ArrowInPatternIndex = 0;
            PatternIndex += 1;
        }
        Invoke(nameof(HideAllArrows), 0.600f);
        // transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        // Debug.Log(randomNum);
    }
    void ChooseRandomArrow()
    {
        int randomNum = Random.Range(1, 5);
        HideAllArrows();
        // Vector2 moveAmount = PlayerMgr.Instance.MoveAmount;

        // Debug.Log("moveamount:" + moveAmount);
        switch (randomNum)
        {
            case 1:
                upArrowShowUp.enabled = true;
                arrowType = ArrowType.UP;
                break;
            case 2:
                downArrowShowUp.enabled = true;
                arrowType = ArrowType.DOWN;
                break;
            case 3:
                leftArrowShowUp.enabled = true;
                arrowType = ArrowType.LEFT;
                break;
            case 4:
                rightArrowShowUp.enabled = true;
                arrowType = ArrowType.RIGHT;
                break;
            default:
                arrowType = ArrowType.UP;
                upArrowShowUp.enabled = true;
                break;
        }
        // transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        // Debug.Log(randomNum);
    }

    void HideAllArrows()
    {
        upArrowShowUp.enabled = false;
        downArrowShowUp.enabled = false;
        leftArrowShowUp.enabled = false;
        rightArrowShowUp.enabled = false;
    }

    void Update()
    {   Vector2 moveAmount = PlayerMgr.Instance.MoveAmount;

        switch(arrowType) 
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

