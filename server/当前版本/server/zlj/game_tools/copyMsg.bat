@ECHO OFF
ECHO "pls input u3u2(client) dir,ex:E:\03project\u3u2"
set /p p=
echo "svn update"
CD ..
svn up
svn info >.\version.txt
echo "pls run MessageGenerator.java"
PAUSE
cd game_tools\
echo "move msg files to client's dir:c2s,data,s2c,MessageReciver,MessageType"
XCOPY .\target\cs_target\c2s %p%\Assets\Scripts\app\net\c2s /m /y
XCOPY .\target\cs_target\data %p%\Assets\Scripts\app\net\data /m /y
XCOPY .\target\cs_target\s2c %p%\Assets\Scripts\app\net\s2c /m /y
XCOPY .\target\cs_target\MessageReciver.cs %p%\Assets\Scripts\app\net\MessageReciver.cs /m /y
XCOPY .\target\cs_target\MessageType.cs %p%\Assets\Scripts\app\net\MessageType.cs /m /y
PAUSE
ECHO "handler file is new? move it : do nothing"
PAUSE