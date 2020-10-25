@echo off 

echo Content-Type: text/html
echo.

rem CGI Body

cd D:\tr_make\deploy_tools
echo "start update config"
call run_deploytool.bat
echo "end update config"

cd D:\tr_make

echo "begin restart the servers"
call restart.bat
echo "end restart the servers"

exit