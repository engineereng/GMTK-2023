using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingKnife : MonoBehaviour
{
    // goal: track the player "warning" mode
    // like this: https://youtu.be/st-a0XKaVh4?t=858
    // knife hovers with it?
    // blink and play warning sound?
    // then CUT and see if the player character got hit - if so, make them lose a heart or something
    // 
    private Rigidbody2D target;
    private enum KnifeActions {
        WANDERING = 0,
        TRACKING,
        PRECUT,
        CUTTING
    }

    [Header("Knife actions")]
    [SerializeField] private KnifeActions CurrentAction;
    [SerializeField] private float ActionTimeLeft;

    [Header("Object refs")]
    [SerializeField] private GameObject KnifeSprite;
    [SerializeField] private GameObject WarningLine;
    [SerializeField] private Rigidbody2D knifeRigidBody;
    [Header("Action States Durations (seconds)")]
    [SerializeField] private float WanderingActionDuration;
    [SerializeField] private float TrackingActionDuration;
    [SerializeField] private float PrecutActionDuration;
    [SerializeField] private float CuttingActionDuration;

    [Header("Wandering physics")]
    [SerializeField] private float WanderingMinX;
    [SerializeField] private float WanderingMaxX;
    [Range(0.5f, 2.0f)]
    [SerializeField] private float WanderInterval;
    [SerializeField] private float WanderStartDelay;
    [Header("Tracking Physics constants")]
    [SerializeField] private float knifeSpeedScale;
    // [SerializeField] private float knifePunishSpeed;  
    // Start is called before the first frame update
    [Header("Cutting constants")]
    [SerializeField] private bool isTouchingPlayer;
    int foo;
    void Start()
    {
        target = PlayerMgr.Instance.Player.GetComponent<Rigidbody2D>();        
        CurrentAction = KnifeActions.WANDERING;
        ActionTimeLeft = WanderingActionDuration;
        Invoke(nameof(Wander), WanderStartDelay);
    }

    void Update()
    {
        ActionTimeLeft -= Time.deltaTime;
        if (ActionTimeLeft > 0)
        {
            if (CurrentAction.Equals(KnifeActions.CUTTING))
            {
                KnifeSlice();
            }
            return;
        }
        switch (CurrentAction) {
             case KnifeActions.WANDERING:
                 // scale knife back to 1 / default
                CancelInvoke();
                CurrentAction = KnifeActions.TRACKING;
                ActionTimeLeft = TrackingActionDuration;
                break;   
            case KnifeActions.TRACKING:
                CurrentAction = KnifeActions.PRECUT;
                ActionTimeLeft = PrecutActionDuration;
                SpriteRenderer WarningLineSpriteRender = WarningLine.GetComponent<SpriteRenderer>();
                SpriteRenderer KnifeSpriteSpriteRender = KnifeSprite.GetComponent<SpriteRenderer>();
                WarningLineSpriteRender.color = Color.red;
                KnifeSpriteSpriteRender.enabled = false;
                break;
            case KnifeActions.PRECUT:
                CancelInvoke();
                // TODO warn the player that they about to be cut
                CurrentAction = KnifeActions.CUTTING;
                ActionTimeLeft = CuttingActionDuration;
                WarningLineSpriteRender = WarningLine.GetComponent<SpriteRenderer>();
                KnifeSpriteSpriteRender = KnifeSprite.GetComponent<SpriteRenderer>();
                KnifeSpriteSpriteRender.enabled = true;
                WarningLineSpriteRender.color = Color.black;
                // scale the knife to x2 then back to x1
                break;
            case KnifeActions.CUTTING:
                // scale knife to 0.9
                CurrentAction = KnifeActions.WANDERING;
                ActionTimeLeft = WanderingActionDuration; 
                Invoke(nameof(Wander), WanderStartDelay);
                break;
            default:
                Debug.LogError("Knife's current state wasn't set properly!");
                break;
        }      

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"));
            isTouchingPlayer = true;
            // 
    }

    void Wander()
    {
        Invoke(nameof(Wander), WanderInterval);
        float randomPosition = Random.Range(WanderingMinX, WanderingMaxX);
        knifeRigidBody.AddForce(new Vector2(((randomPosition - knifeRigidBody.position.x) * knifeSpeedScale / Time.deltaTime) - knifeRigidBody.velocity.x, 0));                
    }

    bool KnifeSlice()
    {
        Debug.Log("cut: " + isTouchingPlayer);
        return isTouchingPlayer;
    }

    void FixedUpdate()
    {
        switch (CurrentAction) {
            case KnifeActions.TRACKING:
                knifeRigidBody.AddForce(new Vector2(((target.position.x - knifeRigidBody.position.x) * knifeSpeedScale / Time.deltaTime) - knifeRigidBody.velocity.x, 0));
                break;
            case KnifeActions.PRECUT:
                knifeRigidBody.velocity = Vector2.zero;
                break;
            default:
                // Debug.LogError("Knife's current state wasn't set properly!");
                break;
        }
    }
}
