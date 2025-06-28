using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject aBullet;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public float rateOfFire = 2;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > rateOfFire) 
        {
            timer = 0;
            shoot();
        }
    }

    void changeRateOfFire(int ROF) 
    {
        rateOfFire = ROF;
    }


    void shoot() 
    {
        Instantiate(aBullet, firingPoint.position, Quaternion.identity);
    }


}
