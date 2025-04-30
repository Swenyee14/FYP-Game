using UnityEngine;
using UnityEngine.Events;

public class checks : MonoBehaviour
{
	[SerializeField] private float JumpPower = 400f;                                   
	[Range(0, .1f)] [SerializeField] private float MoveSmooth = .05f;  
	[SerializeField] private bool AirMovement = false;                         
	[SerializeField] private LayerMask whatIsGround;                          
	[SerializeField] private Transform groundCheck;                                                                  

	const float groundRadius = .2f; 
	private bool grounded;            
	private Rigidbody2D m_Rigidbody2D;
	private bool direction = true;  
	private Vector3 speed = Vector3.zero;
	public UnityEvent landed;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (landed == null)
			landed = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
				if (!wasGrounded)
					landed.Invoke();
			}
		}
	}

	public void Move(float move, bool jump)
	{
		if (grounded || AirMovement)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref speed, MoveSmooth);
		
			if (move > 0 && !direction)
			{
				Flip();
			}
			
			else if (move < 0 && direction)
			{
				Flip();
			}
		}
		
		if (grounded && jump)
		{
			grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, JumpPower));
		}
	}

	private void Flip()
	{
		direction = !direction;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}