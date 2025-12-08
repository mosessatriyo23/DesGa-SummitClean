using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public sealed class CharacterController : MonoBehaviour
{
    #region Constants

    private static readonly int ANIM_WALKING = Animator.StringToHash("Walk");
    private static readonly int ANIM_DIRECTION = Animator.StringToHash("Direction");

    #endregion

    #region Inspector

    [Header("Movement Settings")]
    [Min(0.1f)]
    [SerializeField]
    private float walkSpeed = 2f; // Kecepatan jalan santai

    [Min(0.1f)]
    [SerializeField]
    private float runSpeed = 5f; // Kecepatan lari (lebih cepat)

    #endregion

    #region Fields

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        int? direction = null;
        Vector2 inputVector = Vector2.zero;

        // 1. Deteksi Input Arah
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 2;
            inputVector = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = 0;
            inputVector = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            inputVector = new Vector2(1, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 3;
            inputVector = new Vector2(-1, 0);
        }

        // 2. Logika Lari (Shift + Stamina > 0)
        // Cek apakah tombol Shift ditekan DAN Stamina masih ada
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && StaminaManager.instance.currentStamina > 0;

        // 3. Tentukan Kecepatan Akhir
        // Jika sedang lari pakai runSpeed, jika tidak pakai walkSpeed
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // 4. Gerakkan Karakter
        _rigidbody.velocity = inputVector * currentSpeed;

        // 5. Update Animasi
        _animator.SetBool(ANIM_WALKING, direction.HasValue);

        if (direction.HasValue)
            _animator.SetInteger(ANIM_DIRECTION, direction.Value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Trash trash = collision.GetComponent<Trash>();

        if (trash != null && !trash.collected)
        {
            trash.collected = true;
            TrashManager.instance.AddTrash();
            Destroy(collision.gameObject);
        }
    }

    #endregion
}