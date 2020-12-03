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
    public class BehaviorDesignerRuntimeTasksHotfixConditionalWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BehaviorDesigner.Runtime.Tasks.HotfixConditional);
			Utils.BeginObjectRegister(type, L, translator, 0, 53, 18, 18);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPriority", _m_GetPriority);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUtility", _m_GetUtility);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAwake", _m_OnAwake);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBehaviorComplete", _m_OnBehaviorComplete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBehaviorRestart", _m_OnBehaviorRestart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnd", _m_OnEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnUpdate", _m_OnUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnFixedUpdate", _m_OnFixedUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnLateUpdate", _m_OnLateUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPause", _m_OnPause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnReset", _m_OnReset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStart", _m_OnStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTick", _m_OnTick);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbehaviorTreeConfigID", _g_get_behaviorTreeConfigID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgetPriority", _g_get_getPriority);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgetUtility", _g_get_getUtility);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonAwake", _g_get_onAwake);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonBehaviorComplete", _g_get_onBehaviorComplete);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonBehaviorRestart", _g_get_onBehaviorRestart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonEnd", _g_get_onEnd);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonUpdate", _g_get_onUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonFixedUpdate", _g_get_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonLateUpdate", _g_get_onLateUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonDrawGizmos", _g_get_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonPause", _g_get_onPause);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonReset", _g_get_onReset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonStart", _g_get_onStart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTick", _g_get_onTick);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getequals", _g_get_equals);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgetHashCode", _g_get_getHashCode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettoString", _g_get_toString);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbehaviorTreeConfigID", _s_set_behaviorTreeConfigID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgetPriority", _s_set_getPriority);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgetUtility", _s_set_getUtility);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonAwake", _s_set_onAwake);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonBehaviorComplete", _s_set_onBehaviorComplete);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonBehaviorRestart", _s_set_onBehaviorRestart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonEnd", _s_set_onEnd);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonUpdate", _s_set_onUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonFixedUpdate", _s_set_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonLateUpdate", _s_set_onLateUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonDrawGizmos", _s_set_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonPause", _s_set_onPause);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonReset", _s_set_onReset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonStart", _s_set_onStart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTick", _s_set_onTick);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setequals", _s_set_equals);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgetHashCode", _s_set_getHashCode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settoString", _s_set_toString);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "behaviorTreeConfigID", _g_get_behaviorTreeConfigID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "getPriority", _g_get_getPriority);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "getUtility", _g_get_getUtility);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onAwake", _g_get_onAwake);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBehaviorComplete", _g_get_onBehaviorComplete);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBehaviorRestart", _g_get_onBehaviorRestart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onEnd", _g_get_onEnd);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onUpdate", _g_get_onUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onFixedUpdate", _g_get_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onLateUpdate", _g_get_onLateUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDrawGizmos", _g_get_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPause", _g_get_onPause);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onReset", _g_get_onReset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStart", _g_get_onStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTick", _g_get_onTick);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "equals", _g_get_equals);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "getHashCode", _g_get_getHashCode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toString", _g_get_toString);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "behaviorTreeConfigID", _s_set_behaviorTreeConfigID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "getPriority", _s_set_getPriority);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "getUtility", _s_set_getUtility);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onAwake", _s_set_onAwake);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBehaviorComplete", _s_set_onBehaviorComplete);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBehaviorRestart", _s_set_onBehaviorRestart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onEnd", _s_set_onEnd);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onUpdate", _s_set_onUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onFixedUpdate", _s_set_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onLateUpdate", _s_set_onLateUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDrawGizmos", _s_set_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPause", _s_set_onPause);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onReset", _s_set_onReset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStart", _s_set_onStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTick", _s_set_onTick);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "equals", _s_set_equals);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "getHashCode", _s_set_getHashCode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toString", _s_set_toString);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_ret = new BehaviorDesigner.Runtime.Tasks.HotfixConditional();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.Tasks.HotfixConditional constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPriority(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.GetPriority(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUtility(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.GetUtility(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnAwake(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnAwake(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBehaviorComplete(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnBehaviorComplete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBehaviorRestart(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnBehaviorRestart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnd(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnd(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnFixedUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnFixedUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnLateUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnLateUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmos(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDrawGizmos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPause(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _paused = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.OnPause( 
                        _paused );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnReset(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnReset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStart(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnStart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTick(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        BehaviorDesigner.Runtime.Tasks.TaskStatus gen_ret = gen_to_be_invoked.OnTick(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool gen_ret = gen_to_be_invoked.Equals( 
                        _obj );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_behaviorTreeConfigID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.behaviorTreeConfigID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_getPriority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.getPriority);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_getUtility(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.getUtility);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onAwake(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onAwake);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBehaviorComplete(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onBehaviorComplete);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBehaviorRestart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onBehaviorRestart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEnd(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onEnd);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onFixedUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onFixedUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onLateUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onLateUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDrawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDrawGizmos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPause(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPause);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onReset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onReset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_equals(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.equals);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_getHashCode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.getHashCode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toString(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toString);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_behaviorTreeConfigID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.behaviorTreeConfigID = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_getPriority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.getPriority = translator.GetDelegate<System.Func<float>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_getUtility(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.getUtility = translator.GetDelegate<System.Func<float>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onAwake(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onAwake = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBehaviorComplete(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onBehaviorComplete = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBehaviorRestart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onBehaviorRestart = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEnd(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onEnd = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onUpdate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onFixedUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onFixedUpdate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onLateUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onLateUpdate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDrawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDrawGizmos = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPause(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPause = translator.GetDelegate<System.Action<bool>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onReset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onReset = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStart = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTick = translator.GetDelegate<System.Func<BehaviorDesigner.Runtime.Tasks.TaskStatus>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_equals(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.equals = translator.GetDelegate<System.Func<object, bool>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_getHashCode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.getHashCode = translator.GetDelegate<System.Func<int>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toString(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.HotfixConditional gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.HotfixConditional)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toString = translator.GetDelegate<System.Func<string>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
