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
    public class BehaviorDesignerRuntimeTasksConditionalEvaluatorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAwake", _m_OnAwake);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStart", _m_OnStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanExecute", _m_CanExecute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanReevaluate", _m_CanReevaluate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTick", _m_OnTick);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnChildExecuted", _m_OnChildExecuted);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OverrideStatus", _m_OverrideStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnd", _m_OnEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnReset", _m_OnReset);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getreevaluate", _g_get_reevaluate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconditionalTask", _g_get_conditionalTask);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setreevaluate", _s_set_reevaluate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconditionalTask", _s_set_conditionalTask);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "reevaluate", _g_get_reevaluate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "conditionalTask", _g_get_conditionalTask);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "reevaluate", _s_set_reevaluate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "conditionalTask", _s_set_conditionalTask);
            
			
			
			
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
					
					BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_ret = new BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnAwake(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnAwake(  );
                    
                    
                    
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
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnStart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanExecute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_CanReevaluate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.CanReevaluate(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_OnChildExecuted(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BehaviorDesigner.Runtime.Tasks.TaskStatus _childStatus;translator.Get(L, 2, out _childStatus);
                    
                    gen_to_be_invoked.OnChildExecuted( 
                        _childStatus );
                    
                    
                    
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
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        BehaviorDesigner.Runtime.Tasks.TaskStatus gen_ret = gen_to_be_invoked.OverrideStatus(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<BehaviorDesigner.Runtime.Tasks.TaskStatus>(L, 2)) 
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
            
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator.OverrideStatus!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnd(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnReset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reevaluate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.reevaluate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_conditionalTask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.conditionalTask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_reevaluate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.reevaluate = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_conditionalTask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.conditionalTask = (BehaviorDesigner.Runtime.Tasks.Conditional)translator.GetObject(L, 2, typeof(BehaviorDesigner.Runtime.Tasks.Conditional));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
