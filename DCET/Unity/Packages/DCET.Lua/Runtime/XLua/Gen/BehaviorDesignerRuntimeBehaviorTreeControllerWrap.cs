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
    public class BehaviorDesignerRuntimeBehaviorTreeControllerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BehaviorDesigner.Runtime.BehaviorTreeController);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 4, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetExternalBehavior", _m_SetExternalBehavior);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethotfixActions", _g_get_hotfixActions);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethotfixComposites", _g_get_hotfixComposites);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethotfixConditionals", _g_get_hotfixConditionals);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethotfixDecorators", _g_get_hotfixDecorators);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "hotfixActions", _g_get_hotfixActions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hotfixComposites", _g_get_hotfixComposites);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hotfixConditionals", _g_get_hotfixConditionals);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hotfixDecorators", _g_get_hotfixDecorators);
            
			
			
			
			
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
					
					BehaviorDesigner.Runtime.BehaviorTreeController gen_ret = new BehaviorDesigner.Runtime.BehaviorTreeController();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.BehaviorTreeController constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetExternalBehavior(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BehaviorDesigner.Runtime.ExternalBehavior _externalBehavior = (BehaviorDesigner.Runtime.ExternalBehavior)translator.GetObject(L, 2, typeof(BehaviorDesigner.Runtime.ExternalBehavior));
                    
                    gen_to_be_invoked.SetExternalBehavior( 
                        _externalBehavior );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hotfixActions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hotfixActions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hotfixComposites(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hotfixComposites);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hotfixConditionals(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hotfixConditionals);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hotfixDecorators(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.BehaviorTreeController gen_to_be_invoked = (BehaviorDesigner.Runtime.BehaviorTreeController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hotfixDecorators);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
