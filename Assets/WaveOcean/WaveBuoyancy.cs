using UnityEngine;

namespace Waves.WaveOcean
{
    [RequireComponent(typeof(Rigidbody))]
    public class WaveBuoyancy : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody Rigidbody;

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
        }

        void CalcForce()
        {

            var waterHeight = WaterController.current.GetWaveYPos(transform.position, Time.time);

            if (transform.position.y >= waterHeight)
            {
                return;
            }


            var vel = Rigidbody.velocity;
            if (vel.y < 0)
            {
                var dif = waterHeight - transform.position.y;
                if (Rigidbody.velocity.y < 0)
                {
                    dif *= 2;
                }

                //vel.y = Mathf.Lerp(vel.y, .1f, Time.fixedDeltaTime);
                //Rigidbody.velocity = vel;
                var force = -Physics.gravity * (Rigidbody.mass * dif);
                Rigidbody.AddForceAtPosition(force, transform.position);
            }
            else
            {
                var pos = transform.position;
                pos.y = waterHeight;
                var lerpedPos = Vector3.Lerp(pos, transform.position, Time.fixedDeltaTime * 10);
                Rigidbody.MovePosition(lerpedPos);
            }

            

            //var force = -Physics.gravity * (Rigidbody.mass + dif);
            //Rigidbody.AddForceAtPosition(force, transform.position);
            //Debug.Log("Wave Dif:" + dif + ", Force: " + force);
            
        }
    }
}
