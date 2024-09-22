using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyahaGraphicDevelopTools.VRCComponentRemove
{
    /// <summary>
    /// VRCのコンポーネントを消去する。
    /// 消去されたアバターをCtrl+CでコピーしてPlayを終了してペーストする
    /// </summary>
    public class VRCComponentRemover : MonoBehaviour
    {
        /// <summary>
        /// 消去対象となるスクリプトのDLL
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
        /// 消去対象か判断するためのフラグ
        /// </summary>
        private bool[] _isTargetDllArray;

        void Start()
        {
            var components = GetComponentsInChildren<MonoBehaviour>();

            // 判断用boolを初期化
            _isTargetDllArray = new bool[components.Length];
            for (int i = 0; i < _isTargetDllArray.Length; i++)
            {
                _isTargetDllArray[i] = false;
            }

            // 消去対象か判断
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

            // 消去
            for (int i = 0; i < _isTargetDllArray.Length; i++)
            {
                if (_isTargetDllArray[i])
                {
                    Debug.Log($"{components[i].name}をRemoveします");
                    Destroy(components[i]);
                }
            }
        }
    }
}
