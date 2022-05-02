using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using UnityEditor;

namespace CatFM
{
    public class UIMgr : DntdMonoSingleton<UIMgr>
    {
        // ui系统根节点
        private Transform layerRoot;
        // 面板根节点
        private Transform panelRoot;

        // 各层根节点
        private Dictionary<UILayer, Transform> layerMap = new Dictionary<UILayer, Transform>();
        // 所有面板预制体
        private Dictionary<PanelID, GameObject> prefMap = new Dictionary<PanelID, GameObject>();
        // 所有面板的脚本
        private Dictionary<PanelID, BaseView> panelMap = new Dictionary<PanelID, BaseView>();

        // ui栈
        private Stack<BaseView> panelStack = new Stack<BaseView>();

        /// <summary>
        /// 面板索引器
        /// </summary>
        /// <value></value>
        public BaseView this[PanelID panelID]
        {
            get
            {
                if (!panelMap.ContainsKey(panelID))
                {
                    Bug.Throw(string.Format("The panel {0} does not exist", panelID));
                }
                return panelMap[panelID];
            }
        }
        public void Init()
        {

            foreach (UILayer layer in Enum.GetValues(typeof(UILayer)))
            {
                GameObject go = new GameObject(layer.ToString(), typeof(RectTransform));
                go.transform.SetParent(layerRoot);
                RectTransform rect = go.GetComponent<RectTransform>();
                //rect.SetStrecth(StretchLayout.S_S);
                layerMap[layer] = go.transform;
            }
            GameObject[] panels = ResMgr.Instance.LoadAll<GameObject>(Constant.Path_Res_Panels) as GameObject[];
            for (int i = 0; i < panels.Length; i++)
            {
                PanelID id;
                if (Enum.TryParse<PanelID>(panels[i].name, true, out id))
                {
                    prefMap[id] = panels[i];
                }
                else
                {
                    Bug.Err("不存在{0}面板的枚举定义", panels[i]);
                }
            }
        }

        /// <summary>
        /// 面板进栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="panelID"></param>
        /// <param name="hide"></param>
        /// <param name="diasble"></param>
        /// <returns></returns>
        public T Push<T>(UILayer layer, PanelID panelID, bool hide = true, bool disasble = true) where T : BaseView
        {
            if (panelStack == null)
            {
                panelStack = new Stack<BaseView>();
            }

            if (!panelMap.ContainsKey(panelID))
            {
                GameObject go = ResMgr.Instance.Instantiate<GameObject>(prefMap[panelID]);
                go.transform.SetParent(layerMap[layer]);
                RectTransform rect = go.GetComponent<RectTransform>();
                //rect.SetStrecth(StretchLayout.S_S);
                T panel = go.GetComponent<T>();
                panelMap.Add(panelID, panel);
            }

            if (panelStack.Count > 0)
            {
                BaseView top = panelStack.Peek();
                if (hide)
                    top.OnHide();
                if (disasble)
                    top.OnBlock();
            }
            T target = panelMap[panelID] as T;
            panelStack.Push(target);
            target.OnShow();
            return target;
        }

        /// <summary>
        /// 面板出栈
        /// </summary>
        public void Pop()
        {
            if (panelStack == null)
            {
                panelStack = new Stack<BaseView>();
            }

            if (panelStack.Count <= 0)
            {
                return;
            }

            BaseView panel = panelStack.Pop();
            panel.OnHide();

            if (panelStack.Count > 0)
            {
                BaseView top = panelStack.Peek();
                top.OnActive();
            }
        }
    }
}
