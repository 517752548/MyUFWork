set trunk_path=%1
set tag_path=%2
set project=%3
set version=%4

svn mkdir %tag_path%/tags/t_%version% -m "mkdir tags %version%"
svn cp %trunk_path%/trunk/%project% %tag_path%/tags/t_%version%/%project% -m "%project% tags %version%"
