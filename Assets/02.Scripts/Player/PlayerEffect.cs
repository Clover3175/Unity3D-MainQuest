using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    //private float coolDown = 1.0f;  
    //private float nextTime = -1.0f;

    [SerializeField] private ParticleSystem ps;

    public ParticleSystem Ps
    {
        get { return ps; }
        set { ps = value; }
    }

    public void PlayEffect()
    {
        //if (Time.time < nextTime) return;

        if (particle != null)
        {
            ps = Instantiate(particle, transform.position, Quaternion.identity);
            ps.Stop();
            ps.Play();

            //nextTime = Time.time + coolDown; //현 시간에서 coolDown시간 후 재생가능
        }
    }
}
