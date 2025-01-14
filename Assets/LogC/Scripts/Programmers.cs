using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class Programmers : MonoBehaviour
{
    //public string solution(string[] survey, int[] choices)
    //{
    //    Dictionary<char, int> scores = new Dictionary<char, int>
    //    {
    //        { 'R', 0 },
    //        { 'T', 0 },
    //        { 'C', 0 },
    //        { 'F', 0 },
    //        { 'J', 0 },
    //        { 'M', 0 },
    //        { 'A', 0 },
    //        { 'N', 0 }
    //    };

    //    for (int i = 0; i < choices.Length; i++)
    //    {
    //        char type1 = survey[i][0];
    //        char type2 = survey[i][1];
    //        int choice = choices[i];

    //        if (choice < 4)
    //        {
    //            scores[type1] += (4 - choice);
    //        }
    //        else if (choice > 4)
    //        {
    //            scores[type2] += (choice - 4);
    //        }
    //    }

    //    string answer = "";
    //    answer += (scores['R'] >= scores['T']) ? 'R' : 'T';
    //    answer += (scores['C'] >= scores['F']) ? 'C' : 'F';
    //    answer += (scores['J'] >= scores['M']) ? 'J' : 'M';
    //    answer += (scores['A'] >= scores['N']) ? 'A' : 'N';

    //    return answer;
    //}

    //public int solution(int[] ingredient)
    //{
    //    int answer = 0;

    //    int bread = 0;
    //    int vegetable = 0;
    //    int meat = 0;

    //    for(int i = 0; i < ingredient.Length; i++)
    //    {
    //        if (ingredient[i] == 1)
    //        {
    //            bread++;
    //        }
    //        else if (ingredient[i] == 2)
    //        {
    //            vegetable++;
    //        }
    //        else
    //        {
    //            meat++;
    //        }
    //    }

    //    while(bread > 2 && vegetable > 1 && meat > 1)
    //    {
    //        bread -= 2;
    //        vegetable -= 1;
    //        meat -= 1;

    //        answer++;
    //    }

    //    answer++;

    //    return answer;
    //}

    public string solution(string my_string, int s, int e)
    {
        string answer = my_string;
        answer.Remove(s, e - s + 1);

        for (int i = e; i >= s; i--)
        {
            answer.Insert(s + (e - i), my_string[i].ToString());
        }

        return answer;
    }

    private void Awake()
    {
        Debug.Log(solution("Progra21Sremm3", 6, 12));

    }

}


