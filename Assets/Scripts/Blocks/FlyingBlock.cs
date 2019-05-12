using UnityEngine; 
using System.Collections; 

public class FlyingBlock:MonoBehaviour 
{

	[Range (1, 10)]
	public int speed = 10; 
	public Transform movePoint; 
	public enum Direction 
	{
		LeftRight, 
		UpDown 
	}
	public Direction direct = Direction.UpDown; 

	private Vector2 direction; 
	private Vector2 limits; 
	private Rigidbody2D rb; 



	void Start ()
	{
		rb = GetComponent < Rigidbody2D > (); 

		if (direct == Direction.LeftRight)
{
			direction = Vector2.right; 
			limits = new Vector2 (rb.position.x, rb.position.x + movePoint.position.x); //левая и правая точка
		}else 
        {
			direction = Vector2.up; 
			limits = new Vector2 (rb.position.y, rb.position.y + movePoint.position.y); //нижняя и верхняя точка
		}	
	}
	
	void FixedUpdate()
{

		if (direct == Direction.UpDown)
			if (rb.position.y > limits.y || rb.position.y < limits.x)
				direction =  - direction; 	

		if (direct == Direction.LeftRight)
			if (rb.position.x > limits.y || rb.position.x < limits.x)
				direction =  - direction; 		

		rb.MovePosition (rb.position + (direction * speed) * Time.fixedDeltaTime); 
	}
}
