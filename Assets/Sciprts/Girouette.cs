using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class Girouette : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private WindZone wind;

    [SerializeField] private float windSpeed;

    private Quaternion windRotationTarget;
    
    private Quaternion windLastRotation;
    
    [SerializeField]private float blendTimer;

    [SerializeField]private float timeToNextBlend;

    [SerializeField]private bool isBlending;
    
    [SerializeField]private float windRotationTimer;

    [SerializeField]private float timeToNextWindRotation;
    
    
    
    
    private void Awake()
    {
        if (this.wind ==null)
        {
            this.wind = GetComponent<WindZone>();
        }

        this.blendTimer = 0;
        this.windRotationTimer = 0;

        isBlending = false;

        this.windLastRotation = this.transform.rotation;

        this.timeToNextWindRotation = Random.Range(5, 10);
        this.timeToNextBlend = Random.Range(0.5f, 3);
        this.windRotationTarget= Quaternion.Euler(this.transform.rotation.eulerAngles.x,Random.Range(0, 360),0);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.windRotationTimer +=Time.deltaTime;

        if (this.windRotationTimer>= timeToNextWindRotation)
        {
            this.isBlending = true;
            Debug.Log("is Blending");
            this.windRotationTimer = 0;
            this.timeToNextWindRotation = Random.Range(5, 10);
        }

        if (isBlending)
        {
            this.blendTimer += Time.deltaTime;
            this. transform.rotation = Quaternion.Lerp(windLastRotation, windRotationTarget, (this.blendTimer / timeToNextBlend));

            if ((this.blendTimer / timeToNextBlend)>=1)
            {
                isBlending = false;
                this.blendTimer = 0;
                this.timeToNextBlend = Random.Range(0.5f, 3);
                this.windLastRotation = this.transform.rotation;
                this.windRotationTarget= Quaternion.Euler(this.transform.rotation.eulerAngles.x,Random.Range(0, 360),0);
            }
        }
    }
}
