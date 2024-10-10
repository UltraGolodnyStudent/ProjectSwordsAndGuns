using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _mainCharacter;

    #region AI
    [Space(10)]
    [SerializeField] private GameObject _aIEnemyCharacter;
    [SerializeField] private GameObject _startWeapon;
    [SerializeField] private WeaponSearch _weaponSearcher;
    #endregion

    #region UI
    [Space(10)]
    [TextArea]
    public string UI;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private Canvas_manager _canvasManager;
    [SerializeField] private HUD_Characteristics _characteristics;
    [SerializeField] private Slider _hpBar, _stBar;
    [SerializeField] private TextMeshProUGUI _hpText, _stText;

    [Space(10)]
    [SerializeField] private GameObject _skillPanel, _strength_Panel, _endurance_panel, _mastery_panel, _magic_panel;

    [Space(10)]
    [SerializeField] private Button _strength_Button, _endurance_Button, _mastery_Button, _magic_Button;
    #endregion

    private void Awake()
    {
        MainCharacterInitialize();
        HUDInitialize();
        AIEnemyCharacterInitialize(_aIEnemyCharacter);
    }

    private void MainCharacterInitialize()
    {
        _mainCharacter.GetComponent<AnimationController>().Initialize();
        _mainCharacter.GetComponent<PlayerMovement>().Initialize();
        _mainCharacter.GetComponent<CharacterHealth>().Initialize();
        _mainCharacter.GetComponent<CharacterStamina>().Initialize();
        _mainCharacter.GetComponent<PlayerHit>().Initialize();
        _mainCharacter.GetComponent<PlayerShooting>().Initialize();
        _mainCharacter.GetComponent<PlayerWeaponTaking>().Initialize();
        _mainCharacter.GetComponent<HitTrigger>().Initialize();
    }
    private void AIEnemyCharacterInitialize(GameObject enemyAi)
    {
        enemyAi.GetComponent<AnimationController>().Initialize();
        enemyAi.GetComponent<AIMovement>().Initialize(_mainCharacter);
        enemyAi.GetComponent<AIHealth>().Initialize();
        enemyAi.GetComponent<CharacterStamina>().Initialize();
        enemyAi.GetComponent<AIHit>().Initialize();
        enemyAi.GetComponent<Shooting>().Initialize();
        enemyAi.GetComponent<AIRangeCombat>().Initialize(_mainCharacter);
        enemyAi.GetComponent<AIMeleCombat>().Initialize(_mainCharacter);
        enemyAi.GetComponent<AIWeaponTaking>().Initialize(_startWeapon, _weaponSearcher);
    }

    private void HUDInitialize()
    {
        _cameraFollow.Initialize(_mainCharacter.transform);
        _characteristics.Initialize(_mainCharacter, _hpBar, _hpText, _stBar, _stText);

        _strength_Panel.GetComponent<Strength_panel>().Initialize(_mainCharacter);

        List<GameObject> skillpanelList = new() { _strength_Panel, _endurance_panel, _mastery_panel, _magic_panel };
        List<Button> skillButtonlList = new() { _strength_Button, _endurance_Button, _mastery_Button, _magic_Button };

        _skillPanel.GetComponent<Skill_panel>().Initialize(skillButtonlList, skillpanelList);

        _canvasManager.Initialize(_skillPanel, skillpanelList);
    }
}
