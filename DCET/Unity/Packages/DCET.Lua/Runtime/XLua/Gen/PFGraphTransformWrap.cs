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
using Pathfinding;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PFGraphTransformWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.GraphTransform);
			Utils.BeginObjectRegister(type, L, translator, 1, 7, 3, 0);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__mul", __MulMeta);
            
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WorldUpAtGraphPosition", _m_WorldUpAtGraphPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Transform", _m_Transform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TransformVector", _m_TransformVector);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InverseTransform", _m_InverseTransform);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getidentity", _g_get_identity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonlyTranslational", _g_get_onlyTranslational);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettranslation", _g_get_translation);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "identity", _g_get_identity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onlyTranslational", _g_get_onlyTranslational);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "translation", _g_get_translation);
            
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Multiply",__MulMeta);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getidentityTransform", PF.GraphTransform.identityTransform);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "identityTransform", PF.GraphTransform.identityTransform);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.Matrix4x4>(L, 2))
				{
					UnityEngine.Matrix4x4 _matrix;translator.Get(L, 2, out _matrix);
					
					PF.GraphTransform gen_ret = new PF.GraphTransform(_matrix);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.GraphTransform constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __MulMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.GraphTransform>(L, 1) && translator.Assignable<UnityEngine.Matrix4x4>(L, 2))
				{
					PF.GraphTransform leftside = (PF.GraphTransform)translator.GetObject(L, 1, typeof(PF.GraphTransform));
					UnityEngine.Matrix4x4 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<UnityEngine.Matrix4x4>(L, 1) && translator.Assignable<PF.GraphTransform>(L, 2))
				{
					UnityEngine.Matrix4x4 leftside;translator.Get(L, 1, out leftside);
					PF.GraphTransform rightside = (PF.GraphTransform)translator.GetObject(L, 2, typeof(PF.GraphTransform));
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of * operator, need PF.GraphTransform!");
            
        }
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WorldUpAtGraphPosition(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.WorldUpAtGraphPosition( 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Transform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.Transform( 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.Int3[]>(L, 2)) 
                {
                    PF.Int3[] _arr = (PF.Int3[])translator.GetObject(L, 2, typeof(PF.Int3[]));
                    
                    gen_to_be_invoked.Transform( 
                        _arr );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)) 
                {
                    UnityEngine.Vector3[] _arr = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    
                    gen_to_be_invoked.Transform( 
                        _arr );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphTransform>(L, 1)&& translator.Assignable<UnityEngine.Bounds>(L, 2)) 
                {
                    PF.GraphTransform _self = (PF.GraphTransform)translator.GetObject(L, 1, typeof(PF.GraphTransform));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.Transform( 
                        _bounds );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.GraphTransform.Transform!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TransformVector(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.TransformVector( 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InverseTransform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.InverseTransform( 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.Int3>(L, 2)) 
                {
                    PF.Int3 _point;translator.Get(L, 2, out _point);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.InverseTransform( 
                        _point );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.Int3[]>(L, 2)) 
                {
                    PF.Int3[] _arr = (PF.Int3[])translator.GetObject(L, 2, typeof(PF.Int3[]));
                    
                    gen_to_be_invoked.InverseTransform( 
                        _arr );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphTransform>(L, 1)&& translator.Assignable<UnityEngine.Bounds>(L, 2)) 
                {
                    PF.GraphTransform _self = (PF.GraphTransform)translator.GetObject(L, 1, typeof(PF.GraphTransform));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.InverseTransform( 
                        _bounds );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.GraphTransform.InverseTransform!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_identity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.identity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onlyTranslational(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.onlyTranslational);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_translation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphTransform gen_to_be_invoked = (PF.GraphTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.translation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
