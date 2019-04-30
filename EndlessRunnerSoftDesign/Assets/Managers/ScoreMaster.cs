using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster : Managers
{
    public static int PlayScore { get; private set; }

    public static void AddToPlayScore(int amount)
    {
        PlayScore += amount;
    }
}
