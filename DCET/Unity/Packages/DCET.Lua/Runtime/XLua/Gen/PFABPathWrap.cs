#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PFABPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.ABPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 16, 8, 8);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartNode", _g_get_startNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getendNode", _g_get_endNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoriginalStartPoint", _g_get_originalStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoriginalEndPoint", _g_get_originalEndPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartPoint", _g_get_startPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getendPoint", _g_get_endPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartIntPoint", _g_get_startIntPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcalculatePartial", _g_get_calculatePartial);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartNode", _s_set_startNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setendNode", _s_set_endNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoriginalStartPoint", _s_set_originalStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoriginalEndPoint", _s_set_originalEndPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartPoint", _s_set_startPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setendPoint", _s_set_endPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartIntPoint", _s_set_startIntPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcalculatePartial", _s_set_calculatePartial);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "startNode", _g_get_startNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endNode", _g_get_endNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "originalStartPoint", _g_get_originalStartPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "originalEndPoint", _g_get_originalEndPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startPoint", _g_get_startPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endPoint", _g_get_endPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startIntPoint", _g_get_startIntPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "calculatePartial", _g_get_calculatePartial);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "startNode", _s_set_startNode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endNode", _s_set_endNode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "originalStartPoint", _s_set_originalStartPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "originalEndPoint", _s_set_originalEndPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startPoint", _s_set_startPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endPoint", _s_set_endPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startIntPoint", _s_set_startIntPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "calculatePartial", _s_set_calculatePartial);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Construct", _m_Construct_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.ABPath gen_ret = new PF.ABPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.ABPath constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.OnPathDelegate>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 2, out _end);
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 3);
                    
                        PF.ABPath gen_ret = PF.ABPath.Construct( 
                        _start, 
                        _end, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 2, out _end);
                    
                        PF.ABPath gen_ret = PF.ABPath.Construct( 
                        _start, 
                        _end );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.ABPath.Construct!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.startNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.endNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_originalStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.originalStartPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_originalEndPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.originalEndPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.startPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.endPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startIntPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.startIntPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_calculatePartial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.calculatePartial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.endNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_originalStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.originalStartPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_originalEndPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.originalEndPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.endPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startIntPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                PF.Int3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startIntPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_calculatePartial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ABPath gen_to_be_invoked = (PF.ABPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.calculatePartial = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
