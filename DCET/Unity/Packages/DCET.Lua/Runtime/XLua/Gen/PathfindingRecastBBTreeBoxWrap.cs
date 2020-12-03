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
    public class PathfindingRecastBBTreeBoxWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RecastBBTreeBox);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 4, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Contains", _m_Contains);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrect", _g_get_rect);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmesh", _g_get_mesh);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getc1", _g_get_c1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getc2", _g_get_c2);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrect", _s_set_rect);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmesh", _s_set_mesh);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setc1", _s_set_c1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setc2", _s_set_c2);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "rect", _g_get_rect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mesh", _g_get_mesh);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "c1", _g_get_c1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "c2", _g_get_c2);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "rect", _s_set_rect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mesh", _s_set_mesh);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "c1", _s_set_c1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "c2", _s_set_c2);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Pathfinding.RecastMeshObj>(L, 2))
				{
					Pathfinding.RecastMeshObj _mesh = (Pathfinding.RecastMeshObj)translator.GetObject(L, 2, typeof(Pathfinding.RecastMeshObj));
					
					Pathfinding.RecastBBTreeBox gen_ret = new Pathfinding.RecastBBTreeBox(_mesh);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastBBTreeBox constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contains(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        bool gen_ret = gen_to_be_invoked.Contains( 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mesh(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mesh);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_c1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.c1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_c2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.c2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                UnityEngine.Rect gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.rect = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mesh(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mesh = (Pathfinding.RecastMeshObj)translator.GetObject(L, 2, typeof(Pathfinding.RecastMeshObj));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_c1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.c1 = (Pathfinding.RecastBBTreeBox)translator.GetObject(L, 2, typeof(Pathfinding.RecastBBTreeBox));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_c2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastBBTreeBox gen_to_be_invoked = (Pathfinding.RecastBBTreeBox)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.c2 = (Pathfinding.RecastBBTreeBox)translator.GetObject(L, 2, typeof(Pathfinding.RecastBBTreeBox));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
