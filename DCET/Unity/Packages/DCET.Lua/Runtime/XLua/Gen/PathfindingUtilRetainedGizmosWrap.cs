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
    public class PathfindingUtilRetainedGizmosWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Util.RetainedGizmos);
			Utils.BeginObjectRegister(type, L, translator, 0, 11, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSingleFrameGizmoHelper", _m_GetSingleFrameGizmoHelper);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGizmoHelper", _m_GetGizmoHelper);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasCachedMesh", _m_HasCachedMesh);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Draw", _m_Draw);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawExisting", _m_DrawExisting);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FinalizeDraw", _m_FinalizeDraw);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearCache", _m_ClearCache);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsurfaceMaterial", _g_get_surfaceMaterial);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlineMaterial", _g_get_lineMaterial);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsurfaceMaterial", _s_set_surfaceMaterial);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlineMaterial", _s_set_lineMaterial);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "surfaceMaterial", _g_get_surfaceMaterial);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lineMaterial", _g_get_lineMaterial);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "surfaceMaterial", _s_set_surfaceMaterial);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lineMaterial", _s_set_lineMaterial);
            
			
			
			
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
					
					Pathfinding.Util.RetainedGizmos gen_ret = new Pathfinding.Util.RetainedGizmos();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.RetainedGizmos constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSingleFrameGizmoHelper(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Pathfinding.Util.GraphGizmoHelper gen_ret = gen_to_be_invoked.GetSingleFrameGizmoHelper(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGizmoHelper(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Util.RetainedGizmos.Hasher _hasher;translator.Get(L, 2, out _hasher);
                    
                        Pathfinding.Util.GraphGizmoHelper gen_ret = gen_to_be_invoked.GetGizmoHelper( 
                        _hasher );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasCachedMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Util.RetainedGizmos.Hasher _hasher;translator.Get(L, 2, out _hasher);
                    
                        bool gen_ret = gen_to_be_invoked.HasCachedMesh( 
                        _hasher );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Draw(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Util.RetainedGizmos.Hasher _hasher;translator.Get(L, 2, out _hasher);
                    
                        bool gen_ret = gen_to_be_invoked.Draw( 
                        _hasher );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawExisting(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DrawExisting(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinalizeDraw(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FinalizeDraw(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCache(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearCache(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_surfaceMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.surfaceMaterial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lineMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.lineMaterial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_surfaceMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.surfaceMaterial = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lineMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.RetainedGizmos gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.lineMaterial = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
