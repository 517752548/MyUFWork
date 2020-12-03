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
    public class PathfindingGraphUpdateSceneWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.GraphUpdateScene);
			Utils.BeginObjectRegister(type, L, translator, 0, 35, 14, 14);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Start", _m_Start);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPostScan", _m_OnPostScan);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InvertSettings", _m_InvertSettings);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RecalcConvex", _m_RecalcConvex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBounds", _m_GetBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DisableLegacyMode", _m_DisableLegacyMode);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpoints", _g_get_points);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconvex", _g_get_convex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getminBoundsHeight", _g_get_minBoundsHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpenaltyDelta", _g_get_penaltyDelta);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmodifyWalkability", _g_get_modifyWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsetWalkability", _g_get_setWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getapplyOnStart", _g_get_applyOnStart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getapplyOnScan", _g_get_applyOnScan);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdatePhysics", _g_get_updatePhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getresetPenaltyOnPhysics", _g_get_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdateErosion", _g_get_updateErosion);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmodifyTag", _g_get_modifyTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsetTag", _g_get_setTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlegacyMode", _g_get_legacyMode);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpoints", _s_set_points);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconvex", _s_set_convex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setminBoundsHeight", _s_set_minBoundsHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpenaltyDelta", _s_set_penaltyDelta);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmodifyWalkability", _s_set_modifyWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsetWalkability", _s_set_setWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setapplyOnStart", _s_set_applyOnStart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setapplyOnScan", _s_set_applyOnScan);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdatePhysics", _s_set_updatePhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setresetPenaltyOnPhysics", _s_set_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdateErosion", _s_set_updateErosion);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmodifyTag", _s_set_modifyTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsetTag", _s_set_setTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlegacyMode", _s_set_legacyMode);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "points", _g_get_points);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "convex", _g_get_convex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "minBoundsHeight", _g_get_minBoundsHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "penaltyDelta", _g_get_penaltyDelta);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "modifyWalkability", _g_get_modifyWalkability);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "setWalkability", _g_get_setWalkability);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "applyOnStart", _g_get_applyOnStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "applyOnScan", _g_get_applyOnScan);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updatePhysics", _g_get_updatePhysics);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "resetPenaltyOnPhysics", _g_get_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updateErosion", _g_get_updateErosion);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "modifyTag", _g_get_modifyTag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "setTag", _g_get_setTag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "legacyMode", _g_get_legacyMode);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "points", _s_set_points);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "convex", _s_set_convex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "minBoundsHeight", _s_set_minBoundsHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "penaltyDelta", _s_set_penaltyDelta);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "modifyWalkability", _s_set_modifyWalkability);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "setWalkability", _s_set_setWalkability);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "applyOnStart", _s_set_applyOnStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "applyOnScan", _s_set_applyOnScan);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updatePhysics", _s_set_updatePhysics);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "resetPenaltyOnPhysics", _s_set_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updateErosion", _s_set_updateErosion);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "modifyTag", _s_set_modifyTag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "setTag", _s_set_setTag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "legacyMode", _s_set_legacyMode);
            
			
			
			
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
					
					Pathfinding.GraphUpdateScene gen_ret = new Pathfinding.GraphUpdateScene();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.GraphUpdateScene constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPostScan(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnPostScan(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InvertSettings(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InvertSettings(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecalcConvex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RecalcConvex(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBounds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetBounds(  );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Apply(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DisableLegacyMode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DisableLegacyMode(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_points(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.points);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_convex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.convex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minBoundsHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.minBoundsHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_penaltyDelta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.penaltyDelta);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_modifyWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.modifyWalkability);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_setWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.setWalkability);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_applyOnStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.applyOnStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_applyOnScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.applyOnScan);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updatePhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.updatePhysics);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resetPenaltyOnPhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.resetPenaltyOnPhysics);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updateErosion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.updateErosion);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_modifyTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.modifyTag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_setTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.setTag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_legacyMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.legacyMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_points(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.points = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_convex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.convex = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_minBoundsHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.minBoundsHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_penaltyDelta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.penaltyDelta = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_modifyWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.modifyWalkability = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_setWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.setWalkability = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_applyOnStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.applyOnStart = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_applyOnScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.applyOnScan = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updatePhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.updatePhysics = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resetPenaltyOnPhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.resetPenaltyOnPhysics = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updateErosion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.updateErosion = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_modifyTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.modifyTag = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_setTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.setTag = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_legacyMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateScene gen_to_be_invoked = (Pathfinding.GraphUpdateScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.legacyMode = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
