using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveStrength;
    public float timeValue = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // //used arrow to show if the pan is moving up/down/left/right
        // if(Input.GetKeyDown(KeyCode.UpArrow) == true && (timeValue > 0))
        // {          
        //         myRigidbody.velocity = Vector2.up*moveStrength;
        //         timeValue = timeValue - Time.deltaTime;
            
            
        // }
        
    }
}
