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
    [SerializeField] private SpriteRenderer OverlayIntro;
    [SerializeField] private SpriteRenderer DeathIntro;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        LivesCount = MaxLives;
        OverlayIntro.enabled = true;
        Invoke(nameof(RemoveOverlay), 1.0f);
    }
    void RemoveOverlay()
    {
        OverlayIntro.enabled = false;
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
        Time.timeScale = 0;
        LettuceAnimatorMgr.Instance.Die();
        DogMoodManager.Instance.SetMood(DogMoodManager.DogMoods.Happy);
        DeathIntro.enabled = true;
    }
}
