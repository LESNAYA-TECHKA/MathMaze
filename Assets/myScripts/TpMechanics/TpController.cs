using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TpController : MonoBehaviour
{
    [SerializeField] private List<TpScript> Teleports;
    [SerializeField] private SetQuestion question;

    private Dictionary<float, bool> solutions = new Dictionary<float, bool>();
    private int firstNumber;
    private int secondNumber;
    private float rightAnswer;
    public Signs sign { get; private set; }
    public Difficult difficult { get; private set; }


    private void Awake()
    {
        sign = GameManager.Instance.signs;
        difficult = GameManager.Instance.difficult;

    }


    private void Start()
    {
        GetNumbers();
        Solve();
        GenerateWrongAnswers();
        SetQuestion();
        SetDataToTeleports();
 
    }








    private void SetQuestion()
    {
        char dataSign = ' ';

        switch(sign)
        {
            case Signs.Plus:
                dataSign = '+';
                break;
            case Signs.Minus:
                dataSign = '-' ;
                break;
            case Signs.Multiply:
                dataSign = '*';
                break;
            case Signs.Divide:
                dataSign = '/';
                break;
        }




        question.SetDataQuestion($"{firstNumber} {dataSign} {secondNumber} =");
    }




    private void GetNumbers()
    {
        GenerateNumbers generate = new GenerateNumbers();
        switch(difficult)
        {
            case Difficult.Easy:
                firstNumber = generate.GetRandomNumbers(0, 10, 1);
                secondNumber= generate.GetRandomNumbers(0, 10, 2);
                break;
            case Difficult.Normal:
                firstNumber = generate.GetRandomNumbers(10, 100, 1);
                secondNumber = generate.GetRandomNumbers(10, 100, 2);
                break;
            case Difficult.Hard:
                firstNumber = generate.GetRandomNumbers(100, 1000, 1);
                secondNumber = generate.GetRandomNumbers(100, 1000, 2);
                break;
            case Difficult.SuperHard:
                firstNumber = generate.GetRandomNumbers(1000, 1000000, 1);
                secondNumber = generate.GetRandomNumbers(1000, 1000000, 2);
                break;
            default:
                firstNumber = generate.GetRandomNumbers(0, 10, 1);
                secondNumber = generate.GetRandomNumbers(0, 10, 2);
                break;
        }
    }

    private void Solve()
    {
        Solver solve = new Solver();
        rightAnswer = solve.Solve(firstNumber,secondNumber,sign);
        solutions.Add(rightAnswer,true);

    }

    private void GenerateWrongAnswers()
    {
        GenerateWrongAnswers generate = new GenerateWrongAnswers(); 
        for (int i = 0; i < Teleports.Count; i++)
        {
            var wrongAnswer = generate.WrongSolution(rightAnswer);
            solutions.Add(wrongAnswer,false);
        }

    }

    private void SetDataToTeleports()
    {



        foreach (var t in Teleports)
        {
            var keys = solutions.Keys.ToList();
            var randomKey = Random.Range(0, keys.Count-1);

            t.SetTextNumber(keys[randomKey]);
            t.SetCoordinates(solutions[keys[randomKey]]);
            solutions.Remove(keys[randomKey]);
        }



    }

    //private void Update()
    //{
    //    Debug.Log(difficult);
    //    Debug.Log(sign);
    //}
}
