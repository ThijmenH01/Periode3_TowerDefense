using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Initialize() {
        //new GameObject("Game Manager", typeof(GameManager));
        Object.Instantiate(Resources.Load("Game Manager"));
    }
}
