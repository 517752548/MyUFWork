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
    public class PathfindingVoxelsVoxelSpanWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Voxels.VoxelSpan);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 4, 4);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbottom", _g_get_bottom);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettop", _g_get_top);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnext", _g_get_next);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getarea", _g_get_area);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbottom", _s_set_bottom);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settop", _s_set_top);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnext", _s_set_next);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setarea", _s_set_area);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "bottom", _g_get_bottom);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "top", _g_get_top);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "next", _g_get_next);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "area", _g_get_area);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "bottom", _s_set_bottom);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "top", _s_set_top);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "next", _s_set_next);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "area", _s_set_area);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					uint _b = LuaAPI.xlua_touint(L, 2);
					uint _t = LuaAPI.xlua_touint(L, 3);
					int _area = LuaAPI.xlua_tointeger(L, 4);
					
					Pathfinding.Voxels.VoxelSpan gen_ret = new Pathfinding.Voxels.VoxelSpan(_b, _t, _area);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.VoxelSpan constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bottom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.bottom);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_top(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.top);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_next(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.next);
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
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.area);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bottom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bottom = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_top(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.top = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_next(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.next = (Pathfinding.Voxels.VoxelSpan)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.VoxelSpan));
            
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
			
                Pathfinding.Voxels.VoxelSpan gen_to_be_invoked = (Pathfinding.Voxels.VoxelSpan)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.area = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
