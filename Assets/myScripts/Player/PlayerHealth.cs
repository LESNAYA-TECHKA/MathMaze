using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance { get; private set; }



    [SerializeField] private Slider health;
    [SerializeField] private TextMeshProUGUI text;

    public FloatReactiveProperty HealthValue { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        HealthValue = new FloatReactiveProperty();
        health.value = 100;

        HealthValue.Value = health.value;
        Debug.Log(HealthValue.Value);
        //updateHealthInCanvas();
    }



    public void TakeDamage(int damage)
    {
        health.value -= damage;
        HealthValue.Value -= damage;
        Debug.Log(HealthValue.Value);
        //updateHealthInCanvas();
    }

    //private void updateHealthInCanvas()
    //{
    //    text.text = health.ToString();

    //}

}
