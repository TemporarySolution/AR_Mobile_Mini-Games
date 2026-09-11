using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public float FIRERATE = 4;
    public float PROJSPEED = 1;
    public float DAMAGE = 1;
    public float GUNLEVEL = 1;
    public float MONEY = 10;
    public GameObject PROJECTILE = null;
    public GameObject TARGET = null;
    public GameObject UI = null;
    public GameObject MONUI = null;

    // Start is called before the first frame update
    void Start()
    {
        if (PROJECTILE.name == "Missle")
        {
            StartCoroutine(Shoot());
        }
        else { StartCoroutine(Spawn()); }

        DAMAGE = GUNLEVEL * 2 - 1;

}

    // Update is called once per frame
    void Update()
    {
        if (MONUI != null) { MONUI.GetComponent<UnityEngine.UI.Text>().text = ("" + MONEY); }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            if (TARGET)
            {
                yield return new WaitForSeconds(FIRERATE - GUNLEVEL);
                GameObject missle = Instantiate(PROJECTILE, transform.position + new Vector3(0f,0.3f,0f), transform.rotation);
                missle.GetComponent<MoveTo>().SPEED = PROJSPEED + GUNLEVEL;
                missle.GetComponent<MoveTo>().Target = TARGET;
            }
            else
            {
                yield return new WaitForSeconds(FIRERATE - GUNLEVEL);
            }
        }
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            if (TARGET)
            {
                yield return new WaitForSeconds(FIRERATE);
                GameObject EnemyS = Instantiate(PROJECTILE, transform.position + new Vector3(0f, 0f, 0f), transform.rotation);
                EnemyS.GetComponent<Enemy>().SPEED = PROJSPEED;
            }
            else
            {
                yield return new WaitForSeconds(FIRERATE);
            }
        }
    }
    public void UpgradeGun()
    {
        if ((MONEY >= 15*GUNLEVEL) && (GUNLEVEL !=3))
        {
            MONEY -= 15*GUNLEVEL;
            GUNLEVEL++;
            if (GUNLEVEL == 2) 
            {
                gameObject.transform.Find("Turret_RocketTower_L01").gameObject.SetActive(false);
                gameObject.transform.Find("Turret_RocketTower_L02").gameObject.SetActive(true);
                UI.GetComponent<UnityEngine.UI.Text>().text = ("”ÎÛ˜¯ËÚ¸ ‰Ó 3 Á‡ " + 15 * GUNLEVEL);
                DAMAGE = GUNLEVEL * 2 - 1;
            }
            if (GUNLEVEL == 3)
            {
                gameObject.transform.Find("Turret_RocketTower_L02").gameObject.SetActive(false);
                gameObject.transform.Find("Turret_RocketTower_L03").gameObject.SetActive(true);
                UI.GetComponent<UnityEngine.UI.Text>().text = ("ƒŒ—“»√Õ”“ Ã¿ —»Ã¿À‹Õ€… ”–Œ¬≈Õ‹");
                DAMAGE = GUNLEVEL * 2 - 1;
            }
        }
    }
}
