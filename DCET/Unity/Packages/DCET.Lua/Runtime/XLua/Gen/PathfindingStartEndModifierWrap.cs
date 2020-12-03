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
    public class PathfindingStartEndModifierWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.StartEndModifier);
			Utils.BeginObjectRegister(type, L, translator, 0, 16, 8, 7);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOrder", _g_get_Order);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getaddPoints", _g_get_addPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getexactStartPoint", _g_get_exactStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getexactEndPoint", _g_get_exactEndPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getadjustStartPoint", _g_get_adjustStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuseRaycasting", _g_get_useRaycasting);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuseGraphRaycasting", _g_get_useGraphRaycasting);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setaddPoints", _s_set_addPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setexactStartPoint", _s_set_exactStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setexactEndPoint", _s_set_exactEndPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setadjustStartPoint", _s_set_adjustStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuseRaycasting", _s_set_useRaycasting);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuseGraphRaycasting", _s_set_useGraphRaycasting);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Order", _g_get_Order);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "addPoints", _g_get_addPoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "exactStartPoint", _g_get_exactStartPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "exactEndPoint", _g_get_exactEndPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "adjustStartPoint", _g_get_adjustStartPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useRaycasting", _g_get_useRaycasting);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useGraphRaycasting", _g_get_useGraphRaycasting);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "addPoints", _s_set_addPoints);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "exactStartPoint", _s_set_exactStartPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "exactEndPoint", _s_set_exactEndPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "adjustStartPoint", _s_set_adjustStartPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useRaycasting", _s_set_useRaycasting);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useGraphRaycasting", _s_set_useGraphRaycasting);
            
			
			
			
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
					
					Pathfinding.StartEndModifier gen_ret = new Pathfinding.StartEndModifier();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.StartEndModifier constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path __p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.Apply( 
                        __p );
                    
                    
                    
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
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Order);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_addPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.addPoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exactStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingStartEndModifierExactness(L, gen_to_be_invoked.exactStartPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exactEndPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingStartEndModifierExactness(L, gen_to_be_invoked.exactEndPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_adjustStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.adjustStartPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useRaycasting(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useRaycasting);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useGraphRaycasting(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useGraphRaycasting);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_addPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.addPoints = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exactStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                Pathfinding.StartEndModifier.Exactness gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.exactStartPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_exactEndPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                Pathfinding.StartEndModifier.Exactness gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.exactEndPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_adjustStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.adjustStartPoint = translator.GetDelegate<System.Func<UnityEngine.Vector3>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useRaycasting(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useRaycasting = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                UnityEngine.LayerMask gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.mask = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useGraphRaycasting(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.StartEndModifier gen_to_be_invoked = (Pathfinding.StartEndModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useGraphRaycasting = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
