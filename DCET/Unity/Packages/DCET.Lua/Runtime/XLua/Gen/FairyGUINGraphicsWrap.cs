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
    public class FairyGUINGraphicsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.NGraphics);
			Utils.BeginObjectRegister(type, L, translator, 0, 41, 19, 15);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetShaderAndTexture", _m_SetShaderAndTexture);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Tint", _m_Tint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMeshDirty", _m_SetMeshDirty);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateMesh", _m_UpdateMesh);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPopulateMesh", _m_OnPopulateMesh);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgameObject", _g_get_gameObject);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmeshFilter", _g_get_meshFilter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmeshRenderer", _g_get_meshRenderer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmesh", _g_get_mesh);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmeshFactory", _g_get_meshFactory);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcontentRect", _g_get_contentRect);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getflip", _g_get_flip);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettexture", _g_get_texture);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshader", _g_get_shader);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaterial", _g_get_material);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaterialKeywords", _g_get_materialKeywords);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getenabled", _g_get_enabled);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsortingOrder", _g_get_sortingOrder);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcolor", _g_get_color);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvertexMatrix", _g_get_vertexMatrix);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcameraPosition", _g_get_cameraPosition);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getblendMode", _g_get_blendMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdontClip", _g_get_dontClip);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmeshModifier", _g_get_meshModifier);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmeshFactory", _s_set_meshFactory);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcontentRect", _s_set_contentRect);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setflip", _s_set_flip);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settexture", _s_set_texture);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshader", _s_set_shader);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaterial", _s_set_material);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaterialKeywords", _s_set_materialKeywords);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setenabled", _s_set_enabled);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsortingOrder", _s_set_sortingOrder);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcolor", _s_set_color);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvertexMatrix", _s_set_vertexMatrix);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcameraPosition", _s_set_cameraPosition);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setblendMode", _s_set_blendMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdontClip", _s_set_dontClip);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmeshModifier", _s_set_meshModifier);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "gameObject", _g_get_gameObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "meshFilter", _g_get_meshFilter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "meshRenderer", _g_get_meshRenderer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mesh", _g_get_mesh);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "meshFactory", _g_get_meshFactory);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "contentRect", _g_get_contentRect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flip", _g_get_flip);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "texture", _g_get_texture);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shader", _g_get_shader);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "material", _g_get_material);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "materialKeywords", _g_get_materialKeywords);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enabled", _g_get_enabled);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sortingOrder", _g_get_sortingOrder);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "color", _g_get_color);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vertexMatrix", _g_get_vertexMatrix);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cameraPosition", _g_get_cameraPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "blendMode", _g_get_blendMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dontClip", _g_get_dontClip);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "meshModifier", _g_get_meshModifier);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "meshFactory", _s_set_meshFactory);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "contentRect", _s_set_contentRect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flip", _s_set_flip);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "texture", _s_set_texture);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shader", _s_set_shader);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "material", _s_set_material);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "materialKeywords", _s_set_materialKeywords);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enabled", _s_set_enabled);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sortingOrder", _s_set_sortingOrder);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "color", _s_set_color);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "vertexMatrix", _s_set_vertexMatrix);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cameraPosition", _s_set_cameraPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "blendMode", _s_set_blendMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dontClip", _s_set_dontClip);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "meshModifier", _s_set_meshModifier);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.GameObject>(L, 2))
				{
					UnityEngine.GameObject _gameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
					
					FairyGUI.NGraphics gen_ret = new FairyGUI.NGraphics(_gameObject);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.NGraphics constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetShaderAndTexture(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _shader = LuaAPI.lua_tostring(L, 2);
                    FairyGUI.NTexture _texture = (FairyGUI.NTexture)translator.GetObject(L, 3, typeof(FairyGUI.NTexture));
                    
                    gen_to_be_invoked.SetShaderAndTexture( 
                        _shader, 
                        _texture );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Tint(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Tint(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMeshDirty(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetMeshDirty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.UpdateMesh(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.UpdateContext _context = (FairyGUI.UpdateContext)translator.GetObject(L, 2, typeof(FairyGUI.UpdateContext));
                    float _alpha = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _grayed = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.Update( 
                        _context, 
                        _alpha, 
                        _grayed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPopulateMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.VertexBuffer _vb = (FairyGUI.VertexBuffer)translator.GetObject(L, 2, typeof(FairyGUI.VertexBuffer));
                    
                    gen_to_be_invoked.OnPopulateMesh( 
                        _vb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.gameObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_meshFilter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.meshFilter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_meshRenderer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.meshRenderer);
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
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mesh);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_meshFactory(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.meshFactory);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contentRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.contentRect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.PushFairyGUIFlipType(L, gen_to_be_invoked.flip);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_texture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.texture);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.shader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_material(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.material);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_materialKeywords(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.materialKeywords);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.enabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sortingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.sortingOrder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertexMatrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.vertexMatrix);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cameraPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.cameraPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blendMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.PushFairyGUIBlendMode(L, gen_to_be_invoked.blendMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dontClip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.dontClip);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_meshModifier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.meshModifier);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_meshFactory(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.meshFactory = (FairyGUI.IMeshFactory)translator.GetObject(L, 2, typeof(FairyGUI.IMeshFactory));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_contentRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                UnityEngine.Rect gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.contentRect = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                FairyGUI.FlipType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.flip = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_texture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.texture = (FairyGUI.NTexture)translator.GetObject(L, 2, typeof(FairyGUI.NTexture));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shader = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_material(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.material = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_materialKeywords(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.materialKeywords = (string[])translator.GetObject(L, 2, typeof(string[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enabled = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sortingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sortingOrder = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vertexMatrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                System.Nullable<UnityEngine.Matrix4x4> gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.vertexMatrix = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cameraPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                System.Nullable<UnityEngine.Vector3> gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.cameraPosition = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blendMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                FairyGUI.BlendMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.blendMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dontClip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dontClip = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_meshModifier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NGraphics gen_to_be_invoked = (FairyGUI.NGraphics)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.meshModifier = translator.GetDelegate<FairyGUI.NGraphics.MeshModifier>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
