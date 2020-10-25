@ECHO OFF
ECHO "pls input u3u2(client) dir,ex:E:\03project\u3u2"
set /p p=
echo "svn update"
CD ..
svn up
svn info >.\version.txt
echo "pls run ExcelTemplateGenerator.java"
PAUSE
cd game_tools\
echo "move template files to client's dir"
XCOPY .\target\cs_target\db %p%\Assets\Scripts\app\db\Autocfg /m /y
PAUSE
ECHO "db\cfg file is new? move it : do nothing"
PAUSE