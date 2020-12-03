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
    public class PathfindingRecastMeshObjWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RecastMeshObj);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 3, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBounds", _m_GetBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMeshFilter", _m_GetMeshFilter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCollider", _m_GetCollider);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdynamic", _g_get_dynamic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getarea", _g_get_area);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdynamic", _s_set_dynamic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setarea", _s_set_area);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dynamic", _g_get_dynamic);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "area", _g_get_area);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "bounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dynamic", _s_set_dynamic);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "area", _s_set_area);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAllInBounds", _m_GetAllInBounds_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.RecastMeshObj gen_ret = new Pathfinding.RecastMeshObj();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastMeshObj constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllInBounds_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.RecastMeshObj> _buffer = (System.Collections.Generic.List<Pathfinding.RecastMeshObj>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<Pathfinding.RecastMeshObj>));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                    Pathfinding.RecastMeshObj.GetAllInBounds( 
                        _buffer, 
                        _bounds );
                    
                    
                    
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
            
            
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetMeshFilter(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.MeshFilter gen_ret = gen_to_be_invoked.GetMeshFilter(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCollider(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Collider gen_ret = gen_to_be_invoked.GetCollider(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, gen_to_be_invoked.bounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dynamic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.dynamic);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.area);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
                UnityEngine.Bounds gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.bounds = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dynamic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dynamic = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastMeshObj gen_to_be_invoked = (Pathfinding.RecastMeshObj)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.area = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
