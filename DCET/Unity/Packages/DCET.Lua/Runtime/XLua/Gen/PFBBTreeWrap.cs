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
    public class PFBBTreeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.BBTree);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RebuildFrom", _m_RebuildFrom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QueryClosest", _m_QueryClosest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QueryClosestXZ", _m_QueryClosestXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QueryInside", _m_QueryInside);
						
            
			
						
			
			
			
			
			
			
			
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
					
					PF.BBTree gen_ret = new PF.BBTree();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.BBTree constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BBTree gen_to_be_invoked = (PF.BBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RebuildFrom(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BBTree gen_to_be_invoked = (PF.BBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.TriangleMeshNode[] _nodes = (PF.TriangleMeshNode[])translator.GetObject(L, 2, typeof(PF.TriangleMeshNode[]));
                    
                    gen_to_be_invoked.RebuildFrom( 
                        _nodes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueryClosest(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BBTree gen_to_be_invoked = (PF.BBTree)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.NNConstraint>(L, 3)) 
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    float _distance;
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.QueryClosest( 
                        _p, 
                        _constraint, 
                        out _distance );
                        translator.Push(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _distance);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.NNConstraint>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<PF.NNInfoInternal>(L, 5)) 
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    float _distance = (float)LuaAPI.lua_tonumber(L, 4);
                    PF.NNInfoInternal _previous;translator.Get(L, 5, out _previous);
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.QueryClosest( 
                        _p, 
                        _constraint, 
                        ref _distance, 
                        _previous );
                        translator.Push(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _distance);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.BBTree.QueryClosest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueryClosestXZ(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BBTree gen_to_be_invoked = (PF.BBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    float _distance = (float)LuaAPI.lua_tonumber(L, 4);
                    PF.NNInfoInternal _previous;translator.Get(L, 5, out _previous);
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.QueryClosestXZ( 
                        _p, 
                        _constraint, 
                        ref _distance, 
                        _previous );
                        translator.Push(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _distance);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueryInside(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BBTree gen_to_be_invoked = (PF.BBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    
                        PF.TriangleMeshNode gen_ret = gen_to_be_invoked.QueryInside( 
                        _p, 
                        _constraint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
