using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    [SerializeField] private VariableJoystick _variableJoystick;
    private bool obstacletrig;
    private float goBackTimer = 0.5f;
    [SerializeField] private float playerSpeed = 5 ;
    private Vector3 playerPosition;
    private int health=100;

    private void Awake()
    {
        playerSpeed = PlayerPrefs.HasKey("PlayerSpeed")?(PlayerPrefs.GetFloat("PlayerSpeed")):5;
    }

    void FixedUpdate()
    {
        playerPosition = transform.position;
        playerPosition += Vector3.right * (_variableJoystick.Horizontal * Time.fixedDeltaTime * 0.1f * Screen.dpi);
        if (obstacletrig)
        {
            goBackTimer -= Time.fixedDeltaTime;
            playerPosition += Vector3.back * playerSpeed*Time.fixedDeltaTime; // karakteri geri sektirme 
            if (goBackTimer <=0)
            {
                obstacletrig = false;
            }
        }
        else
        {
            playerPosition += Vector3.forward * playerSpeed* Time.fixedDeltaTime; // karakteri ileri götürmek için
        }

        var x =Math.Clamp(playerPosition.x, -4f, 4f);
        playerPosition.x = x;
        transform.position = playerPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            goBackTimer = 0.5f;
            obstacletrig = true;
            health -= 10;
            if (health <= 0)
            {
                health = 0;
                UIManager.Instance.GameOver();
                playerSpeed = 0;
            }
            UIManager.Instance.SetHealthBar(health/100f);
        }

        else if(other.CompareTag("Gate"))
        {
            var gate = other.GetComponent<GateScript>();
            UIManager.Instance.MoneyValueProp += gate.GateAmount;
            gate.CloseGateCollider();
            
        }

        else if(other.CompareTag("Finish"))
        {
           
            _variableJoystick.gameObject.SetActive(false);
            UIManager.Instance.OpenEndGamePanel();
            var collectCount = UIManager.Instance.MoneyValueProp;
            playerSpeed += collectCount * 0.1f;
            UIManager.Instance.SpeedText(playerSpeed); 
            PlayerPrefs.SetFloat("PlayerSpeed",(playerSpeed));
            PlayerPrefs.Save();
            playerSpeed = 0;
        }
        
    }
    
}
