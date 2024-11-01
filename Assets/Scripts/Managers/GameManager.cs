using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameLive;
    public PoolManager pool;

    private void Awake()
    {
        Instance = this;
    }
}