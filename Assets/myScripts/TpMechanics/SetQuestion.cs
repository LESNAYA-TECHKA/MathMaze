using TMPro;
using UnityEngine;

public class SetQuestion : MonoBehaviour
{

    private TextMeshPro textMeshProComponent;

    private void Start()
    {
        textMeshProComponent = GetComponentInChildren<TextMeshPro>();
    }


    public void SetDataQuestion(string data)
    {
        textMeshProComponent.text = data;
    }


}
