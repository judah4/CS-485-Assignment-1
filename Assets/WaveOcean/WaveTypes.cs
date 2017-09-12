using UnityEngine;

namespace Waves.WaveOcean
{
    public class WaveTypes : MonoBehaviour {

        //Sinus waves
	    public static float SinXWave(
		    Vector3 position, 
            //float x,
		    float speed, 
		    float scale,
		    float waveDistance,
		    float noiseStrength, 
		    float noiseWalk,
            float timeSinceStart) 
	    {
            float x = position.x;
            float y = 0f;
            float z = position.z;

            //Using only x or z will produce straight waves
		    //Using only y will produce an up/down movement
		    //x + y + z rolling waves
		    //x * z produces a moving sea without rolling waves

	        //float waveType = x+z;//z;

            //y += (Mathf.Sin((timeSinceStart * speed + waveType) / waveDistance) * scale;

            y = (SinX(x, 1.0f, 1.0f, speed, waveDistance, timeSinceStart) /*+ Mathf.Sin(x * 2.3f + timeSinceStart * 1.5f * speed)*/ + SinX(x, 3.3f, 0.4f , speed, waveDistance, timeSinceStart)) *scale;
            y += (SinX(z, 2.0f, 1.5f, speed, waveDistance, timeSinceStart) /*+ Mathf.Sin(x * 2.3f + timeSinceStart * 1.5f * speed)*/ + SinX(z, 1.3f, 1f , speed, waveDistance, timeSinceStart)) *scale;
            //Add noise to make it more realistic
            //y += Mathf.PerlinNoise(x + noiseWalk, y + Mathf.Sin(timeSinceStart * 0.1f)) * noiseStrength;



            return y;
	    }

        static float SinX(float x,
            float adjust,
            float timeAdjust,
            float speed,
            float waveDistance,
            float timeSinceStart)
        {
            return Mathf.Sin(x * adjust / waveDistance + timeSinceStart * timeAdjust * speed);
        }
    }
}
