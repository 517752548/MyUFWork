set tag_path=%1
set branch_path=%2
set project=%3
set version=%4

svn mkdir %branch_path%/branches/%version% -m "mkdir branches %version%"
svn cp %tag_path%/tags/t_%version%/%project% %branch_path%/branches/%version%/%project% -m "%project% branches %version%"
