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
    private Transform target;
    private enum KnifeStates {
        WANDERING = 0,
        TRACKING,
        PRECUT,
        CUTTING
    }
    [SerializeField] private Rigidbody2D knifeRigidBody;
    [SerializeField] private float currentActionTimeLeft;
    [SerializeField] private float actionDelay;
    [Header("Action States Durations (seconds)")]
    [SerializeField] private float WanderingActionDuration;
    [SerializeField] private float TrackingActionDuration;
    [SerializeField] private float PrecutActionDuration;
    [SerializeField] private float CuttingActionDuration;

    private KnifeStates KnifeCurrentState;
    

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerMgr.Instance.Player.transform;
        KnifeCurrentState = KnifeStates.WANDERING;
        currentActionTimeLeft = WanderingActionDuration;
    }

    void Update()
    {
        currentActionTimeLeft -= Time.deltaTime;
        if (currentActionTimeLeft > 0)
        {
            // do something
            return;
        }
        switch (KnifeCurrentState) {
             case KnifeStates.WANDERING:
                KnifeCurrentState = KnifeStates.TRACKING;
                currentActionTimeLeft = TrackingActionDuration;
                break;   
            case KnifeStates.TRACKING:
                KnifeCurrentState = KnifeStates.PRECUT;
                currentActionTimeLeft = PrecutActionDuration;
                break;
            case KnifeStates.PRECUT:
                // TODO warn the player that they about to be cut
                KnifeCurrentState = KnifeStates.CUTTING;
                currentActionTimeLeft = CuttingActionDuration;
                break;
            case KnifeStates.CUTTING:
                KnifeCurrentState = KnifeStates.WANDERING;
                currentActionTimeLeft = WanderingActionDuration; 
                break;
            default:
                Debug.LogError("Knife's current state wasn't set properly!");
                
                break;
        }      

    }

    void BeginWander()
    {
        // TODO
    }

    void BeginTracking()
    {
        // TODO track the player loosely UNLESS they are moving too quickly
        
    }

    void BeginPrecut()
    {
        // TODO
    }

    void BeginCutting()
    {
        // TODO
    }

    void FixedUpdate()
    {
        // for physics
    }
}
