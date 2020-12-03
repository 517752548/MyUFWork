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
    public class PathfindingGraphUpdateShapeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.GraphUpdateShape);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 3, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBounds", _m_GetBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Contains", _m_Contains);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpoints", _g_get_points);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconvex", _g_get_convex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getminimumHeight", _g_get_minimumHeight);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpoints", _s_set_points);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconvex", _s_set_convex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setminimumHeight", _s_set_minimumHeight);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "points", _g_get_points);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "convex", _g_get_convex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "minimumHeight", _g_get_minimumHeight);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "points", _s_set_points);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "convex", _s_set_convex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "minimumHeight", _s_set_minimumHeight);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBounds", _m_GetBounds_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.GraphUpdateShape gen_ret = new Pathfinding.GraphUpdateShape();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<UnityEngine.Vector3[]>(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && translator.Assignable<UnityEngine.Matrix4x4>(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))
				{
					UnityEngine.Vector3[] _points = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
					bool _convex = LuaAPI.lua_toboolean(L, 3);
					UnityEngine.Matrix4x4 _matrix;translator.Get(L, 4, out _matrix);
					float _minimumHeight = (float)LuaAPI.lua_tonumber(L, 5);
					
					Pathfinding.GraphUpdateShape gen_ret = new Pathfinding.GraphUpdateShape(_points, _convex, _matrix, _minimumHeight);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.GraphUpdateShape constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBounds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetBounds_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3[] _points = (UnityEngine.Vector3[])translator.GetObject(L, 1, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 2, out _matrix);
                    float _minimumHeight = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.GraphUpdateShape.GetBounds( 
                        _points, 
                        _matrix, 
                        _minimumHeight );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contains(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 2)) 
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.Contains( 
                        _node );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        bool gen_ret = gen_to_be_invoked.Contains( 
                        _point );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.GraphUpdateShape.Contains!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_points(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.convex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minimumHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.minimumHeight);
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
			
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.convex = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_minimumHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateShape gen_to_be_invoked = (Pathfinding.GraphUpdateShape)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.minimumHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
