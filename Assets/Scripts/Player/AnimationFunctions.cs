using UnityEngine.UI;
using UnityEngine;

public class AnimationFunctions : MonoBehaviour
{
    public AudioSource MelonTake;
    public AudioSource PfTake;
    public AudioSource JumpSound;
    public AudioSource AttackSound;
    public AudioSource VaseSound;
    public AudioSource GameSound;
    public AudioSource GameLoseSound;
    public AudioSource WaterSound;

    public GameObject LoseMenu;
    public GameObject PinkFloydAttack;
    public Button AttackButton;

    private Rigidbody2D RbOfHero;
    private Animator AnimOfPlayer;
    private BoxCollider2D ColliderOfHero;

    private float JumpForse = 0;
    private bool YouHavePF = false;
    void Start()
    {
        GameSound.Play();
        ColliderOfHero = GetComponent<BoxCollider2D>();
        RbOfHero = GetComponent<Rigidbody2D>();
        AnimOfPlayer = GetComponent<Animator>();
    }
    void Update()
    {
        if (RbOfHero.velocity.y == 0)
        {
            AnimOfPlayer.SetBool("OnTheEarth", true);
            AnimOfPlayer.SetBool("Down", false);
            AnimOfPlayer.SetBool("Up", false);
        }
        else if (RbOfHero.velocity.y < 0)
        {
            AnimOfPlayer.SetBool("OnTheEarth", false);
            AnimOfPlayer.SetBool("Down", true);
            AnimOfPlayer.SetBool("Up", false);
        }
        else if (RbOfHero.velocity.y > 0)
        {
            AnimOfPlayer.SetBool("OnTheEarth", false);
            AnimOfPlayer.SetBool("Down", false);
            AnimOfPlayer.SetBool("Up", true);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.tag = "NotActive";
            JumpForse = 0;
            YouHavePF = false;
            AttackButton.interactable = false;
            StaticParams.GameActive = false;
            AnimOfPlayer.SetBool("Swim", true);
            AnimOfPlayer.SetBool("Attack", false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PinkFloydLoot"))
        {
            PfTake.Play();
            YouHavePF = true;
            AttackButton.interactable = true;
        }
        else if (collision.gameObject.CompareTag("Melon"))
        {
            MelonTake.Play();
            StaticParams.MelonCounter += 1;
        }
        else if (collision.gameObject.CompareTag("Vase"))
        {
            VaseSound.Play();
        }
        else if (collision.gameObject.CompareTag("Robot"))
        {
            GameSound.Stop();
            GameLoseSound.Play();
            AttackSound.Play();
            StaticParams.GameActive = false;
            JumpForse = 0;
            YouHavePF = false;
            AttackButton.interactable = false;
            AnimOfPlayer.SetBool("Embrace", true);
            AnimOfPlayer.SetBool("Attack", false);
        }
        else if (collision.gameObject.CompareTag("Pencil"))
        {
            GameSound.Stop();
            GameLoseSound.Play();
            AttackSound.Play();
            ColliderOfHero.enabled = false;
            AnimOfPlayer.SetBool("PencilCollision", true);
            AnimOfPlayer.SetBool("Attack", false);
            YouHavePF = false;
            AttackButton.interactable = false;
            StaticParams.GameActive = false;
            JumpForse = 0;
            Fly();
        }
        else if (collision.gameObject.CompareTag("Bird"))
        {
            GameSound.Stop();
            GameLoseSound.Play();
            AttackSound.Play();
            ColliderOfHero.enabled = false;
            AnimOfPlayer.SetBool("FlyWithBird", true);
            AnimOfPlayer.SetBool("Attack", false);
            YouHavePF = false;
            AttackButton.interactable = false;
            StaticParams.GameActive = false;
            JumpForse = 0;
            Fly();
        }
    }
    public void StartGame() //Start Animation
    {
        JumpForse = 48;
        StaticParams.GameActive = true;
        AnimOfPlayer.SetBool("StartGame", true);
    }
    public void Jump()
    {
        if ((RbOfHero.velocity.y == 0) && (StaticParams.GameActive == true))
        {
            JumpSound.Play();
            RbOfHero.AddForce(Vector2.up * JumpForse, ForceMode2D.Impulse);
        }
    }
    public void Attack()
    {
        if (YouHavePF)
        {
            AttackSound.Play();
            AnimOfPlayer.SetBool("Attack", true);
            Instantiate(PinkFloydAttack, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, 0));
            AttackButton.interactable = false;
            YouHavePF = false;
        }
    }
    public void StopAttackAnim()
    {
        AnimOfPlayer.SetBool("Attack", false);
    }
    public void Fly()
    {
        RbOfHero.AddForce(Vector2.up * 70, ForceMode2D.Impulse);
    }
    public void GravityIsZero()
    {
        RbOfHero.bodyType = RigidbodyType2D.Static;
    }
    public void FloyAfterSwimAnim()
    {
        ColliderOfHero.enabled = false;
        AnimOfPlayer.SetBool("Swim", false);
        Fly();
    }
    public void Lose() //You are caught
    {
        StaticParams.PlayerLose = true;
        LoseMenu.active = true;
    }
    public void WaterSoundA()
    {
        WaterSound.Play();
    }
    public void SoundLose()
    {
        GameSound.Stop();
        GameLoseSound.Play();
    }
}
