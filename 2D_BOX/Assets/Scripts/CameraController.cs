using UnityEngine;
using System.Collections;


    public class CameraController : MonoBehaviour
    {

        public GameObject target;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);
        }
    }
