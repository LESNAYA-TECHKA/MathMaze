using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumbers
{
    private List<int> usageNumberFirst = new List<int>();
    private List<int> usageNumberSecond = new List<int>();

    public int GetRandomNumbers(int min, int max, int firstOrSecondNumber)
    {
        System.Random random = new System.Random();
        int number = random.Next(min, max);


        List<int> numbers = firstOrSecondNumber == 1 ? usageNumberFirst : usageNumberSecond;


        if (numbers.Contains(number))
            number = GetRandomNumbers(min, max, firstOrSecondNumber);
        else
            numbers.Add(number);

        switch(firstOrSecondNumber)
        {
            case 1: 
                usageNumberFirst.Add(number);
                break;
            case 2:
                usageNumberSecond.Add(number);
                break;
        }



        return number;
    }

}
