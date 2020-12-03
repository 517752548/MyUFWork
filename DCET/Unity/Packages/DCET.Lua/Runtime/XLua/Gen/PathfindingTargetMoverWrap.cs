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
    public class PathfindingTargetMoverWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.TargetMover);
			Utils.BeginObjectRegister(type, L, translator, 0, 11, 4, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Start", _m_Start);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnGUI", _m_OnGUI);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateTargetPosition", _m_UpdateTargetPosition);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettarget", _g_get_target);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonlyOnDoubleClick", _g_get_onlyOnDoubleClick);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuse2D", _g_get_use2D);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settarget", _s_set_target);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonlyOnDoubleClick", _s_set_onlyOnDoubleClick);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuse2D", _s_set_use2D);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "mask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "target", _g_get_target);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onlyOnDoubleClick", _g_get_onlyOnDoubleClick);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "use2D", _g_get_use2D);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "mask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "target", _s_set_target);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onlyOnDoubleClick", _s_set_onlyOnDoubleClick);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "use2D", _s_set_use2D);
            
			
			
			
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
					
					Pathfinding.TargetMover gen_ret = new Pathfinding.TargetMover();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.TargetMover constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGUI(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnGUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateTargetPosition(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateTargetPosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_target(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.target);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onlyOnDoubleClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.onlyOnDoubleClick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_use2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.use2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                UnityEngine.LayerMask gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.mask = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_target(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.target = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onlyOnDoubleClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onlyOnDoubleClick = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_use2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.TargetMover gen_to_be_invoked = (Pathfinding.TargetMover)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.use2D = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
