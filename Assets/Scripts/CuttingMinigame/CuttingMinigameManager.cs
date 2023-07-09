using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CuttingMinigameManager : Singleton<CuttingMinigameManager>
{
    public int LivesCount;
    public int MaxLives;
    [SerializeField] private UnityEvent OnLoseEvents;
    [SerializeField] private UnityEvent OnWinEvents;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        LivesCount = MaxLives;
    }

    public void GotHit()
    {
        LivesCount--;
        if (LivesCount < 0)
        {
            Die();
        }
    }

    void Die()
    {
        // death animations?

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
