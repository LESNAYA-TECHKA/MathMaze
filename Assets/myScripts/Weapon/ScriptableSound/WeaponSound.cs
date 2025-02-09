using UnityEngine;

[CreateAssetMenu(fileName = "WeponSound", menuName = "Scriptable Objects/WeponSound")]
public class WeaponSound : ScriptableObject
{
    public AudioClip shoot;
    public AudioClip reload;
    public AudioClip empty;
}
