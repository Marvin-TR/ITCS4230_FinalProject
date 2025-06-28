using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currHealth;
    private float timer = 0;

    [SerializeField]public HealthBar healthBar;
    [SerializeField] public GameObject leftArm;
    [SerializeField] public GameObject bottomLeftArm;
    [SerializeField] public GameObject rightArm;
    [SerializeField] public GameObject bottomRightArm;

    [SerializeField] public GameObject gameOverScreen;

    [SerializeField] public GameObject thePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        bottomLeftArm.SetActive(false);
        bottomRightArm.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(currHealth);
        timer += Time.deltaTime;
        if (currHealth == maxHealth*.75) 
        {

            bottomLeftArm.SetActive(true);
            bottomRightArm.SetActive(true);
        }

        if (currHealth == maxHealth/2) 
        {


            leftArm.GetComponent<EnemyShoot>().rateOfFire = (float).4;
            rightArm.GetComponent<EnemyShoot>().rateOfFire = (float).4;
            bottomLeftArm.GetComponent<EnemyShoot>().rateOfFire = (float).4;
            bottomRightArm.GetComponent<EnemyShoot>().rateOfFire = (float).4;
        }

        if (currHealth == 0) 
        {
            Debug.Log("boss is defeated");
            bossDefeated();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet(Clone)")
        {
            takeDamage(5);
        }
    }

    void bossDefeated() 
    {
        int hitCount = thePlayer.GetComponent<PlayerMovement>().getHitCount();
        gameOverScreen.GetComponent<GameOver>().callGameOver(hitCount, timer);
        gameOverScreen.SetActive(true);
        leftArm.SetActive(false);
        rightArm.SetActive(false);
        bottomLeftArm.SetActive(false);
        bottomRightArm.SetActive(false);

        thePlayer.SetActive(false);
    }

    public void resetEverything() 
    {
        currHealth = maxHealth;
        timer = 0;

        leftArm.SetActive(true);
        rightArm.SetActive(true);
        bottomLeftArm.SetActive(false);
        bottomRightArm.SetActive(false);

        leftArm.GetComponent<EnemyShoot>().rateOfFire = 1;
        rightArm.GetComponent<EnemyShoot>().rateOfFire = 1;
        bottomLeftArm.GetComponent<EnemyShoot>().rateOfFire = 1;
        bottomRightArm.GetComponent<EnemyShoot>().rateOfFire = 1;

        thePlayer.SetActive(true);

        thePlayer.GetComponent<PlayerMovement>().resetEverything();
        gameOverScreen.GetComponent<GameOver>().restart();

    }

    void takeDamage(int dmg) 
    {
        currHealth -= dmg;
    }
}
