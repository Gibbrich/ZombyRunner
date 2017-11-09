using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Helicopter Helicopter { get; private set; }

    public Player Player { get; private set; }

    public HealthDisplay HealthDisplay { get; private set; }

    public UIManager UIManager { get; private set; }
    
    [SerializeField]
    private GameObject deathExplosionParticlesPrefab;

    private int zombieCount;
    public int ZombieCount
    {
        get { return zombieCount; }

        set
        {
            zombieCount = value;
            UIManager.UpdateZombieKillCountDisplay();
        }
    }

    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Helicopter = FindObjectOfType<Helicopter>();
        HealthDisplay = FindObjectOfType<HealthDisplay>();
        UIManager = FindObjectOfType<UIManager>();
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    /* todo    - move to ZombieHealth script
     * @author - Артур
     * @date   - 09.11.2017
     * @time   - 23:11
    */
    
    public void PlayZombieDeathExplosion(Vector3 position)
    {
        GameObject explosion = Instantiate(deathExplosionParticlesPrefab, position, Quaternion.identity);
//        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, 3f);
    }
}