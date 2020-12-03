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
    public class BehaviorDesignerRuntimeTasksReturnSuccessWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BehaviorDesigner.Runtime.Tasks.ReturnSuccess);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanExecute", _m_CanExecute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnChildExecuted", _m_OnChildExecuted);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Decorate", _m_Decorate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnd", _m_OnEnd);
						
            
			
						
			
			
			
			
			
			
			
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
					
					BehaviorDesigner.Runtime.Tasks.ReturnSuccess gen_ret = new BehaviorDesigner.Runtime.Tasks.ReturnSuccess();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.Tasks.ReturnSuccess constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanExecute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ReturnSuccess gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ReturnSuccess)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_OnChildExecuted(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ReturnSuccess gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ReturnSuccess)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_Decorate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.ReturnSuccess gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ReturnSuccess)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BehaviorDesigner.Runtime.Tasks.TaskStatus _status;translator.Get(L, 2, out _status);
                    
                        BehaviorDesigner.Runtime.Tasks.TaskStatus gen_ret = gen_to_be_invoked.Decorate( 
                        _status );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                BehaviorDesigner.Runtime.Tasks.ReturnSuccess gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.ReturnSuccess)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnd(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
