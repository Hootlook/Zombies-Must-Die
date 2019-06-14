/************************************
 *  Class made by Jan VERMEULEN 
 ************************************/

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] float Speed = 100;
    [SerializeField] float Life = 1000;

    public void TakeDamage(float damage)
    {
        Life -= damage;
    }
    private void Awake()
    {
       characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * -1;
        var vertical = Input.GetAxis("Vertical") * -1;
        var movement = new Vector3(horizontal, 0, vertical);
        characterController.SimpleMove(movement * Time.deltaTime * Speed);
    }
}
