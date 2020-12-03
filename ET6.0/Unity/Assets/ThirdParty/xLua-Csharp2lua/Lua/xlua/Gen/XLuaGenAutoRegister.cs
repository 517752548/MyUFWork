#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
        
        
        static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray), UnityEngineRayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray2D), UnityEngineRay2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resources), UnityEngineResourcesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Keyframe), UnityEngineKeyframeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngineParticleSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkinnedMeshRenderer), UnityEngineSkinnedMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Light), UnityEngineLightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mathf), UnityEngineMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Debug), UnityEngineDebugWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastHit), UnityEngineRaycastHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Input), UnityEngineInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Physics), UnityEnginePhysicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Camera), UnityEngineCameraWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Animator), UnityEngineAnimatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<string>), SystemCollectionsGenericList_1_SystemString_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SceneManagement.SceneManager), UnityEngineSceneManagementSceneManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Type), SystemTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RuntimeAnimatorController), UnityEngineRuntimeAnimatorControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorControllerParameter), UnityEngineAnimatorControllerParameterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.Socket), SystemNetSocketsSocketWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.IPEndPoint), SystemNetIPEndPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.EndPoint), SystemNetEndPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.IPAddress), SystemNetIPAddressWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.AddressFamily), SystemNetSocketsAddressFamilyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.SocketType), SystemNetSocketsSocketTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.ProtocolType), SystemNetSocketsProtocolTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.SocketAsyncEventArgs), SystemNetSocketsSocketAsyncEventArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.SerializableAttribute), SystemSerializableAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.Path), SystemIOPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleManifest), UnityEngineAssetBundleManifestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.IOException), SystemIOIOExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoMemberAttribute), ProtoBufProtoMemberAttributeWrap.__Register);
        
        }
        
        static void wrapInit1(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoContractAttribute), ProtoBufProtoContractAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Text.Encoding), SystemTextEncodingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.Stream), SystemIOStreamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.MemoryStream), SystemIOMemoryStreamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute), MongoDBBsonSerializationAttributesBsonIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElementsAttribute), MongoDBBsonSerializationAttributesBsonIgnoreExtraElementsAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreIfDefaultAttribute), MongoDBBsonSerializationAttributesBsonIgnoreIfDefaultAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonDefaultValueAttribute), MongoDBBsonSerializationAttributesBsonDefaultValueAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonElementAttribute), MongoDBBsonSerializationAttributesBsonElementAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIdAttribute), MongoDBBsonSerializationAttributesBsonIdAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreIfNullAttribute), MongoDBBsonSerializationAttributesBsonIgnoreIfNullAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoConverterAttribute), ProtoBufProtoConverterAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoEnumAttribute), ProtoBufProtoEnumAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoIgnoreAttribute), ProtoBufProtoIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoIncludeAttribute), ProtoBufProtoIncludeAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoPartialIgnoreAttribute), ProtoBufProtoPartialIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoPartialMemberAttribute), ProtoBufProtoPartialMemberAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AsyncOperation), UnityEngineAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Convert), SystemConvertWrap.__Register);
        
        
        
        }
        
        static void Init(LuaEnv luaenv, ObjectTranslator translator)
        {
            
            wrapInit0(luaenv, translator);
            
            wrapInit1(luaenv, translator);
            
            
            translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
            
        }
        
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter(Init);
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
