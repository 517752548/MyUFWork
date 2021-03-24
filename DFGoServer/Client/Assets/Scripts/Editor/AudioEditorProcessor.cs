using System.IO;
using UnityEditor;
using UnityEngine;
public class AudioEditorProcessor : AssetPostprocessor
{
	public void OnPreprocessAudio()
	{
		AudioImporter importer = (AudioImporter)assetImporter;
		//背景音乐
		if (assetPath.IndexOf("Res/Audio/bgm") >= 0)
		{
			importer.forceToMono = false;
			importer.loadInBackground = true;
			importer.preloadAudioData = true;
			AudioImporterSampleSettings aiss = new AudioImporterSampleSettings
			{
				loadType = AudioClipLoadType.Streaming,
				compressionFormat = AudioCompressionFormat.Vorbis,
				quality = 1f,
				sampleRateSetting = AudioSampleRateSetting.OverrideSampleRate,
				sampleRateOverride = 22050,
			};
			importer.defaultSampleSettings = aiss;
			importer.SetOverrideSampleSettings("Standalone", aiss);
			importer.SetOverrideSampleSettings("Android", aiss);
			importer.SetOverrideSampleSettings("iPhone", aiss);
		}
		//音效
		else if (assetPath.IndexOf("Res/Audio/sfx") >= 0)
		{
			importer.forceToMono = false;
			importer.loadInBackground = true;
			importer.preloadAudioData = true;
			AudioImporterSampleSettings aiss = new AudioImporterSampleSettings
			{
				loadType = AudioClipLoadType.DecompressOnLoad,
				compressionFormat = AudioCompressionFormat.Vorbis,
				quality = 1f,
				sampleRateSetting = AudioSampleRateSetting.OverrideSampleRate,
				sampleRateOverride = 22050,
			};
			importer.defaultSampleSettings = aiss;
			importer.SetOverrideSampleSettings("Standalone", aiss);
			importer.SetOverrideSampleSettings("Android", aiss);
			importer.SetOverrideSampleSettings("iPhone", aiss);
		}
	}
}

