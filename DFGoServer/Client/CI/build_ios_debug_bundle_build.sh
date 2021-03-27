svn update ..
python3 build.py ios debug --bundle build --uploadcdn --build --publisher none
svn commit ../Assets/HybridBundlesBuildVersionDataIOS.asset -m "CI auto commit file HybridBundlesBuildVersionDataIOS.asset"