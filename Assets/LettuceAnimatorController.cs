using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettuceAnimatorController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public Animator AnimationController;
    [SerializeField] float animationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = Mathf.Clamp(Mathf.Abs(rigidbody2D.velocity.x), 0, 1.5f);
        // Debug.Log("new speed:" + newSpeed);
        AnimationController.SetFloat("Speed", newSpeed);
        AnimationController.SetBool("FacingRight", rigidbody2D.velocity.x >= 0);
    }
}
