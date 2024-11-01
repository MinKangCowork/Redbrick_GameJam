using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolManager : MonoBehaviour
{
    public enum PoolType { Tower, Bullet, Enemy, Effect }  // Ǯ Ÿ���� �����ϴ� enum    
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
        // TowerPool�ʱ�ȭ
        towerPools = new List<GameObject>[towerPrefabs.Length];
        for (int index = 0; index < towerPools.Length; index++)
        {
            towerPools[index] = new List<GameObject>();
        }

        // WeaponPool �ʱ�ȭ
        bulletPools = new List<GameObject>[bulletPrefabs.Length];
        for (int index = 0; index < bulletPools.Length; index++)
        {
            bulletPools[index] = new List<GameObject>();
        }

        // EnemyPool �ʱ�ȭ
        enemyPools = new List<GameObject>[enemyPrefabs.Length];
        for (int index = 0; index < enemyPools.Length; index++)
        {
            enemyPools[index] = new List<GameObject>();
        }
       
        // EfectPool �ʱ�ȭ
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

        // Ǯ Ÿ�Կ� ���� Ǯ�� ������ �迭 ����

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

        // ������ Ǯ�� ��Ȱ��ȭ �� ���� ������Ʈ ����
        foreach (GameObject item in selectedPool[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // Ǯ���� ��Ȱ��ȭ�� ������Ʈ�� ã�� ���� ���, ���� ����
        if (select == null)
        {
            select = Instantiate(selectedPrefabs[index], transform);
            selectedPool[index].Add(select);
        }

        return select;
    }
}
