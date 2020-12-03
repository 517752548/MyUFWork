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
    public class PathfindingVoxelsVoxelContourSetWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Voxels.VoxelContourSet);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 2, 2);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconts", _g_get_conts);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbounds", _g_get_bounds);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconts", _s_set_conts);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbounds", _s_set_bounds);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "conts", _g_get_conts);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounds", _g_get_bounds);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "conts", _s_set_conts);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bounds", _s_set_bounds);
            
			
			
			
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
					
					Pathfinding.Voxels.VoxelContourSet gen_ret = new Pathfinding.Voxels.VoxelContourSet();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.VoxelContourSet constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_conts(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelContourSet gen_to_be_invoked = (Pathfinding.Voxels.VoxelContourSet)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.conts);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelContourSet gen_to_be_invoked = (Pathfinding.Voxels.VoxelContourSet)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, gen_to_be_invoked.bounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_conts(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelContourSet gen_to_be_invoked = (Pathfinding.Voxels.VoxelContourSet)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.conts = (System.Collections.Generic.List<Pathfinding.Voxels.VoxelContour>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.Voxels.VoxelContour>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelContourSet gen_to_be_invoked = (Pathfinding.Voxels.VoxelContourSet)translator.FastGetCSObj(L, 1);
                UnityEngine.Bounds gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.bounds = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
