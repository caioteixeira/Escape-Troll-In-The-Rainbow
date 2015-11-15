using UnityEngine;
using System.Collections;

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace EarthTroll.Player
{
	[RequireComponent(typeof (Rigidbody))]
	[RequireComponent(typeof (CapsuleCollider))]
	public class Player : MonoBehaviour
	{	
		public GameManager gm;
		public Camera cam;
		public bool move = true;
		public int speed = 500;

		private Rigidbody m_RigidBody;
		private CapsuleCollider m_Capsule;

		private float maxZPosition;
		private float minZPosition;
		private float timeToMove = 0;

        public GameObject projectile;
		
		public Vector3 Velocity
		{
			get { return m_RigidBody.velocity; }
		}
		
		private void Start()
		{
			m_RigidBody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();

			maxZPosition = transform.position.z + 3;
			minZPosition = transform.position.z - 3;

			StartCoroutine(Initialize());
		}

		IEnumerator Initialize() {
			move = false;
			yield return new WaitForSeconds(2.5f);
			move = true;
		}

		private void Update()
		{
			Vector3 pos = transform.position;
			float input = Input.GetAxisRaw ("Horizontal");

			if (Time.time > timeToMove) {
				if (input == -1) {
					float posZ = pos.z + 3 > maxZPosition ? maxZPosition : pos.z + 3;
					transform.position = new Vector3 (pos.x, pos.y, posZ);
				} else if (input == 1) {
					float posZ = pos.z - 3 < minZPosition ? minZPosition : pos.z - 3;
					transform.position = new Vector3 (pos.x, pos.y, posZ);
				} else if (Input.GetButton ("Fire1")) {
					FireProjectile ();
				}

				timeToMove = Time.time + 0.1f; //2 is the cooldown			}
			}
		
		}
		float timeSinceFire = 0;
		float fireRate = 0;
		private void FixedUpdate()
		{
			
			if(move) m_RigidBody.velocity = new Vector3(speed * Time.fixedDeltaTime, 0, 0);
		}
		
		
		private Vector2 GetInput()
		{
			
			Vector2 input = new Vector2
			{
				x = CrossPlatformInputManager.GetAxis("Horizontal"),
				y = CrossPlatformInputManager.GetAxis("Vertical")
			};
			return input;
		}

		
		public void OnTriggerEnter(Collider col)
		{
			if(col.tag == "Obstacle" || col.tag == "Cat"){
				gm.StartCoroutine(gm.GameOver());
			}
		}

        public void FireProjectile()
        {
            Instantiate(projectile, transform.position + new Vector3(1.5f, 1.0f), Quaternion.identity);
        }
	}
}