using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public bool isArrowFlipped;

    SpriteRenderer upArrowShowUp;
    SpriteRenderer downArrowShowUp;
    SpriteRenderer leftArrowShowUp;
    SpriteRenderer rightArrowShowUp;
    public void ClearSlot()
    {
        upArrowShowUp.enabled = false;
        downArrowShowUp.enabled = false;
        leftArrowShowUp.enabled = false;
        rightArrowShowUp.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        upArrowShowUp = upArrow.GetComponent<SpriteRenderer>();
        downArrowShowUp = downArrow.GetComponent<SpriteRenderer>();
        leftArrowShowUp = leftArrow.GetComponent<SpriteRenderer>();
        rightArrowShowUp = rightArrow.GetComponent<SpriteRenderer>();
    }
    public CallAndResponseArrowManager.ArrowType currentArrow;

    public void ChangeArrow(CallAndResponseArrowManager.ArrowType newArrow)
    {
        currentArrow = newArrow;
        ClearSlot();
        switch(currentArrow) 
        {
            case CallAndResponseArrowManager.ArrowType.UP:
                if (isArrowFlipped)
                    downArrowShowUp.enabled = true;
                else
                    upArrowShowUp.enabled = true;
                break;
            case CallAndResponseArrowManager.ArrowType.DOWN:
                if (isArrowFlipped)
                    upArrowShowUp.enabled = true;
                else
                    downArrowShowUp.enabled = true;
                break;
            case CallAndResponseArrowManager.ArrowType.LEFT:
                if (isArrowFlipped)
                    rightArrowShowUp.enabled = true;
                else
                    leftArrowShowUp.enabled = true;
                break;
            case CallAndResponseArrowManager.ArrowType.RIGHT:
                if (isArrowFlipped)
                    leftArrowShowUp.enabled = true;
                else
                    rightArrowShowUp.enabled = true;
                break;
            default:
                if (isArrowFlipped)
                    downArrowShowUp.enabled = true;
                else
                    upArrowShowUp.enabled = true;
                break;
        }
    }
}
