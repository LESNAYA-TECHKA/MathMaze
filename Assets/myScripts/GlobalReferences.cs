using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    public static GlobalReferences instance { get; private set; }

    public GameObject bulletEffectsPrefab;

    public GameObject pressButtonToTakeWeapon;

    public GameObject deathCanvas;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;    
    }
}
