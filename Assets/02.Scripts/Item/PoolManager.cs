using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance {  get; private set; }

    private Dictionary<string, object> pools = new Dictionary<string, object>();

    public Dictionary<string, object> Pools
    {
        get { return pools; }
        private set { pools = value; }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    //private void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoded;
    //}
    //private void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoded;
    //}
    //private void OnSceneLoded(Scene secen, LoadSceneMode mode)
    //{
    //    foreach (var pool in pools.Values)
    //    {
    //        var clearMethod = pool.GetType().GetMethod("Clear");
    //        if (clearMethod != null)
    //        {
    //            clearMethod.Invoke(pool, null);
    //        }
    //    }
    //    pools.Clear();
    //}
    public void CreatPool<T>(T prefab, int initCount, Transform parent = null) where T : MonoBehaviour
    {
        if (prefab == null) return;

        string key = prefab.name;
        if (pools.ContainsKey(key)) return;

        pools.Add(key, new ObjectPool<T>(prefab, initCount, parent));
    }
    public T GetFromPool<T>(T prefab) where T : MonoBehaviour
    {
        if (prefab == null) return null;
    
        //등록할 때 썻던 프리팹 이름으로 풀 찾기
        //찾으면 box로 뱉음
        if (!pools.TryGetValue(prefab.name, out var box))
        {
            return null;
        }
    
        var pool = box as ObjectPool<T>;  //object로 저장된 풀을 원래 재네릭으로 반환
    
        if (pool != null)
        {
            return pool.Dequeue();
        }
        else
        {
            return null;
        }
    }
    public void ReturnPool<T>(T instance) where T : MonoBehaviour
    {
        if (instance == null) return;

        //어느 풀에도 없으면 삭제
        if (!pools.TryGetValue(instance.gameObject.name, out var box))
        {
            Destroy(instance.gameObject);
            return;
        }

        var pool = box as ObjectPool<T>;
        
        if (pool != null)
        {
            pool.Enqueue(instance);
        }
    }
}
