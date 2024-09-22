using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyahaGraphicDevelopTools.VRCComponentRemove
{
    /// <summary>
    /// VRC�̃R���|�[�l���g����������B
    /// �������ꂽ�A�o�^�[��Ctrl+C�ŃR�s�[����Play���I�����ăy�[�X�g����
    /// </summary>
    public class VRCComponentRemover : MonoBehaviour
    {
        /// <summary>
        /// �����ΏۂƂȂ�X�N���v�g��DLL
        /// </summary>
        private string[] _targetDllArray = new string[] {
        // Packages/com.vrchat.base/Runtime/VRCSDK/Plugins
        "SDKBase-Legacy",
        "VRC.Dynamics",
        "VRC.SDK3.Dynamics.Constraint",
        "VRC.SDK3.Dynamics.Contact",
        "VRC.SDK3.Dynamics.PhysBone",
        "VRC.Utility",
        "VRCCore-Editor",
        "VRCCore-Standalone",
        "VRCSDKBase",
        "VRCSDKBase-Editor",
        // Packages/com.vrchat.avatars/Runtime/VRCSDK/Plugins
        "VRCSDK3A",
        "VRCSDK3A-Editor"};

        /// <summary>
        /// �����Ώۂ����f���邽�߂̃t���O
        /// </summary>
        private bool[] _isTargetDllArray;

        void Start()
        {
            var components = GetComponentsInChildren<MonoBehaviour>();

            // ���f�pbool��������
            _isTargetDllArray = new bool[components.Length];
            for (int i = 0; i < _isTargetDllArray.Length; i++)
            {
                _isTargetDllArray[i] = false;
            }

            // �����Ώۂ����f
            for (int i = 0; i < components.Length; i++)
            {
                var assembly = components[i].GetType().Assembly;
                for (int j = 0; j < _targetDllArray.Length; j++)
                {
                    if (assembly.GetName().Name == _targetDllArray[j])
                    {
                        _isTargetDllArray[i] = true;
                        continue;
                    }
                }
            }

            // ����
            for (int i = 0; i < _isTargetDllArray.Length; i++)
            {
                if (_isTargetDllArray[i])
                {
                    Debug.Log($"{components[i].name}��Remove���܂�");
                    Destroy(components[i]);
                }
            }
        }
    }
}
