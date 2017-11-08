using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField]
    private float arrivalTime = 300;
    
    private new Rigidbody rigidbody;
    private State currentState;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void CallHelicopter()
    {
        if (currentState == State.AWAIT)
        {
            currentState = State.IN_TRANSIT;
            
            transform.LookAt(GameManager.Instance.Player.Flare.transform);
            Vector3 rotationEulerAngles = transform.rotation.eulerAngles;
            rotationEulerAngles.x = 0;
            rotationEulerAngles.z = 0;
            transform.rotation = Quaternion.Euler(rotationEulerAngles);

            rigidbody.velocity = transform.forward * 50;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == State.IN_TRANSIT && other.GetComponent<ClearArea>())
        {
            currentState = State.LANDING;
            rigidbody.velocity = new Vector3(0, -30, 0);
        }

        if (currentState == State.LANDING && other.name.Equals("Flare"))
        {
            currentState = State.LANDED;
            rigidbody.velocity = Vector3.zero;
        }

        if (currentState == State.LANDED && other.GetComponent<Player>())
        {
            currentState = State.EVACUATING;
            /* todo    - move helicopter
             * @author - Артур
             * @date   - 07.11.2017
             * @time   - 16:54
            */   
            GameManager.Instance.UIManager.PlayerRescued();
        }
    }

    private enum State
    {
        AWAIT,
        IN_TRANSIT,
        LANDING,
        LANDED,
        EVACUATING
    }
}