using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPosition", menuName = "Scriptable Objects/WeaponPosition")]
public class WeaponPosition : ScriptableObject
{
    public Vector3 position;
    public float rotatex;
    public float rotatey;
    public float rotatez;
}
