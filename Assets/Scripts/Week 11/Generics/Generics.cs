using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Generics
{
    // public class Generics : MonoBehaviour // If I am repating codes, I can ask my lecturer or classmates, "How can I make my codes more generic?"
    public static class Generics
    {
        //public List<int> allMyInts = new List<int>();
        //public List<Transform> allMyTransformsInScene = new List<Transform>();

        //public delegate void OneParamDelegate<T>(T val);
        //public delegate void TwoParamDelegate<T1,T2>(T1 val1, T2 val2);
        //public delegate void ThreeParamDelegate<T1, T2, T3>(T1 val1, T2 val2, T3 val3);

        //public static OneParamDelegate<bool> pauseGameEvent;
        //public static OneParamDelegate<int> scorePointEvent;
        //public static OneParamDelegate<int> changeHealthEvent;

        //public static ThreeParamDelegate<float, string, bool> damagePlayerEvent;

        // Start is called before the first frame update
        //void Start()
        //{
        //    Debug.Log(GetFirstInList<int>(allMyInts));
        //    Debug.Log(GetFirstInList<Transform>(allMyTransformsInScene).name);
        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}

        //private T GetFirstInList<T>(List<T> list)
        //{
        //    return list[0];
        //}

        public static T GetFirstInList<T>(List<T> list)
        {
            return list[0];
        }
    }
}
