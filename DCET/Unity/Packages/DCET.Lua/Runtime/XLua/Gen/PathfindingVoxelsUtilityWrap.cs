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
    public class PathfindingVoxelsUtilityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Voxels.Utility);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Min", _m_Min_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Max", _m_Max_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CopyVector", _m_CopyVector_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveDuplicateVertices", _m_RemoveDuplicateVertices_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.Voxels.Utility gen_ret = new Pathfinding.Voxels.Utility();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.Utility constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Min_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _c = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        float gen_ret = Pathfinding.Voxels.Utility.Min( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int _d = LuaAPI.xlua_tointeger(L, 4);
                    
                        int gen_ret = Pathfinding.Voxels.Utility.Min( 
                        _a, 
                        _b, 
                        _c, 
                        _d );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _c = (float)LuaAPI.lua_tonumber(L, 3);
                    float _d = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        float gen_ret = Pathfinding.Voxels.Utility.Min( 
                        _a, 
                        _b, 
                        _c, 
                        _d );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.Utility.Min!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Max_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _c = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        float gen_ret = Pathfinding.Voxels.Utility.Max( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int _d = LuaAPI.xlua_tointeger(L, 4);
                    
                        int gen_ret = Pathfinding.Voxels.Utility.Max( 
                        _a, 
                        _b, 
                        _c, 
                        _d );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _c = (float)LuaAPI.lua_tonumber(L, 3);
                    float _d = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        float gen_ret = Pathfinding.Voxels.Utility.Max( 
                        _a, 
                        _b, 
                        _c, 
                        _d );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.Utility.Max!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyVector_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float[] _a = (float[])translator.GetObject(L, 1, typeof(float[]));
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Vector3 _v;translator.Get(L, 3, out _v);
                    
                    Pathfinding.Voxels.Utility.CopyVector( 
                        _a, 
                        _i, 
                        _v );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveDuplicateVertices_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3[] _vertices = (PF.Int3[])translator.GetObject(L, 1, typeof(PF.Int3[]));
                    int[] _triangles = (int[])translator.GetObject(L, 2, typeof(int[]));
                    
                        PF.Int3[] gen_ret = Pathfinding.Voxels.Utility.RemoveDuplicateVertices( 
                        _vertices, 
                        _triangles );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
