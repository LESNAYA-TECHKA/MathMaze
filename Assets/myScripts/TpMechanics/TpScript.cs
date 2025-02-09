using TMPro;
using UnityEngine;


public class TpScript : MonoBehaviour
{

    [SerializeField] private Transform rightAnswer;
    [SerializeField] private Transform wrongAnswer;
    private TextMeshPro textMeshProComponent;
    

    private Transform targetPos;
    private bool answer;

    private void Awake()
    {
        textMeshProComponent = GetComponentInChildren<TextMeshPro>();
    }


    //private void Start()
    //{
    //    SetTextNumber(5);
    //    SetCoordinates(true);

    //}

    public void SetTextNumber(float number)
    {
        textMeshProComponent.text = number.ToString();
    }

    public void SetCoordinates(bool coordinates)
    {
        targetPos = coordinates?rightAnswer:wrongAnswer;
        answer = coordinates;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = targetPos.position;
        }

        switch(answer)
        {
            case true:
                GameManager.Instance.correctAnswerCount++;
                    break;
            case false:
                GameManager.Instance.wrongAnswerCount++;
                break;
        }
        

        //Debug.Log($"enter {other.name}");
    }

}
