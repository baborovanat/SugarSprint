using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    public HealthBar healthBar;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        var playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.currentHealth += 31.68f;//48f;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfBananas += 1;
           // player.TakeDamage(100f);//nove
            Destroy(gameObject);
            StartCoroutine(player.TakeDamageForSeconds(15, 5));

        }
    }
}
