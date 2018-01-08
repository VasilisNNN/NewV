using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
	private const float SkinWidth = .02f;
	private const int TotalHorizontalRays = 8;
	private const int TotalVerticalRays = 4;

	//private static readonly float SlopeLimitTangant = Mathf.Tan(75f * Mathf.Deg2Rad);

	public LayerMask PlatformMask;
	public ControllerParameters2D DefaultParameters;

	public ControllerState2D State { get; private set; }
	public Vector2 Velocity { get { return _velocity; } }
	public bool HandleCollisions { get; set; }
	public ControllerParameters2D Parameters { get { return _overrideParameters ?? DefaultParameters; } }
	public GameObject StandingOn { get; private set; }
	public Vector3 PlatformVelocity { get; private set; }


	private Vector2 _velocity;
	private Transform _transform;
	private Vector3 _localScale;
	private BoxCollider2D _boxCollider;
	private ControllerParameters2D _overrideParameters;

	private GameObject _lastStandingOn;


	private Vector3
		_raycastTopLeft,
		_raycastBottomRight,
		_raycastBottomLeft;

	private float
		_verticalDistanceBetweenRays,
		_horizontalDistanceBetweenRays;

	public void Awake()
	{
		HandleCollisions = true;
		State = new ControllerState2D();
		_transform = transform;
		_localScale = transform.localScale;
		_boxCollider = GetComponent<BoxCollider2D>();

		var colliderWidth = _boxCollider.size.x * Mathf.Abs(transform.localScale.x) - (2 * SkinWidth);
		_horizontalDistanceBetweenRays = colliderWidth / (TotalVerticalRays - 1);

		var colliderHeight = _boxCollider.size.y * Mathf.Abs(transform.localScale.y) - (2 * SkinWidth);
		_verticalDistanceBetweenRays = colliderHeight / (TotalHorizontalRays - 1);
	}

	public void AddForce(Vector2 force)
	{
		_velocity = force;
	}

	public void SetForce(Vector2 force)
	{
		_velocity += force;
	}

	public void SetHorizontalForce(float x)
	{
		_velocity.x = x;
	}

	public void SetVerticalForce(float y)
	{
		_velocity.y = y;
	}


	public void LateUpdate()
	{

		//_velocity.y += Parameters.Gravity * Time.deltaTime;
		Move(Velocity * Time.deltaTime);
	}

	private void Move(Vector2 deltaMovement)
	{
	
		State.Reset();

		if (HandleCollisions)
		{
		//	HandlePlatforms();
			CalculateRayOrigins();

			/*if (deltaMovement.y < 0)
				HandleVerticalSlope(ref deltaMovement);*/

			if (Mathf.Abs(deltaMovement.x) > .001f)
			MoveHorizontally(ref deltaMovement);

			MoveVertically(ref deltaMovement);

			CorrectHorizontalPlacement(ref deltaMovement, true);
			CorrectHorizontalPlacement(ref deltaMovement, false);
		}

		_transform.Translate(deltaMovement, Space.World);

		if (Time.deltaTime > 0)
			_velocity = deltaMovement / Time.deltaTime;

		_velocity.x = Mathf.Min(_velocity.x, Parameters.MaxVelocity.x);
		_velocity.y = Mathf.Min(_velocity.y, Parameters.MaxVelocity.y);

	//	if (State.IsMovingUpSlope)
		//	_velocity.y = 0;

		/*if (StandingOn != null)
		{
			_activeGlobalPlatformPoint = transform.position;
			_activeLocalPlatformPoint = StandingOn.transform.InverseTransformPoint(transform.position);

		}
		else if (_lastStandingOn != null)
		{
			_lastStandingOn.SendMessage("ControllerExit2D", this, SendMessageOptions.DontRequireReceiver);
			_lastStandingOn = null;
		}*/
	}



	private void CorrectHorizontalPlacement(ref Vector2 deltaMovement, bool isRight)
	{
		var halfWidth = (_boxCollider.size.x * _localScale.x) / 2f;
		var rayOrigin = isRight ? _raycastBottomRight : _raycastBottomLeft;

		if (isRight)
			rayOrigin.x -= (halfWidth - SkinWidth);
		else
			rayOrigin.x += (halfWidth - SkinWidth);

		var rayDirection = isRight ? Vector2.right : -Vector2.right;
		//var offset = 0f;

		for (var i = 1; i < TotalHorizontalRays - 1; i++)
		{
			var rayVector = new Vector2(deltaMovement.x + rayOrigin.x, deltaMovement.y + rayOrigin.y + (i * _verticalDistanceBetweenRays));
			//			Debug.DrawRay(rayVector, rayDirection * halfWidth, isRight ? Color.cyan : Color.magenta);

			var raycastHit = Physics2D.Raycast(rayVector, rayDirection, halfWidth, PlatformMask);
			if (!raycastHit)
				continue;
			else deltaMovement.x = 0;
			//offset = isRight ? ((raycastHit.point.x - _transform.position.x) - halfWidth) : (halfWidth - (_transform.position.x - raycastHit.point.x));
		}

	//	deltaMovement.x += offset;
	}

	private void CalculateRayOrigins()
	{
		var size = new Vector2(_boxCollider.size.x * Mathf.Abs(_localScale.x), _boxCollider.size.y * Mathf.Abs(_localScale.y)) / 2;
		var center = new Vector2(_boxCollider.offset.x * _localScale.x, _boxCollider.offset.y * _localScale.y);

		_raycastTopLeft = _transform.position + new Vector3(center.x - size.x + SkinWidth, center.y + size.y - SkinWidth);
		_raycastBottomRight = _transform.position + new Vector3(center.x + size.x - SkinWidth, center.y - size.y + SkinWidth);
		_raycastBottomLeft = _transform.position + new Vector3(center.x - size.x + SkinWidth, center.y - size.y + SkinWidth);
	}

	private void MoveHorizontally(ref Vector2 deltaMovement)
	{
		var isGoingRight = deltaMovement.x > 0;
		var rayDistance = Mathf.Abs(deltaMovement.x) + SkinWidth;
		var rayDirection = isGoingRight ? Vector2.right : -Vector2.right;
		var rayOrigin = isGoingRight ? _raycastBottomRight : _raycastBottomLeft;

		for (var i = 0; i < TotalHorizontalRays; i++)
		{
			var rayVector = new Vector2(rayOrigin.x, rayOrigin.y + (i * _verticalDistanceBetweenRays));
			//Debug.DrawRay(rayVector, rayDirection * rayDistance, Color.red);

			var rayCastHit = Physics2D.Raycast(rayVector, rayDirection, rayDistance, PlatformMask);
			if (!rayCastHit)
				continue;



			deltaMovement.x = rayCastHit.point.x - rayVector.x;
			rayDistance = Mathf.Abs(deltaMovement.x);

			if (isGoingRight)
			{
				deltaMovement.x -= SkinWidth;
				State.IsCollidingRight = true;
			}
			else
			{
				deltaMovement.x += SkinWidth;
				State.IsCollidingLeft = true;
			}

			if (rayDistance < SkinWidth + .0001f)
				break;
		}
	}

	private void MoveVertically(ref Vector2 deltaMovement)
	{
		var isGoingUp = deltaMovement.y > 0;
		var rayDistance = Mathf.Abs(deltaMovement.y) + SkinWidth;
		var rayDirection = isGoingUp ? Vector2.up : -Vector2.up;
		var rayOrigin = isGoingUp ? _raycastTopLeft : _raycastBottomLeft;

		rayOrigin.x += deltaMovement.x;

		var standingOnDistance = float.MaxValue;
		for (var i = 0; i < TotalVerticalRays; i++)
		{
			var rayVector = new Vector2(rayOrigin.x + (i * _horizontalDistanceBetweenRays), rayOrigin.y);
			//Debug.DrawRay(rayVector, rayDirection * rayDistance, Color.red);

			var raycastHit = Physics2D.Raycast(rayVector, rayDirection, rayDistance, PlatformMask);
			if (!raycastHit)
				continue;

			if (!isGoingUp)
			{
				var verticalDistanceToHit = _transform.position.y - raycastHit.point.y;
				if (verticalDistanceToHit < standingOnDistance)
				{
					standingOnDistance = verticalDistanceToHit;
					StandingOn = raycastHit.collider.gameObject;
				}
			}

			deltaMovement.y = raycastHit.point.y - rayVector.y;
			rayDistance = Mathf.Abs(deltaMovement.y);

			if (isGoingUp)
			{
				deltaMovement.y -= SkinWidth;
				State.IsCollidingAbove = true;
			}
			else
			{
				deltaMovement.y += SkinWidth;
				State.IsCollidingBelow = true;
			}

			if (deltaMovement.y > .0001f)
				State.IsMovingUpSlope = true;

			if (rayDistance < SkinWidth + .0001f)
				break;
		}
	}



	public void OnTriggerEnter2D(Collider2D other)
	{
		var parameters = other.gameObject.GetComponent<ControllerPhsyicsVolume2D>();
		if (parameters == null)
			return;

		_overrideParameters = parameters.Parameters;
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		var parameters = other.gameObject.GetComponent<ControllerPhsyicsVolume2D>();
		if (parameters == null)
			return;

		_overrideParameters = null;
	}
}