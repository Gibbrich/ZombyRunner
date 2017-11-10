using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField]
    private float arrivalTime = 300;
    public float ArrivalTime
    {
        get { return arrivalTime; }
    }

    private float calledTime = -1f;
    public float CalledTime
    {
        get { return calledTime; }
        private set { calledTime = value; }
    }

    private State currentState = State.AWAIT;
    public State CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }

    private new Rigidbody rigidbody;
    

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void CallHelicopter()
    {
        if (CurrentState == State.AWAIT)
        {
            CalledTime = Time.time;
            
            CurrentState = State.IN_TRANSIT;
            
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
        if (CurrentState == State.IN_TRANSIT && other.GetComponent<ClearArea>())
        {
            CurrentState = State.LANDING;
            rigidbody.velocity = new Vector3(0, -30, 0);
        }

        if (CurrentState == State.LANDING && other.GetComponent<Terrain>())
        {
            CurrentState = State.LANDED;
            rigidbody.velocity = Vector3.zero;
        }

        if (CurrentState == State.LANDED && other.GetComponent<Player>())
        {
            CurrentState = State.EVACUATING;
            /* todo    - move helicopter
             * @author - Артур
             * @date   - 07.11.2017
             * @time   - 16:54
            */   
            GameManager.Instance.UIManager.PlayerRescued();
        }
    }

    public enum State
    {
        AWAIT,
        IN_TRANSIT,
        LANDING,
        LANDED,
        EVACUATING
    }
}