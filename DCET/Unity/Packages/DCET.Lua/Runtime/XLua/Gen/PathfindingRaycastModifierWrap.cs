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
    public class PathfindingRaycastModifierWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RaycastModifier);
			Utils.BeginObjectRegister(type, L, translator, 0, 18, 9, 8);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOrder", _g_get_Order);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuseRaycasting", _g_get_useRaycasting);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getthickRaycast", _g_get_thickRaycast);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getthickRaycastRadius", _g_get_thickRaycastRadius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuse2DPhysics", _g_get_use2DPhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getraycastOffset", _g_get_raycastOffset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuseGraphRaycasting", _g_get_useGraphRaycasting);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getquality", _g_get_quality);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuseRaycasting", _s_set_useRaycasting);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setthickRaycast", _s_set_thickRaycast);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setthickRaycastRadius", _s_set_thickRaycastRadius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuse2DPhysics", _s_set_use2DPhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setraycastOffset", _s_set_raycastOffset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuseGraphRaycasting", _s_set_useGraphRaycasting);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setquality", _s_set_quality);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Order", _g_get_Order);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useRaycasting", _g_get_useRaycasting);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "thickRaycast", _g_get_thickRaycast);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "thickRaycastRadius", _g_get_thickRaycastRadius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "use2DPhysics", _g_get_use2DPhysics);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "raycastOffset", _g_get_raycastOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useGraphRaycasting", _g_get_useGraphRaycasting);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "quality", _g_get_quality);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "useRaycasting", _s_set_useRaycasting);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "thickRaycast", _s_set_thickRaycast);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "thickRaycastRadius", _s_set_thickRaycastRadius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "use2DPhysics", _s_set_use2DPhysics);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "raycastOffset", _s_set_raycastOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useGraphRaycasting", _s_set_useGraphRaycasting);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "quality", _s_set_quality);
            
			
			
			
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
					
					Pathfinding.RaycastModifier gen_ret = new Pathfinding.RaycastModifier();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RaycastModifier constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
            
            
                
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
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Order);
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
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_thickRaycast(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.thickRaycast);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_thickRaycastRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.thickRaycastRadius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_use2DPhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.use2DPhysics);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_raycastOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.raycastOffset);
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
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useGraphRaycasting);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_quality(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRaycastModifierQuality(L, gen_to_be_invoked.quality);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useRaycasting(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                UnityEngine.LayerMask gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.mask = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_thickRaycast(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.thickRaycast = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_thickRaycastRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.thickRaycastRadius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_use2DPhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.use2DPhysics = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_raycastOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.raycastOffset = gen_value;
            
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
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useGraphRaycasting = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_quality(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RaycastModifier gen_to_be_invoked = (Pathfinding.RaycastModifier)translator.FastGetCSObj(L, 1);
                Pathfinding.RaycastModifier.Quality gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.quality = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
