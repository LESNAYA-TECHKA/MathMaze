using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public static SoundManager instance { get; set; }

    public AudioSource Pistol_Shoot;
    public AudioSource Pistol_EmptyMagazine;
    public AudioSource Pistol_Reload;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }


}
