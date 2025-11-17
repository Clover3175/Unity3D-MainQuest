using UnityEngine;

public class LayerMaskUtils : MonoBehaviour
{
    public static bool IsInLayer(GameObject obj, LayerMask mask)
    {
        return(mask.value & (1<<obj.layer)) != 0;
    }
}
