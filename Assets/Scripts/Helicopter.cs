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
    
    private float landingSpeed = 30f;
    private float landingTreshold = 3f;
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

            Transform flareTransform = GameManager.Instance.Player.Flare.transform;

            // rotate helicopter towards flare 
            Vector3 flarePosition = flareTransform.position;
            flarePosition.y = transform.position.y;            
            transform.LookAt(flarePosition);
            
            // calculate landing time
            float landingTime = (transform.position.y - flareTransform.position.y) / landingSpeed;

            // calculate moving time
            float movingTime = ArrivalTime - landingTime;

            // set moving speed
            rigidbody.velocity = transform.forward * Vector3.Distance(transform.position, flarePosition) / movingTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentState == State.IN_TRANSIT && other.GetComponent<ClearArea>())
        {
            CurrentState = State.LANDING;
            rigidbody.velocity = Vector3.down * landingSpeed;
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