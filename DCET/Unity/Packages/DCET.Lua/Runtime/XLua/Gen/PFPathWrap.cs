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
    public class PFPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.Path);
			Utils.BeginObjectRegister(type, L, translator, 0, 29, 13, 10);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTotalLength", _m_GetTotalLength);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WaitForPath", _m_WaitForPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsDone", _m_IsDone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Error", _m_Error);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Claim", _m_Claim);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Release", _m_Release);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCompleteState", _g_get_CompleteState);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "geterror", _g_get_error);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "geterrorLog", _g_get_errorLog);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettagPenalties", _g_get_tagPenalties);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcallback", _g_get_callback);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getimmediateCallback", _g_get_immediateCallback);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettraversalProvider", _g_get_traversalProvider);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpath", _g_get_path);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvectorPath", _g_get_vectorPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnnConstraint", _g_get_nnConstraint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getenabledTags", _g_get_enabledTags);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "settagPenalties", _s_set_tagPenalties);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcallback", _s_set_callback);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setimmediateCallback", _s_set_immediateCallback);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settraversalProvider", _s_set_traversalProvider);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpath", _s_set_path);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvectorPath", _s_set_vectorPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnnConstraint", _s_set_nnConstraint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setenabledTags", _s_set_enabledTags);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "CompleteState", _g_get_CompleteState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "error", _g_get_error);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "errorLog", _g_get_errorLog);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tagPenalties", _g_get_tagPenalties);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "callback", _g_get_callback);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "immediateCallback", _g_get_immediateCallback);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "traversalProvider", _g_get_traversalProvider);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "path", _g_get_path);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vectorPath", _g_get_vectorPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nnConstraint", _g_get_nnConstraint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enabledTags", _g_get_enabledTags);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "tagPenalties", _s_set_tagPenalties);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "callback", _s_set_callback);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "immediateCallback", _s_set_immediateCallback);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "traversalProvider", _s_set_traversalProvider);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "path", _s_set_path);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "vectorPath", _s_set_vectorPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nnConstraint", _s_set_nnConstraint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enabledTags", _s_set_enabledTags);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.Path does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTotalLength(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.GetTotalLength(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitForPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.IEnumerator gen_ret = gen_to_be_invoked.WaitForPath(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDone(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsDone(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Error(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Error(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Claim(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _o = translator.GetObject(L, 2, typeof(object));
                    
                    gen_to_be_invoked.Claim( 
                        _o );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Release(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    object _o = translator.GetObject(L, 2, typeof(object));
                    bool _silent = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Release( 
                        _o, 
                        _silent );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _o = translator.GetObject(L, 2, typeof(object));
                    
                    gen_to_be_invoked.Release( 
                        _o );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Path.Release!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CompleteState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.PushPFPathCompleteState(L, gen_to_be_invoked.CompleteState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_error(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.error);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_errorLog(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.errorLog);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tagPenalties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tagPenalties);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_callback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.callback);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_immediateCallback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.immediateCallback);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_traversalProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.traversalProvider);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_path(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.path);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vectorPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.vectorPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nnConstraint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nnConstraint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heuristic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                translator.PushPFHeuristic(L, gen_to_be_invoked.heuristic);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heuristicScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.heuristicScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enabledTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.enabledTags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tagPenalties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tagPenalties = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_callback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.callback = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_immediateCallback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.immediateCallback = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_traversalProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.traversalProvider = (PF.ITraversalProvider)translator.GetObject(L, 2, typeof(PF.ITraversalProvider));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_path(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.path = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<PF.GraphNode>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vectorPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.vectorPath = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nnConstraint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nnConstraint = (PF.NNConstraint)translator.GetObject(L, 2, typeof(PF.NNConstraint));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heuristic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                PF.Heuristic gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.heuristic = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heuristicScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.heuristicScale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enabledTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Path gen_to_be_invoked = (PF.Path)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enabledTags = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
