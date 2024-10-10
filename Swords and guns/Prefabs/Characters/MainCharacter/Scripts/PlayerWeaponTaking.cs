using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTaking : WeaponTaking
{
    private int _multipleTriggerActive = 0; // ����� ����� ������ ��������� ��������� ������ � �� �������� ����� ������������� ���� �� �����

    #region MONO
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Object != null) 
            PickedUpWeapon();

        if (Input.GetKeyDown(KeyCode.Z) && Weapon != null)
            WeaponThrow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") // ������� ������
        {
            Object = collision.gameObject;
            _multipleTriggerActive++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon" && _multipleTriggerActive == 1)
        {
            Object = null;
            _multipleTriggerActive--;
        }
        if (collision.tag == "Weapon" && _multipleTriggerActive > 1) // �� �� ����������� ���� �. �. ��� ��� ������ ������ ��������
            _multipleTriggerActive--;
    }
    #endregion
}
