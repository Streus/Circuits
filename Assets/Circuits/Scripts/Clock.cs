﻿using UnityEngine;

namespace Circuits
{
    [AddComponentMenu("Circuits/Clock")]
    public class Clock : CircuitNode
    {
        [SerializeField]
        private float pulseInterval = 0.9f;

        [SerializeField]
        private float pulseLength = 0.1f;

        private float currentDuration;

        private bool pulsing;

        private void Awake()
        {
            pulsing = Powered;
            currentDuration = pulsing ? pulseLength : pulseInterval;
        }

        protected override bool EvaluateState()
        {
            currentDuration -= Time.inFixedTimeStep ? Time.fixedDeltaTime : Time.deltaTime;
            if(currentDuration <= 0f)
            {
                pulsing = !pulsing;
                currentDuration += (pulsing ? pulseLength : pulseInterval);
            }
            return Inverted ^ pulsing;
        }
    }
}
