using System.Collections.Generic;
using UnityEngine;

public class GenerateWrongAnswers
{
    private List<int> usageWrongAnswers = new List<int>();
    public float WrongSolution(float number)
    {

        float min = number - 5;
        float max = number + 5;

       var wrongNumber = Random.Range(min, max);

        while (wrongNumber == number)
        {
            min += 0.1f;
            max -= 0.1f;
            wrongNumber = Random.Range(min, max);
        }

        return wrongNumber;
    }


    
}
