using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage; // �������� ����, ��� �� ���� �� ������������� �� ���� ������������� (���� ������, ������, �������� � �. �.)
    private float _destructionDelay = 2;
    private Rigidbody2D _rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if(collision.tag == "Player" && collision.GetComponentInChildren<CharacterHealth>() != null)
        {
            // ���� � ������� ��� ���������
            EventBus.ApplyDamage(collision.gameObject, gameObject, _damage);
            Destroy(gameObject);
        }
        else if (collision.isTrigger) 
            Debug.Log("����� Bullet - ����� �������"); // �������� ��� �����������, ���� � �������
        else if (!collision.isTrigger) 
            Destroy(gameObject); // ���� � �������
    }

    public void ShotBullet(int damage, int speed)
    {
        _rb = GetComponent<Rigidbody2D>();
        _damage = damage;
        _rb.AddForce(transform.right * speed);

        StartCoroutine(DelaysDestruction());
    }

    private IEnumerator DelaysDestruction()
    {
        yield return new WaitForSeconds(_destructionDelay);
        Destroy(gameObject);
    }
}
