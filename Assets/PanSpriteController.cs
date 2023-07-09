using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanSpriteController : MonoBehaviour
{
    [SerializeField] GameObject PanTiltingRight, PanTiltingLeft, PanTiltingUp, PanTiltingDown, PanNeutral;
    Rigidbody2D panRigidbody;
    private Vector2 startingPosition;
    // // Start is called before the first frame update
    void Start()
    {
        panRigidbody = GetComponent<Rigidbody2D>();
        startingPosition = panRigidbody.position;
        ResetTilt();
    }

    private void HideAllTiltSprites()
    {
        PanTiltingDown.SetActive(false);
        PanTiltingUp.SetActive(false);
        PanTiltingLeft.SetActive(false);
        PanTiltingRight.SetActive(false);
        PanNeutral.SetActive(false);
    }

    /// <summary>
    /// Tilt towards a direction
    /// </summary>
    public void TiltTowards(ArrowManager.ArrowType direction)
    {
        HideAllTiltSprites();
        GameObject targetSprite = PanNeutral;
        switch (direction)
        {
            case ArrowManager.ArrowType.UP:
                targetSprite = PanTiltingUp;
                break;
            case ArrowManager.ArrowType.DOWN:
                targetSprite = PanTiltingDown;
                break;
            case ArrowManager.ArrowType.LEFT:
                targetSprite = PanTiltingLeft;
                break;
            case ArrowManager.ArrowType.RIGHT:
                targetSprite = PanTiltingRight;
                break;
        }
        targetSprite.SetActive(true);
    }
    public void ResetTilt()
    {
        HideAllTiltSprites();
        PanNeutral.SetActive(true);    
    }

    public IEnumerator Wobble()
    {
        Debug.Log("Wobble!");
        panRigidbody.AddForce(new Vector2(30.0f,-30.0f));
        yield return new WaitForSeconds(1.0f);

        panRigidbody.AddForce(new Vector2(-30.0f,0.0f));
        yield return new WaitForSeconds(1.0f);
        // panRigidbody.AddForce(startingPosition);
    }
    
}
