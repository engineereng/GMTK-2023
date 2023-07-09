using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] GameObject upArrow, downArrow, leftArrow, rightArrow;
    public int ArrowInPatternIndex;
    public ArrowType CurrentArrow;
    public bool areArrowsVisible;
    public enum ArrowType 
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    public ArrowType[] Sequence;
    public UnityEvent[] OnFinishPatternEvents;
    // Start is called before the first frame update
    void Start()
    {
        HideAllArrows();
        // InvokeRepeating(nameof(ShowDirectionalArrow), 0.0f, 2.0f);
    }
    public void AdvanceToNextArrow()
    {
        ArrowInPatternIndex += 1;
        if (IsSequenceFinished())
        {
            foreach (UnityEvent Event in OnFinishPatternEvents)
            {
                Event.Invoke();
            }
        }
    }

    public ArrowType GetCurrentArrow()
    {
        return Sequence[ArrowInPatternIndex];
    }

    public void HideAllArrows()
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }

    public ArrowType OppositeArrowOf(ArrowType InputArrow)
    {
        ArrowType oppositeArrow = ArrowType.UP;
        switch (InputArrow)
        {
            case ArrowType.UP:
                oppositeArrow = ArrowType.DOWN;
                break;
            case ArrowType.DOWN:
                oppositeArrow = ArrowType.UP;
                break;
            case ArrowType.LEFT:
                oppositeArrow = ArrowType.RIGHT;
                break;
            case ArrowType.RIGHT:
                oppositeArrow = ArrowType.LEFT;
                break;
        } 
        return oppositeArrow;
    }
    public void ShowDirectionalArrow()
    {
        CurrentArrow = GetCurrentArrow();
        HideAllArrows();
        GameObject targetArrow;
        switch(CurrentArrow) 
        {
            case ArrowType.UP:
                targetArrow = upArrow;
                break;
            case ArrowType.DOWN:
                targetArrow = downArrow;
                break;
            case ArrowType.LEFT:
                targetArrow = leftArrow;
                break;
            case ArrowType.RIGHT:
                targetArrow = rightArrow;
                break;
            default:
                targetArrow = upArrow;
                CurrentArrow = ArrowType.UP;
                break;
        }
        if (areArrowsVisible) targetArrow.SetActive(true);
        // Invoke(nameof(HideAllArrows), 0.600f);
    }
    public bool IsSequenceFinished()
    {
        return ArrowInPatternIndex >= Sequence.Length;
    }
}
