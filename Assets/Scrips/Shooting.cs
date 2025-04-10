using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image waterImage;
    [SerializeField] private float drainSpeed = 0.2f;
    private bool GunEquipped = true;
    private bool shooting;
    private float initialJump = 10f;
    [SerializeField] private float CanisterPercent;
   

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shooting = true;
            initialJump = 10f;
        }
        if (context.canceled)
        {
            shooting = false;
        }
    }

    private void Update()
    {
        CanisterPercent = waterImage.fillAmount;

        if (GunEquipped && shooting)
        {
            waterImage.fillAmount = Mathf.Max(0, waterImage.fillAmount - drainSpeed * Time.deltaTime * initialJump);
            initialJump = 1;
        }
    }



}
