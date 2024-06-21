using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public AudioClip m_FireClip;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 450f;

    private float m_CurrentLaunchForce;
    private bool m_Fired;

    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        AudioSource.PlayClipAtPoint(m_FireClip, m_FireTransform.position);

        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
