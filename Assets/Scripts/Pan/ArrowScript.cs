using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // public float moveSpeed = 5;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("ChooseArrow", 2.0f, 1.0f); //change it back to 2.3f,3.0f
    }
    // Update is called once per frame
    void ChooseArrow()
    {
        int randomNum = Random.Range(1, 5);
        SpriteRenderer upArrowShowUp = upArrow.GetComponent<SpriteRenderer>();
        upArrowShowUp.enabled = false;
        SpriteRenderer downArrowShowUp = downArrow.GetComponent<SpriteRenderer>();
        downArrowShowUp.enabled = false;
        SpriteRenderer leftArrowShowUp = leftArrow.GetComponent<SpriteRenderer>();
        leftArrowShowUp.enabled = false;
        SpriteRenderer rightArrowShowUp = rightArrow.GetComponent<SpriteRenderer>();
        rightArrowShowUp.enabled = false;

        switch(randomNum) 
        {
            case 1:
                upArrowShowUp.enabled = true;
                break;
            case 2:
                downArrowShowUp.enabled = true;
                break;
            case 3:
                leftArrowShowUp.enabled = true;
                break;
            case 4:
                rightArrowShowUp.enabled = true;
                break;
            default:
                break;
        }
        // transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        Debug.Log(randomNum);
    }
}

