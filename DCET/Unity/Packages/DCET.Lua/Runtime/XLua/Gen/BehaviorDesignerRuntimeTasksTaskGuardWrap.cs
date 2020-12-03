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
    public class BehaviorDesignerRuntimeTasksTaskGuardWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BehaviorDesigner.Runtime.Tasks.TaskGuard);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 3, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanExecute", _m_CanExecute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnChildStarted", _m_OnChildStarted);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OverrideStatus", _m_OverrideStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "taskExecuting", _m_taskExecuting);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnd", _m_OnEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnReset", _m_OnReset);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxTaskAccessCount", _g_get_maxTaskAccessCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlinkedTaskGuards", _g_get_linkedTaskGuards);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwaitUntilTaskAvailable", _g_get_waitUntilTaskAvailable);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxTaskAccessCount", _s_set_maxTaskAccessCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlinkedTaskGuards", _s_set_linkedTaskGuards);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwaitUntilTaskAvailable", _s_set_waitUntilTaskAvailable);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxTaskAccessCount", _g_get_maxTaskAccessCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "linkedTaskGuards", _g_get_linkedTaskGuards);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "waitUntilTaskAvailable", _g_get_waitUntilTaskAvailable);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxTaskAccessCount", _s_set_maxTaskAccessCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "linkedTaskGuards", _s_set_linkedTaskGuards);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "waitUntilTaskAvailable", _s_set_waitUntilTaskAvailable);
            
			
			
			
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
					
					BehaviorDesigner.Runtime.Tasks.TaskGuard gen_ret = new BehaviorDesigner.Runtime.Tasks.TaskGuard();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.Tasks.TaskGuard constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanExecute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.CanExecute(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnChildStarted(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnChildStarted(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OverrideStatus(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BehaviorDesigner.Runtime.Tasks.TaskStatus _status;translator.Get(L, 2, out _status);
                    
                        BehaviorDesigner.Runtime.Tasks.TaskStatus gen_ret = gen_to_be_invoked.OverrideStatus( 
                        _status );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_taskExecuting(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _increase = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.taskExecuting( 
                        _increase );
                    
                    
                    
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
            
            
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnd(  );
                    
                    
                    
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
            
            
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnReset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxTaskAccessCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxTaskAccessCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_linkedTaskGuards(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.linkedTaskGuards);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_waitUntilTaskAvailable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.waitUntilTaskAvailable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxTaskAccessCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxTaskAccessCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_linkedTaskGuards(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.linkedTaskGuards = (BehaviorDesigner.Runtime.Tasks.TaskGuard[])translator.GetObject(L, 2, typeof(BehaviorDesigner.Runtime.Tasks.TaskGuard[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_waitUntilTaskAvailable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.TaskGuard gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.TaskGuard)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.waitUntilTaskAvailable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
