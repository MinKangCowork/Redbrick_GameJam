using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolManager : MonoBehaviour
{
    public enum PoolType { Tower, Bullet, Enemy, Effect }  // 풀 타입을 구분하는 enum    
    public GameObject[] towerPrefabs;
    public GameObject[] bulletPrefabs;
    public GameObject[] enemyPrefabs;
    public GameObject[] effectPrefabs;

    private List<GameObject>[] towerPools;
    private List<GameObject>[] bulletPools;
    private List<GameObject>[] enemyPools;
    private List<GameObject>[] effectPools;

    private void Awake()
    {
        // TowerPool초기화
        towerPools = new List<GameObject>[towerPrefabs.Length];
        for (int index = 0; index < towerPools.Length; index++)
        {
            towerPools[index] = new List<GameObject>();
        }

        // WeaponPool 초기화
        bulletPools = new List<GameObject>[bulletPrefabs.Length];
        for (int index = 0; index < bulletPools.Length; index++)
        {
            bulletPools[index] = new List<GameObject>();
        }

        // EnemyPool 초기화
        enemyPools = new List<GameObject>[enemyPrefabs.Length];
        for (int index = 0; index < enemyPools.Length; index++)
        {
            enemyPools[index] = new List<GameObject>();
        }
       
        // EfectPool 초기화
        effectPools = new List<GameObject>[effectPrefabs.Length];
        for (int index = 0; index < effectPools.Length; index++)
        {
            effectPools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(PoolType poolType, int index)
    {
        List<GameObject>[] selectedPool = null;
        GameObject[] selectedPrefabs = null;

        // 풀 타입에 따라 풀과 프리팹 배열 선택

        switch (poolType)
        {
            case PoolType.Tower:
                selectedPool = towerPools;
                selectedPrefabs = towerPrefabs;
                break;
            case PoolType.Bullet:
                selectedPool = bulletPools;
                selectedPrefabs = bulletPrefabs;
                break;

            case PoolType.Enemy:
                selectedPool = enemyPools;
                selectedPrefabs = enemyPrefabs;
                break;

            case PoolType.Effect:
                selectedPool = effectPools;
                selectedPrefabs = effectPrefabs;
                break;
        }


        if (selectedPool == null || selectedPrefabs == null) return null;

        GameObject select = null;

        // 선택한 풀의 비활성화 된 게임 오브젝트 접근
        foreach (GameObject item in selectedPool[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 풀에서 비활성화된 오브젝트를 찾지 못한 경우, 새로 생성
        if (select == null)
        {
            select = Instantiate(selectedPrefabs[index], transform);
            selectedPool[index].Add(select);
        }

        return select;
    }
}
