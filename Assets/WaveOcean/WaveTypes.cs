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

            y = ((Mathf.Sin(x * 1.0f + timeSinceStart * 1.0f * speed) + Mathf.Sin(x * 2.3f + timeSinceStart * 1.5f * speed) + Mathf.Sin(x * 3.3f + timeSinceStart * 0.4f * speed)) / waveDistance) *scale;
            y +=((Mathf.Sin(z * 1.0f + timeSinceStart * 1.0f * speed) + Mathf.Sin(z * 2.3f + timeSinceStart * 1.5f * speed) + Mathf.Sin(z * 3.3f + timeSinceStart * 0.4f * speed)) / waveDistance) *scale;
            //Add noise to make it more realistic
            //y += Mathf.PerlinNoise(x + noiseWalk, y + Mathf.Sin(timeSinceStart * 0.1f)) * noiseStrength;



            return y;
	    }
    }
}
