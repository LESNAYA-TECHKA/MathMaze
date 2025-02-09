using System;
using System.Collections;
using UnityEngine;

public class Solver
{

    public float Solve(int firstNumber, int secondNumber, Signs sign)
    {
        float result = 0;
        switch (sign)
        {
            case Signs.Plus:
                result = firstNumber + secondNumber;
                break;
            case Signs.Minus:
                result = firstNumber - secondNumber;
                break;
            case Signs.Multiply:
                result = firstNumber * secondNumber;
                break;
            case Signs.Divide:
                result = firstNumber / secondNumber;
                break;
            default:
                result = 0;
                break;
        }

        return (float)Math.Round(result, 2);
    }


}
