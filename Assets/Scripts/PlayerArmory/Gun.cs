using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _mazzleFlash;
    [SerializeField] private AudioSource _shotAudio;
    [SerializeField] private float _speed;
    [SerializeField] private float _shotPeriod;
    [SerializeField] private ParticleSystem _smoke;

    private float _timer;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (Input.GetMouseButton(0) && _timer > _shotPeriod)
        {
            _timer = 0;

            Shot();
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _spawner.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _speed / Time.timeScale;

        _mazzleFlash.SetActive(true);
        Invoke(nameof(DisableMuzzleFlash), 0.12f);

        _shotAudio.Play();
        _smoke.Play();
    }

    private void DisableMuzzleFlash()
    {
        _mazzleFlash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void DisActivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int count)
    {
    }
}