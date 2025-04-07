using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SAE.GAD176.Tutorials.Events
{
    public static class GameEvents // anything within a static class also has to be static.
    {
        // define all my events
        public static Action<float, Transform> OnDamageEvent; // parameters inside <> is setting up the rules or requirements for your event. E.g. <float, bool> If the scripts don't have bool, then the event won't work.
        public static Action OnGameStartEvent;

        // is effectively my delegate signiture.
        public delegate void FloatTransformDelegate(float amount, Transform trans);

        public static FloatTransformDelegate OnChangeHealthEvent;
        //public static FloatTransformDelegate OnUpdateUiEvent;

        // Once you make something static, it won't appear on the Inspector. So it's best not to make Unity Events a static.
    }
}
