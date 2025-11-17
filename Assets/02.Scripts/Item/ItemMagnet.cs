using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    [SerializeField] private float megnetDistance = 2f; //아이템 자석 범위
    [SerializeField] private float megnetSpeed = 8.0f;     //자석 속도

    public void Megnet(Transform playerPos, Transform itemPos)
    {
        float distace = Vector3.Distance(playerPos.position, itemPos.position);

        if (distace <= megnetDistance)
        {
            itemPos.position = Vector3.Lerp(itemPos.position, playerPos.position, megnetSpeed * Time.deltaTime);
            Debug.Log("sss");
        }
    }
}
