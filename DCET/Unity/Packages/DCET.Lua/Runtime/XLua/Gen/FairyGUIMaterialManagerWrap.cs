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
    public class FairyGUIMaterialManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.MaterialManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMaterial", _m_GetMaterial);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DestroyMaterials", _m_DestroyMaterials);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshMaterials", _m_RefreshMaterials);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Release", _m_Release);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "FairyGUI.MaterialManager does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMaterial(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.MaterialManager gen_to_be_invoked = (FairyGUI.MaterialManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _materialType = LuaAPI.xlua_tointeger(L, 2);
                    FairyGUI.BlendMode _blendMode;translator.Get(L, 3, out _blendMode);
                    uint _clipId = LuaAPI.xlua_touint(L, 4);
                    bool _firstInstance;
                    
                        FairyGUI.NMaterial gen_ret = gen_to_be_invoked.GetMaterial( 
                        _materialType, 
                        _blendMode, 
                        _clipId, 
                        out _firstInstance );
                        translator.Push(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _firstInstance);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyMaterials(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.MaterialManager gen_to_be_invoked = (FairyGUI.MaterialManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DestroyMaterials(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshMaterials(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.MaterialManager gen_to_be_invoked = (FairyGUI.MaterialManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RefreshMaterials(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Release(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.MaterialManager gen_to_be_invoked = (FairyGUI.MaterialManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Release(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
