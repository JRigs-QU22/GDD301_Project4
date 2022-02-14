using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	Vector3 cameraInitialPosition;
	public float shakeMagnetude, shakeTime;
	public Camera mainCamera;
    public float IncreaseTimer = 3.0f;
    public float Countdown;

    public void Start()
    {
        shakeMagnetude = 0;
        shakeTime = 0;
        Countdown = IncreaseTimer;
    }
    public void Update()
    {
        Countdown -= Time.deltaTime;
        if (Countdown < 0)
        {
            shakeMagnetude = shakeMagnetude + 0.01f;
            shakeTime = shakeTime + 0.01f;
            Countdown = 3.0f;
        }
        StartCameraShaking();

        if(this.enabled == false)
        {
            shakeMagnetude = 0f;
            shakeTime = 0f;
            Countdown = 3.0f;
        } 
        
    }
    public void ShakeIt()
	{
		cameraInitialPosition = mainCamera.transform.position;
		InvokeRepeating ("StartCameraShaking", 0f, 0.005f);
		Invoke ("StopCameraShaking", shakeTime);
	}

	void StartCameraShaking()
	{
		float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
		cameraIntermadiatePosition.x += cameraShakingOffsetX;
		cameraIntermadiatePosition.y += cameraShakingOffsetY;
		mainCamera.transform.position = cameraIntermadiatePosition;
	}

	void StopCameraShaking()
	{
		CancelInvoke ("StartCameraShaking");
		mainCamera.transform.position = cameraInitialPosition;
	}

}
