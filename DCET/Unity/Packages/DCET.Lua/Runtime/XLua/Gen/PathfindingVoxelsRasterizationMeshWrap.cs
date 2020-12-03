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
    public class PathfindingVoxelsRasterizationMeshWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Voxels.RasterizationMesh);
			Utils.BeginObjectRegister(type, L, translator, 0, 20, 9, 9);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RecalculateBounds", _m_RecalculateBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Pool", _m_Pool);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoriginal", _g_get_original);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getarea", _g_get_area);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvertices", _g_get_vertices);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettriangles", _g_get_triangles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnumVertices", _g_get_numVertices);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnumTriangles", _g_get_numTriangles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmatrix", _g_get_matrix);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpool", _g_get_pool);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoriginal", _s_set_original);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setarea", _s_set_area);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvertices", _s_set_vertices);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settriangles", _s_set_triangles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnumVertices", _s_set_numVertices);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnumTriangles", _s_set_numTriangles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmatrix", _s_set_matrix);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpool", _s_set_pool);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "original", _g_get_original);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "area", _g_get_area);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vertices", _g_get_vertices);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "triangles", _g_get_triangles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "numVertices", _g_get_numVertices);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "numTriangles", _g_get_numTriangles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "matrix", _g_get_matrix);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pool", _g_get_pool);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "original", _s_set_original);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "area", _s_set_area);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "vertices", _s_set_vertices);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "triangles", _s_set_triangles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "numVertices", _s_set_numVertices);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "numTriangles", _s_set_numTriangles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "matrix", _s_set_matrix);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pool", _s_set_pool);
            
			
			
			
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
					
					Pathfinding.Voxels.RasterizationMesh gen_ret = new Pathfinding.Voxels.RasterizationMesh();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<UnityEngine.Vector3[]>(L, 2) && translator.Assignable<int[]>(L, 3) && translator.Assignable<UnityEngine.Bounds>(L, 4))
				{
					UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
					int[] _triangles = (int[])translator.GetObject(L, 3, typeof(int[]));
					UnityEngine.Bounds _bounds;translator.Get(L, 4, out _bounds);
					
					Pathfinding.Voxels.RasterizationMesh gen_ret = new Pathfinding.Voxels.RasterizationMesh(_vertices, _triangles, _bounds);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<UnityEngine.Vector3[]>(L, 2) && translator.Assignable<int[]>(L, 3) && translator.Assignable<UnityEngine.Bounds>(L, 4) && translator.Assignable<UnityEngine.Matrix4x4>(L, 5))
				{
					UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
					int[] _triangles = (int[])translator.GetObject(L, 3, typeof(int[]));
					UnityEngine.Bounds _bounds;translator.Get(L, 4, out _bounds);
					UnityEngine.Matrix4x4 _matrix;translator.Get(L, 5, out _matrix);
					
					Pathfinding.Voxels.RasterizationMesh gen_ret = new Pathfinding.Voxels.RasterizationMesh(_vertices, _triangles, _bounds, _matrix);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.RasterizationMesh constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecalculateBounds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RecalculateBounds(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pool(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Pool(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_original(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.original);
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
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.area);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertices(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.vertices);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_triangles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.triangles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_numVertices(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.numVertices);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_numTriangles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.numTriangles);
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
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, gen_to_be_invoked.bounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_matrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.matrix);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pool(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.pool);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_original(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.original = (UnityEngine.MeshFilter)translator.GetObject(L, 2, typeof(UnityEngine.MeshFilter));
            
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
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.area = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vertices(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_triangles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.triangles = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_numVertices(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.numVertices = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_numTriangles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.numTriangles = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                UnityEngine.Bounds gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.bounds = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_matrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                UnityEngine.Matrix4x4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.matrix = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pool(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.RasterizationMesh gen_to_be_invoked = (Pathfinding.Voxels.RasterizationMesh)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pool = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
