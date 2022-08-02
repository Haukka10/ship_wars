using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class MovementPlayer : MonoBehaviour
    {
        [Header("SuS")]
        public float Speed = 3;

        [SerializeField]
        private CharacterController CharacterController;

        [HideInInspector]
        public Vector3 move;
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            move = transform.right * x + transform.forward * z;

            gameObject.transform.localPosition = new Vector3(move.x, move.y, move.z);

            CharacterController.Move(move * Speed * Time.deltaTime);
        }
    }
}
