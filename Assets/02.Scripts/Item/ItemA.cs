using UnityEngine;

public class ItemA : MonoBehaviour
{
    [SerializeField] private Transform player;
    private ItemMagnet itemMagnet;

    private void Awake()
    {
        itemMagnet = GetComponent<ItemMagnet>();

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
        itemMagnet.Megnet(player, gameObject.transform);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ReturnPool();
            UIManager.Instance.TakeCount();
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
