using UnityEngine;

[RequireComponent(typeof(PlayerVelocity))]
public class PlayerInput : MonoBehaviour
{

	private PlayerVelocity playerVelocity;

	void Start()
	{
		playerVelocity = GetComponent<PlayerVelocity>();
	}

	void Update()
	{
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (FirstLight.instance != null)
        {
			if(FirstLight.instance.readyPlaying)
				playerVelocity.SetDirectionalInput(directionalInput);
		}

        else
        {
			playerVelocity.SetDirectionalInput(directionalInput);
		}

		if (Input.GetButtonDown("Jump"))
		{
			playerVelocity.OnJumpInputDown();
		}
		if (Input.GetButtonUp("Jump"))
		{
			playerVelocity.OnJumpInputUp();
		}
		//if (Input.GetKeyDown(KeyCode.S))
		//{
		//	playerVelocity.OnFallInputDown();
		//}
	}
}
