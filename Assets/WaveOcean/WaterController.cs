using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Waves.WaveOcean
{
    public class WaterController :MonoBehaviour
    {
        public static WaterController current;

        public bool isMoving;

        //Wave height and speed
        public float scale = 0.1f;
        public float speed = 1.0f;
        //The width between the waves
        public float waveDistance = 1f;
        //Noise parameters
        //public float noiseStrength = 1f;
        //public float noiseWalk = 1f;

        void Start()
        {
            current = this;
        }

        //Get the y coordinate from whatever wavetype we are using
        public float GetWaveYPos(Vector3 position, float timeSinceStart)
        {
            if (isMoving)
            {
                var height =WaveTypes.SinXWave(position, speed, scale, waveDistance, 0, 0, timeSinceStart);
                //height -= WaveTypes.SinXWave(0, speed, scale, waveDistance, noiseStrength, noiseWalk, timeSinceStart);
                return height;
            }
            else
            {
                return 0f;
            }

        }

        //Find the distance from a vertice to water
        //Make sure the position is in global coordinates
        //Positive if above water
        //Negative if below water
        public float DistanceToWater(Vector3 position, float timeSinceStart)
        {
            float waterHeight = GetWaveYPos(position, timeSinceStart);

            float distanceToWater = position.y - waterHeight;

            return distanceToWater;
        }
    }
}
