using UnityEngine;

namespace Waves.WaveOcean
{
    public class WaveBuoyancy : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody Rigidbody;

        public bool engageBuoyancy = true;
        //public float activationRange = 500.0f;
        //public bool inheritForce = false;
        public float buoyancyOffset = 1.3f;
        public float buoyancyStrength = 1.0f;
        //public float forceHeightFactor = 0.0f;

        private float surfaceRange = 0.2f;

        private float buoyancyFactor;
        private float forceMod;
        [SerializeField]
        private float surfaceLevel = 0.0f;
        private float buoyancy = 0.0f;
        private float displace;
        private float maxVerticalSpeed = 5.0f;
        private float modTime = 0.0f;
        [SerializeField]
        private bool isOver = false;
        [SerializeField]
        private bool isUnderwater = false;
        [SerializeField]
        private float underwaterLevel = 0;
        // Use this for initialization
        void Start ()
        {
            if (Rigidbody == null)
                Rigidbody = GetComponent<Rigidbody>();
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        void FixedUpdate()
        {
            CalcForce();

             displace = Mathf.Clamp(surfaceLevel - (transform.position.y + buoyancyOffset - 0.5f), 0.0f, 5.0f);
            maxVerticalSpeed = displace;
            buoyancy = 1 + (displace * buoyancyStrength);
        }

        void CalcForce()
        {
            //check activations
            //var performHeight = true;

            var pos = transform.position;
            
            
            //Debug.Log("Dif Pos " + dif + " ," + pos);
            // Get all height variables from Suimono Module object
            //heightValues = WaterManager.WaterModule.SuimonoGetHeightAll(WaterManager.WaterModule.mainCamera.transform.position + dif);

            var height = WaterController.current.DistanceToWater(pos, Time.time);
            var waveHeight = WaterController.current.GetWaveYPos(transform.position, Time.time);

            isOver = height > waveHeight;
            //objectDepth = heightValues[3];
            surfaceLevel = waveHeight;
            //forceAngles = WaterManager.WaterModule.SuimonoConvertAngleToDegrees(heightValues[6]);
            //forceSpeed = heightValues[7] * 0.1f;

                //    var debugdata = "";
                //    for (int cnt = 0; cnt < heightValues.Length; cnt++)
                //    {
                //        debugdata += heightValues[cnt] + ", ";
                //    }
            
                //Debug.Log(debugdata);
            

            //clamp variables
            //forceHeightFactor = Mathf.Clamp01(forceHeightFactor);

            //Reset values
            isUnderwater = false;
            underwaterLevel = 0f;

            //calculate scaling
            var testObjectHeight = (pos.y + buoyancyOffset - 0.5f);

            waveHeight = surfaceLevel;
            if (testObjectHeight < waveHeight)
            {
                isUnderwater = true;
            }
            underwaterLevel = waveHeight - testObjectHeight;


            //set buoyancy

            if (engageBuoyancy && !isOver)
            {
                if (Rigidbody && !Rigidbody.isKinematic)
                {

                    buoyancyFactor = 10.0f;

                    if (isUnderwater)
                    {

                        if (testObjectHeight < waveHeight - surfaceRange)
                        {

                            // add vertical force to buoyancy while underwater
                            forceMod = (buoyancyFactor * (buoyancy * Rigidbody.mass) * (underwaterLevel) * (isUnderwater ? 1f : 0f));
                            if (Rigidbody.velocity.y < maxVerticalSpeed)
                            {
                                var force = new Vector3(0f, 1f, 0f) * forceMod;
                                Debug.Log("Force: " + force);
                                Rigidbody.AddForceAtPosition(force, pos);
                            }
                            modTime = 0f;

                        }
                        else
                        {

                            // slow down vertical velocity as it reaches water surface or wave zenith
                            modTime = (pos.y + buoyancyOffset - 0.5f) / (waveHeight + Random.Range(0f, 0.25f) * (isUnderwater ? 1f : 0f));
                            if (Rigidbody.velocity.y > 0f)
                            {
                                var vel =new Vector3(
                                Rigidbody.velocity.x,
                                Mathf.SmoothStep(Rigidbody.velocity.y, 0f, modTime),
                                Rigidbody.velocity.z);
                                Debug.Log("velocity: " + vel);

                                Rigidbody.velocity = vel;
                            }
                        }


                    }

                }
            }
            
        }
    }
}
