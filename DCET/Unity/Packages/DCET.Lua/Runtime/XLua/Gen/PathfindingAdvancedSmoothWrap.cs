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
    public class PathfindingAdvancedSmoothWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AdvancedSmooth);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 4, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOrder", _g_get_Order);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getturningRadius", _g_get_turningRadius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getturnConstruct1", _g_get_turnConstruct1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getturnConstruct2", _g_get_turnConstruct2);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setturningRadius", _s_set_turningRadius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setturnConstruct1", _s_set_turnConstruct1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setturnConstruct2", _s_set_turnConstruct2);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Order", _g_get_Order);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "turningRadius", _g_get_turningRadius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "turnConstruct1", _g_get_turnConstruct1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "turnConstruct2", _g_get_turnConstruct2);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "turningRadius", _s_set_turningRadius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "turnConstruct1", _s_set_turnConstruct1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "turnConstruct2", _s_set_turnConstruct2);
            
			
			
			
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
					
					Pathfinding.AdvancedSmooth gen_ret = new Pathfinding.AdvancedSmooth();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AdvancedSmooth constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.Apply( 
                        _p );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Order(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Order);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_turningRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.turningRadius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_turnConstruct1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.turnConstruct1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_turnConstruct2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.turnConstruct2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_turningRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.turningRadius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_turnConstruct1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.turnConstruct1 = (Pathfinding.AdvancedSmooth.MaxTurn)translator.GetObject(L, 2, typeof(Pathfinding.AdvancedSmooth.MaxTurn));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_turnConstruct2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth gen_to_be_invoked = (Pathfinding.AdvancedSmooth)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.turnConstruct2 = (Pathfinding.AdvancedSmooth.ConstantTurn)translator.GetObject(L, 2, typeof(Pathfinding.AdvancedSmooth.ConstantTurn));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
