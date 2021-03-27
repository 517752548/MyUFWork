svn update ..
/Library/Frameworks/Python.framework/Versions/3.7/bin/python3 build.py ios release --bundle rebuild --uploadcdn --build --publisher none
svn commit ../Assets/HybridBundlesBuildVersionDataIOS.asset -m "CI auto commit file HybridBundlesBuildVersionDataIOS.asset"
