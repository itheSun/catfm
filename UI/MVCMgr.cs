using CatFM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class MVCMgr
{
    private static Dictionary<Type, BaseModel> modelMap = new Dictionary<Type, BaseModel>();
    private static Dictionary<Type, BaseController> controllerMap = new Dictionary<Type, BaseController>();
    private static Dictionary<Type, BaseView> viewMap = new Dictionary<Type, BaseView>();

    static MVCMgr()
    {
        //// 从配置文件加载
        //string uiPanelPath = "";
        //BaseView[] basePanels = ResMgr.Instance.LoadAll<BaseView>(uiPanelPath);
        //int panelCount = basePanels.Length;
        //for (int i = 0; i < panelCount; ++i)
        //{
        //    Register(basePanels[i]);
        //}

        Register(new LoginController());
    }

    public static void Register<T>(T obj) where T : class, new()
    {
        BaseModel model = obj as BaseModel;
        BaseView view = obj as BaseView;
        BaseController controller = obj as BaseController;
        if (model != null)
        {
            if (modelMap == null)
            {
                modelMap = new Dictionary<Type, BaseModel>();
            }
            modelMap[obj.GetType()] = model;
        }
        else if (view != null)
        {
            if (viewMap == null)
            {
                viewMap = new Dictionary<Type, BaseView>();
            }
            viewMap[obj.GetType()] = view;

        }
        else if (controller != null)
        {
            if (controllerMap == null)
            {
                controllerMap = new Dictionary<Type, BaseController>();
            }
            controllerMap[obj.GetType()] = controller;

        }
    }

    public static BaseController GetController<T>() where T : BaseController, new()
    {
        if (controllerMap == null)
        {
            controllerMap = new Dictionary<Type, BaseController>();
            return null;
        }
        if (controllerMap.ContainsKey(typeof(T)))
        {
            return controllerMap[typeof(T)];
        }
        T t = new T();
        controllerMap[typeof(T)] = t;
        return t;
    }

    public static BaseModel GetModel<T>() where T : BaseModel, new()
    {
        if (modelMap == null)
        {
            modelMap = new Dictionary<Type, BaseModel>();
            return null;
        }
        if (modelMap.ContainsKey(typeof(T)))
        {
            return modelMap[typeof(T)];
        }
        T t = new T();
        modelMap[typeof(T)] = t;
        return t;
    }
}
