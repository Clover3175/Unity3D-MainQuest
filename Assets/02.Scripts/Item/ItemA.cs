using UnityEngine;

public class ItemA : MonoBehaviour
{
    [SerializeField] private Transform player;
    private ItemMagnet itemMagnet;

    private ItemSpawn itemSpawn;

    private void Awake()
    {
        itemMagnet = GetComponent<ItemMagnet>();

        itemSpawn = FindObjectOfType<ItemSpawn>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
    }
    void Start()
    {

    }
    void Update()
    {
        if (!gameObject.activeSelf) return;

        if (player != null)
        {
            itemMagnet.Megnet(player, gameObject.transform);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ReturnPool();
            UIManager.Instance.TakeCount();
        }
        if (collision.CompareTag("Building"))
        {
            gameObject.transform.position = itemSpawn.randomPos;
        }
    }
    private void ReturnPool()
    {
        if (PoolManager.Instance != null)
        {
            PoolManager.Instance.ReturnPool(this);
        }
    }
    
    
}
