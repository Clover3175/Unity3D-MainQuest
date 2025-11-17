using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T prefab;
    private Queue<T> pool = new Queue<T>();
    
    public Transform Root { get; private set; } //풀을 담을 부모

    public ObjectPool(T prefab, int initCount, Transform parent = null)
    {
        this.prefab = prefab;

        Root = new GameObject($"{prefab.name}_Pool").transform;

        Object.DontDestroyOnLoad(Root.gameObject); //씬 로드시 삭제 방지

        if (parent != null)
        {
            Root.SetParent(parent, false);
        }

        for (int i = 0; i < initCount; i++)
        {
            var init = Object.Instantiate(prefab, Root); //Root자식으로 생성
            init.name = prefab.name;
            init.gameObject.SetActive(false);
            pool.Enqueue(init); //큐에 넣기
        }
    }
    public T Dequeue()
    {
        if (pool.Count == 0) return null;

        var inst = pool.Dequeue();
        inst.gameObject.SetActive(true);
        return inst;  
    }
    public void Enqueue(T instace)
    {
        if (instace == null) return;

        instace.gameObject.SetActive(false);
        pool.Enqueue(instace);
    }
}
