using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField]
    public bool isCurrent;
    public int damage;

    protected Player player;

    private void Start()
    {

    }

    protected void takeWeapon()
    {
        if (!isCurrent && Vector2.Distance(player.transform.position, transform.position) < 3)
        {
            if ((Input.GetKeyDown(KeyCode.E) && player.canChangeWeapon) || player.weapon == null)
            {
                if (player.weapon != null)
                {
                    player.weapon.GetComponent<WeaponBase>().isCurrent = false;
                    player.weapon.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    player.weapon.transform.localScale = new Vector3(1, 1, 0);
                    player.weapon.transform.parent = player.transform.parent.parent;
                }
                player.weapon = gameObject;
                player.weapon.transform.parent = player.transform;
                player.weapon.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                isCurrent = true;
                GameManager.Instance.AudioManager.Play("PickupGun");
                StartCoroutine(player.waitForChangeWeapon());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.UiManager.ShowHint("Pick up (E)");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.UiManager.ShowHint("");
        }
    }
}
